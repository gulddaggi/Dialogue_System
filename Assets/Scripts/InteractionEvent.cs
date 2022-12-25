using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    [SerializeField]
    DialogueEvent dialogueEvent;
    [SerializeField]
    SelectEvent SelectEvent;

    public Dialogue[] GetDialogue()
    {
        dialogueEvent.dialogues = DatabaseManager.instance.GetDialogue(
            (int)dialogueEvent.line.x, (int)dialogueEvent.line.y);

        return dialogueEvent.dialogues;
    }

    public DialogueSelect[] GetDialogueSelects()
    {
        SelectEvent.dialogueSelects = DatabaseManager.instance.GetDialogueSelects(
            (int)SelectEvent.line.x, (int)SelectEvent.line.y);

        return SelectEvent.dialogueSelects;
    }

}
