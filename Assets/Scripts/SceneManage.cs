using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public void LoadDialogueScene()
    {
        SceneManager.LoadScene("DialogueScene");
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
