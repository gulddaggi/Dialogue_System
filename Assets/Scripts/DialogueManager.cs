using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj.GetComponent<InteractionEvent>().GetDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
