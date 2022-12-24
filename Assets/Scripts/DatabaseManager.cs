using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;

    [SerializeField] string csv_FileName;

    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>(); // �̺�Ʈ �� ��� ������ ���� ��ųʸ�. ���� ��� ���Ұ� ������...

    public static bool isFinish = false; // �Ľ� ������ ���� ����Ǿ�����

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DialogueParser parser = GetComponent<DialogueParser>();
            Dialogue[] dialogues = parser.Parse(csv_FileName); // perser�� ���� �Ľ̵� ������ ����
            for (int i = 0; i < dialogues.Length; i++) dialogueDic.Add(i + 1, dialogues[i]); // ��ųʸ��� ����. 1����
            isFinish = true; // ���� �Ϸ�.
        }
    }

    public Dialogue[] GetDialogue(int _startNum, int _endNum)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();

        for (int i = 0; i <= _endNum - _startNum; i++) dialogueList.Add(dialogueDic[_startNum + i]);

        return dialogueList.ToArray();
    }
}
