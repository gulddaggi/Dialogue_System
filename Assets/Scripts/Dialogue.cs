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
}

[System.Serializable]
public class DialogueEvent
{
    public string name; //�̺�Ʈ �̸�

    public Vector2 line; //��� ������ ����
    public Dialogue[] dialogues;
}
