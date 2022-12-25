using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    [SerializeField]
    Text text;

    bool isDialogue = false; // 대화중 여부
    bool isNext = false; // 스킵 키 입력 대기

    int lineCount = 0; // 캐릭터 대화 카운트
    int contextCount = 0; //대사 줄 카운트

    Dialogue[] dialogues;

    void Start()
    {
        StartDialogue(obj.GetComponent<InteractionEvent>().GetDialogue());
        obj.GetComponent<InteractionEvent>().GetDialogueSelects();
    }

    void Update()
    {
        if (isDialogue)
        {
            if (isNext)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isNext = false;
                    text.text = "";
                    if (++contextCount < dialogues[lineCount].texts.Length)
                    {
                        StartCoroutine(TypeWriter());
                    }
                    else
                    {
                        contextCount = 0;
                        if(++lineCount < dialogues.Length)
                        {
                            StartCoroutine(TypeWriter());
                        }
                        else // 대화 종료
                        {
                            
                        }
                    }
                }
            }
        }
    }

    IEnumerator TypeWriter()
    {
        string replaceText = dialogues[lineCount].texts[contextCount];
        replaceText = replaceText.Replace("'", ",");
        replaceText = replaceText.Replace("\\n", "\n");

        text.text = replaceText;

        isNext = true;
        yield return null;
    }


    public void StartDialogue(Dialogue[] _dialogues)
    {
        isDialogue = true;
        text.text = "";
        dialogues = _dialogues;

        StartCoroutine(TypeWriter());
    }

    void EndDialogue()
    {
        isDialogue = false;
        contextCount = 0;
        lineCount = 0;
        dialogues = null;
        isNext = false;
    }

}
