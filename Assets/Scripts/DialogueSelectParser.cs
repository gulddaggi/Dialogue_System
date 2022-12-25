using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSelectParser : MonoBehaviour
{
    public DialogueSelect[] Parse(string csv_selectFileName)
    {
        List<DialogueSelect> selectList = new List<DialogueSelect>(); // ������ ����Ʈ. �Ľ� ������ ����
        TextAsset csvData = Resources.Load<TextAsset>(csv_selectFileName); //csv���� ���޹���

        string[] data = csvData.text.Split(new char[] { '\n' }); // ���� ������ �� ����

        for (int i = 1; i < data.Length;) // �׸� ���� ����
        {
            string[] row = data[i].Split(new char[] { ',' }); // �޸� ������ �� �׸� ����

            DialogueSelect dialogueSelect = new DialogueSelect(); // ������ Ŭ����
            List<string> choiceList = new List<string>(); // �ؽ�Ʈ ����Ʈ
            List<string> moveNumList = new List<string>(); // �̵����� ����Ʈ

            dialogueSelect.event_ID = row[0]; // �̺�Ʈ ID ����

            do // �̺�Ʈ ID �� �������� �̵������� ����
            {
                // �� �׸� ������ ����
                choiceList.Add(row[1]);
                moveNumList.Add(row[2]);

                if (++i < data.Length) row = data[i].Split(new char[] { ',' }); // ���� ���� ������ ��� �׸� ���� ����
                else break;

            } while (row[0].ToString() == ""); // �ؽ�Ʈ ID�� ���Ե��� ���� ���� ��� �ݺ�

            // �ؽ�Ʈ ID �� ������ ����
            dialogueSelect.choices = choiceList.ToArray();
            dialogueSelect.move_num = moveNumList.ToArray();

            selectList.Add(dialogueSelect); // ����Ʈ�� ����. �ݺ����� ���� ��ü �Ľ�
        }
        return selectList.ToArray(); // �迭�� ��ȯ�Ͽ� ���� ��ȯ

    }
}
