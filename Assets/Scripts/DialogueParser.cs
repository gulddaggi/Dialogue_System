using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _csvFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); // 수행되는 대화 리스트. 파싱 데이터 저장.
        TextAsset csvData = Resources.Load<TextAsset>(_csvFileName); //csv파일 전달받음.

        string[] data = csvData.text.Split(new char[] { '\n' });

        for (int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });

            Dialogue dialogue = new Dialogue(); // 대사 클래스

            dialogue.name = row[1];

            List<string> textList = new List<string>();
            // 텍스트 리스트. dialogue.texts는 크기가 정해지지 않은 배열이기에,
            // row[2]의 대입이 불가하여 리스트를 생성하고 후에 ToArray를 사용


            do
            {
                textList.Add(row[2]);

                if (++i < data.Length) row = data[i].Split(new char[] { ',' });
                else break;

            } while (row[0].ToString() == ""); // 한차례 조건상관없이 수행되도록. 텍스트만 존재하는 행을 고려.

            dialogue.texts = textList.ToArray();

            dialogueList.Add(dialogue); // 텍스트 ID 별 대사 집합에 대한 리스트가 구성됨.
        }
        return dialogueList.ToArray();
    }

    private void Start()
    {
        Parse("Dialogue");
    }
}
