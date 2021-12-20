using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player Player;
    private Vector3 _offset;

    private void Start()
    {
        _offset = transform.position - Player.transform.position;
    }

    void LateUpdate()
    {
        if (Player != null)
            transform.position = Player.transform.position + _offset;
    }
}