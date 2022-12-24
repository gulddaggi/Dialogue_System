using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _csvFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); // ����Ǵ� ��ȭ ����Ʈ. �Ľ� ������ ����.
        TextAsset csvData = Resources.Load<TextAsset>(_csvFileName); //csv���� ���޹���.

        string[] data = csvData.text.Split(new char[] { '\n' });

        for (int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });

            Dialogue dialogue = new Dialogue(); // ��� Ŭ����

            dialogue.name = row[1];

            List<string> textList = new List<string>();
            // �ؽ�Ʈ ����Ʈ. dialogue.texts�� ũ�Ⱑ �������� ���� �迭�̱⿡,
            // row[2]�� ������ �Ұ��Ͽ� ����Ʈ�� �����ϰ� �Ŀ� ToArray�� ���


            do
            {
                textList.Add(row[2]);

                if (++i < data.Length) row = data[i].Split(new char[] { ',' });
                else break;

            } while (row[0].ToString() == ""); // ������ ���ǻ������ ����ǵ���. �ؽ�Ʈ�� �����ϴ� ���� ���.

            dialogue.texts = textList.ToArray();

            dialogueList.Add(dialogue); // �ؽ�Ʈ ID �� ��� ���տ� ���� ����Ʈ�� ������.
        }
        return dialogueList.ToArray();
    }

    private void Start()
    {
        Parse("Dialogue");
    }
}
