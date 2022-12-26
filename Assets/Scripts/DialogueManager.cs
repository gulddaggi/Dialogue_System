using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    [SerializeField]
    Camera cam;

    //��簡 ��µǴ� �ؽ�Ʈ ����
    [SerializeField]
    Text dialogueText;

    [SerializeField]
    Text skipText;

    [SerializeField]
    GameObject selector;

    [SerializeField]
    GameObject textPrefab;

    bool isSelectOn = false;
    bool isTextAppear = false;
    bool isDialogue = false; // ��ȭ�� ����
    bool canSkip = false; // ��ŵ ���� ����

    int lineCount = 0; // ĳ���� ��ȭ ī��Ʈ
    int contextCount = 0; //��� �� ī��Ʈ

    static int startNum = 0;
    static int endNum = 0;

    Dialogue[] dialogues;
    DialogueSelect[] dialogueSelects;

    void Start()
    {
        selector.SetActive(false);
        StartDialogue(obj.GetComponent<InteractionEvent>().GetDialogue());
    }

    void Update()
    {
        DialogueCheck();
    }

    // ��ȭ ����
    public void StartDialogue(Dialogue[] _dialogues)
    {
        isDialogue = true;
        dialogueText.text = "";
        dialogues = _dialogues;

        //��� ��� �ڷ�ƾ ����
        StartCoroutine(TypeWriter());
    }

    // ��ǥ, ���� ��ȯ �� ��� ���
    IEnumerator TypeWriter()
    {
        if (!isSelectOn)
        {
            isDialogue = true;
            string replaceText = dialogues[lineCount].texts[contextCount];
            replaceText = replaceText.Replace("'", ",");
            replaceText = replaceText.Replace("\\n", "\n");

            //�ؽ�Ʈ ���� �� ��ȯ�� �ؽ�Ʈ ����.
            dialogueText.text = replaceText;

            canSkip = true;

            //������ �̺�Ʈ üũ
            SelectEventCheck();
            SelectReturnCheck();

            yield return new WaitForSeconds(3.0f);

            Debug.Log("pass");

            NextDialogue();
        }
    }

    void StartSelectEvent(int _eventID, DialogueSelect[] _dialogueSelects)
    {
        selector.SetActive(true);
        dialogueSelects = _dialogueSelects;
        int textNum = dialogueSelects[_eventID].choices.Length;
        Dictionary<GameObject, string> a = new Dictionary<GameObject, string>();

        for (int i = 0; i < textNum; i++)
        {
            GameObject select_txt = Instantiate(textPrefab, selector.transform);
            select_txt.GetComponentInChildren<Text>().text = (i + 1).ToString() + ". " + dialogueSelects[_eventID].choices[i];
            a.Add(select_txt, dialogueSelects[_eventID].move_num[i]);
            select_txt.GetComponentInChildren<Button>().onClick.AddListener(delegate { Selected(_eventID, a[select_txt]); });
        }
    }

    //��ȭ ����
    void EndDialogue()
    {
        isDialogue = false;
        contextCount = 0;
        lineCount = 0;
        dialogues = null;
        canSkip = false;
        this.gameObject.GetComponent<SceneManage>().LoadPlayScene();
    }

    void DialogueCheck()
    {
        if (isDialogue)
        {
            if (canSkip)
            {
                //��ŵ
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    DialogueSkip();
                }
            }
        }
    }

    void DialogueSkip()
    {
        if (!isTextAppear)
        {
            StartCoroutine(TextAppear());
            return;
        }

        /*else
        {
            //StopCoroutine(TextDisappear());
            //StartCoroutine(TextDisappear());
        }*/
        StopCoroutine(TypeWriter());
        NextDialogue();

    }
    
    void NextDialogue()
    {
        if (!isSelectOn)
        {
            canSkip = false;
            dialogueText.text = "";

            if (++contextCount < dialogues[lineCount].texts.Length)
            {
                StartCoroutine(TypeWriter());
            }
            else
            {
                contextCount = 0;
                if (++lineCount < dialogues.Length)
                {
                    cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y + 180.0f, cam.transform.eulerAngles.z);
                    StartCoroutine(TypeWriter());
                }
                else // ��ȭ ����
                {
                    EndDialogue();
                }
            }
        }

    }

    IEnumerator TextAppear()
    {
        isTextAppear = true;
        skipText.text = "<color=red>Tab</color> <color=black>�ǳʶٱ�</color>";
        skipText.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, 0);
        while(skipText.color.a > 0.0f)
        {
            skipText.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, skipText.color.a + (Time.deltaTime / 2.0f));
            yield return null;
        }
        //StartCoroutine(TextDisappear());
    }

    /*IEnumerator TextDisappear()
    {
        yield return new WaitForSeconds(2.0f);
        skipText.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, 1);
        while (skipText.color.a < 1.0f)
        {
            skipText.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, skipText.color.a - (Time.deltaTime / 3.0f));
            yield return null;
        }

        isTextAppear = false;
    }*/

    void SelectEventCheck()
    {
        string eventIDText = dialogues[lineCount].event_ID[contextCount];

        if (eventIDText != "") // �̺�Ʈ �ѹ��� �����Ұ��
        {
            isSelectOn = true;
            StopCoroutine(TypeWriter());
            canSkip = false;
            isDialogue = false;

            int eventID = Convert.ToInt32(eventIDText);

            StartSelectEvent(eventID - 1, obj.GetComponent<InteractionEvent>().GetDialogueSelects());
        }
        else
        {
            isSelectOn = false;
        }
    }

    void SelectReturnCheck()
    {
        string isReturnText = dialogues[lineCount].return_num[contextCount];

        if (isReturnText == "1")
        {
            isSelectOn = true;
            //StopCoroutine(TypeWriter());
            selector.SetActive(true);
        }
    }

    //������ ���� �� �ش� ��� ���
    public void Selected(int _eventID, string str_move_num)
    {
        //������ ��� ��µǵ��� ���� ����
        int moveNum = Convert.ToInt32(str_move_num);
        lineCount = moveNum - 1;
        contextCount = 0;

        // ������ ��Ȱ��ȭ
        selector.SetActive(false);

        isSelectOn = false;
        //��� ���
        StartCoroutine(TypeWriter());
    }

}
