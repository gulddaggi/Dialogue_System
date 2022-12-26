using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCText : MonoBehaviour
{
    [SerializeField]
    GameObject obj;

    [SerializeField]
    string name;

    [SerializeField]
    TextMesh textMesh;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = obj.transform.rotation;
    }

    public void TextAppear()
    {
        if (textMesh.text == "")
        {
            textMesh.text = "E\n¥Î»≠\n" + name;
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }

    public void TextDisappear()
    {
        this.gameObject.SetActive(false);
    }

}
