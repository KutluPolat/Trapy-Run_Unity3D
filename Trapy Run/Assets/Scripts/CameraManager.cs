using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 _playerPosition;

    private void FixedUpdate()
    {
        if (Player.RescueMode)
            SecondView();
        else
        {
            _playerPosition = GameObject.Find("PlayerCapsule").transform.position;
            transform.position = new Vector3(_playerPosition.x - 20, transform.position.y, 0);
        }
    }

    private void SecondView()
    {
        var centerOfRescueBounds = GameObject.Find("RescuePoint").GetComponent<MeshRenderer>().bounds.center;
        var lerpPosition = new Vector3(centerOfRescueBounds.x - 20, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, lerpPosition, 0.05f);
    }

}
