using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Tooltip("�̸�")]
    public string name;

    [Tooltip("���")]
    public string[] texts;

    [Tooltip("�̺�Ʈ ID")]
    public string[] number;

    [Tooltip("�ݺ� ����")]
    public string[] return_num;

}

[System.Serializable]
public class DialogueSelect
{
    [Tooltip("�̺�Ʈ ID")]
    public string[] number;

    [Tooltip("�̵� ����")]
    public string[] return_num;
}


[System.Serializable]
public class DialogueEvent
{
    public string name; //�̺�Ʈ �̸�

    public Vector2 line; //��� ������ ����
    public Dialogue[] dialogues;
}

[System.Serializable]
public class SelectEvent
{
    public string name; //�̺�Ʈ �̸�

    public Vector2 line; //��� ������ ����
    public DialogueSelect[] dialogueSelects;
}


