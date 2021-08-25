using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 _playerPosition;


    private void FixedUpdate()
    {
        _playerPosition = GameObject.Find("Player").transform.position;

        transform.position = new Vector3(_playerPosition.x - 40, 22, 0);
    }

}
