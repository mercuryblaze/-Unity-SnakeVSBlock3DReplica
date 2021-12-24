using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private int nextSceneID;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneID, LoadSceneMode.Single);
    }
}
