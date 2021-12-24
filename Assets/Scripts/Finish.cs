using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private SceneController sceneController;
    private CanvasController canvasController;

    private void Awake()
    {
        canvasController = FindObjectOfType(typeof(CanvasController)) as CanvasController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            Debug.Log("You Won!");
            canvasController.WinGame();
        }
    }
}