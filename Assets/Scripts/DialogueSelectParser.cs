using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSelectParser : MonoBehaviour
{
    public DialogueSelect[] Parse(string csv_selectFileName)
    {
        List<DialogueSelect> selectList = new List<DialogueSelect>(); // 선택지 리스트. 파싱 데이터 저장
        TextAsset csvData = Resources.Load<TextAsset>(csv_selectFileName); //csv파일 전달받음

        string[] data = csvData.text.Split(new char[] { '\n' }); // 엔터 단위로 행 구분

        for (int i = 1; i < data.Length;) // 항목별 저장 수행
        {
            string[] row = data[i].Split(new char[] { ',' }); // 콤마 단위로 각 항목 구분

            DialogueSelect dialogueSelect = new DialogueSelect(); // 선택지 클래스
            List<string> choiceList = new List<string>(); // 텍스트 리스트
            List<string> moveNumList = new List<string>(); // 이동지점 리스트

            dialogueSelect.event_ID = row[0]; // 이벤트 ID 저장

            do // 이벤트 ID 별 선택지와 이동지점을 저장
            {
                // 각 항목 데이터 저장
                choiceList.Add(row[1]);
                moveNumList.Add(row[2]);

                if (++i < data.Length) row = data[i].Split(new char[] { ',' }); // 다음 행이 존재할 경우 항목 구분 수행
                else break;

            } while (row[0].ToString() == ""); // 텍스트 ID가 기입되지 않은 행일 경우 반복

            // 텍스트 ID 별 데이터 저장
            dialogueSelect.choices = choiceList.ToArray();
            dialogueSelect.move_num = moveNumList.ToArray();

            selectList.Add(dialogueSelect); // 리스트에 저장. 반복문을 통해 전체 파싱
        }
        return selectList.ToArray(); // 배열로 변환하여 최종 반환

    }
}
