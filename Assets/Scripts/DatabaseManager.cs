using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;

    [SerializeField] string csv_DialogueFileName;
    [SerializeField] string csv_DialogueSelectFileName;

    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>(); // 텍스트 ID 별 대사 접근을 위한 딕셔너리.
    Dictionary<int, DialogueSelect> dialogueSelectDic = new Dictionary<int, DialogueSelect>(); // 이벤트 ID 별 대사 접근을 위한 딕셔너리.

    public static bool isFinish = false; // 파싱 데이터 전부 저장되었는지

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            // perser를 통해 파싱된 데이터 전달
            DialogueParser parser = GetComponent<DialogueParser>();
            DialogueSelectParser selectParser = GetComponent<DialogueSelectParser>();
            Dialogue[] dialogues = parser.Parse(csv_DialogueFileName);
            DialogueSelect[] dialogueSelects = selectParser.Parse(csv_DialogueSelectFileName);

            // 딕셔너리에 저장. 1색인
            for (int i = 0; i < dialogues.Length; i++)
            {

                dialogueDic.Add(i + 1, dialogues[i]); 
            }

            for(int i = 0; i < dialogueSelects.Length; i++)
            {
                dialogueSelectDic.Add(i + 1, dialogueSelects[i]);
            }

            isFinish = true; // 저장 완료.
        }
    }

    public Dialogue[] GetDialogue(int _startNum, int _endNum)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();

        for (int i = 0; i <= _endNum - _startNum; i++) dialogueList.Add(dialogueDic[_startNum + i]);

        return dialogueList.ToArray();
    }

    public DialogueSelect[] GetDialogueSelects(int _startNum, int _endNum)
    {
        List<DialogueSelect> selectList = new List<DialogueSelect>();

        for (int i = 0; i <= _endNum - _startNum; i++) selectList.Add(dialogueSelectDic[_startNum + i]);

        return selectList.ToArray();
    }

}
