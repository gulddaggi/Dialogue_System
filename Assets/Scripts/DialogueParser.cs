using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] DialogueParse(string _csvFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); // 대화 리스트. 파싱 데이터 저장
        TextAsset csvData = Resources.Load<TextAsset>(_csvFileName); //csv파일 전달받음

        string[] data = csvData.text.Split(new char[] { '\n' }); // 엔터 단위로 행 구분

        for (int i = 1; i < data.Length;) // 항목별 저장 수행
        {
            string[] row = data[i].Split(new char[] { ',' }); // 콤마 단위로 각 항목 구분

            Dialogue dialogue = new Dialogue(); // 대사 클래스
            List<string> textList = new List<string>();
            // 텍스트 리스트. 크기가 정해지지 않은 배열에 row[2]의 대입이 불가하여 리스트를 생성 후 ToArray를 사용
            List<string> eventIDList = new List<string>(); // 이벤트 번호 리스트
            List<string> returnNumList = new List<string>(); // 반복여부 리스트

            dialogue.text_ID = row[0]; // 텍스트ID 저장

            do // 캐릭터 대사 텍스트가 2행 이상을 경우를 고려. 한차례 조건상관없이 수행되도록
            {
                // 각 항목 데이터 저장
                textList.Add(row[2]);
                eventIDList.Add(row[3]);
                returnNumList.Add(row[4]);

                if (++i < data.Length) row = data[i].Split(new char[] { ',' }); // 다음 행이 존재할 경우 항목 구분 수행
                else break;

            } while (row[0].ToString() == ""); // 텍스트 ID가 기입되지 않은 행일 경우 반복

            // 텍스트 ID 별 데이터 저장
            dialogue.texts = textList.ToArray();
            dialogue.event_ID = eventIDList.ToArray();
            dialogue.return_num = returnNumList.ToArray();

            dialogueList.Add(dialogue); // 이를 다시 대화 리스트에 저장. 반복문을 통해 전체 대사 파싱
        }

        return dialogueList.ToArray(); // 다이얼로그 배열로 변환하여 최종 반환
    }
}
