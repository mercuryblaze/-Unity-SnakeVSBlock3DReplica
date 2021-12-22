using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player Player;
    //private Vector3 _offset;
    /*
    private void Start()
    {
        _offset = transform.position - Player.transform.position;
    }
    */
    void LateUpdate()
    {
        if (Player != null)
            //transform.position = Player.transform.position + _offset;
            transform.position = new Vector3(0.0f, 5.5f, Player.transform.position.z - 3f);
    }
}