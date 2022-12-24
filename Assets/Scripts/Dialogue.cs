using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Tooltip("이름")]
    public string name;

    [Tooltip("대사")]
    public string[] texts;

    [Tooltip("이벤트 ID")]
    public string[] number;

    [Tooltip("반복 여부")]
    public string[] return_num;

}

[System.Serializable]
public class DialogueSelect
{
    [Tooltip("이벤트 ID")]
    public string[] number;

    [Tooltip("이동 지점")]
    public string[] return_num;
}


[System.Serializable]
public class DialogueEvent
{
    public string name; //이벤트 이름

    public Vector2 line; //대사 추출을 위함
    public Dialogue[] dialogues;
}

[System.Serializable]
public class SelectEvent
{
    public string name; //이벤트 이름

    public Vector2 line; //대사 추출을 위함
    public DialogueSelect[] dialogueSelects;
}


