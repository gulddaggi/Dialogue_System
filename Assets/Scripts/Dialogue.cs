using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Tooltip("�ؽ�Ʈ ID")]
    public string text_ID;

    [Tooltip("���")]
    public string[] texts;

    [Tooltip("�̺�Ʈ ID")]
    public string[] event_ID;

    [Tooltip("�ݺ� ����")]
    public string[] return_num;

}

[System.Serializable]
public class DialogueSelect
{
    [Tooltip("�̺�Ʈ ID")]
    public string event_ID;

    [Tooltip("������")]
    public string[] choices;

    [Tooltip("�̵� ����")]
    public string[] move_num;
}


[System.Serializable]
public class DialogueEvent
{
    public Vector2 line; //��� ������ ����
    public Dialogue[] dialogues;
}

[System.Serializable]
public class SelectEvent
{
    public Vector2 line; //��� ������ ����
    public DialogueSelect[] dialogueSelects;
}


