using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Tooltip("텍스트 ID")]
    public string text_ID;

    [Tooltip("대사")]
    public string[] texts;

    [Tooltip("이벤트 ID")]
    public string[] event_ID;

    [Tooltip("반복 여부")]
    public string[] return_num;

}

[System.Serializable]
public class DialogueSelect
{
    [Tooltip("이벤트 ID")]
    public string event_ID;

    [Tooltip("선택지")]
    public string[] choices;

    [Tooltip("이동 지점")]
    public string[] move_num;
}


[System.Serializable]
public class DialogueEvent
{
    public Vector2 line; //대사 추출을 위함
    public Dialogue[] dialogues;
}

[System.Serializable]
public class SelectEvent
{
    public Vector2 line; //대사 추출을 위함
    public DialogueSelect[] dialogueSelects;
}


