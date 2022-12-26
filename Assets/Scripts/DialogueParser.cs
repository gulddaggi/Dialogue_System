using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] DialogueParse(string _csvFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); // ��ȭ ����Ʈ. �Ľ� ������ ����
        TextAsset csvData = Resources.Load<TextAsset>(_csvFileName); //csv���� ���޹���

        string[] data = csvData.text.Split(new char[] { '\n' }); // ���� ������ �� ����

        for (int i = 1; i < data.Length;) // �׸� ���� ����
        {
            string[] row = data[i].Split(new char[] { ',' }); // �޸� ������ �� �׸� ����

            Dialogue dialogue = new Dialogue(); // ��� Ŭ����
            List<string> textList = new List<string>();
            // �ؽ�Ʈ ����Ʈ. ũ�Ⱑ �������� ���� �迭�� row[2]�� ������ �Ұ��Ͽ� ����Ʈ�� ���� �� ToArray�� ���
            List<string> eventIDList = new List<string>(); // �̺�Ʈ ��ȣ ����Ʈ
            List<string> returnNumList = new List<string>(); // �ݺ����� ����Ʈ

            dialogue.text_ID = row[0]; // �ؽ�ƮID ����

            do // ĳ���� ��� �ؽ�Ʈ�� 2�� �̻��� ��츦 ���. ������ ���ǻ������ ����ǵ���
            {
                // �� �׸� ������ ����
                textList.Add(row[2]);
                eventIDList.Add(row[3]);
                returnNumList.Add(row[4]);

                if (++i < data.Length) row = data[i].Split(new char[] { ',' }); // ���� ���� ������ ��� �׸� ���� ����
                else break;

            } while (row[0].ToString() == ""); // �ؽ�Ʈ ID�� ���Ե��� ���� ���� ��� �ݺ�

            // �ؽ�Ʈ ID �� ������ ����
            dialogue.texts = textList.ToArray();
            dialogue.event_ID = eventIDList.ToArray();
            dialogue.return_num = returnNumList.ToArray();

            dialogueList.Add(dialogue); // �̸� �ٽ� ��ȭ ����Ʈ�� ����. �ݺ����� ���� ��ü ��� �Ľ�
        }

        return dialogueList.ToArray(); // ���̾�α� �迭�� ��ȯ�Ͽ� ���� ��ȯ
    }
}
