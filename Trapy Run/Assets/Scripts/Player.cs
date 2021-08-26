using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private readonly float _speed = 0.1f;

    private void FixedUpdate()
    {
        MoveIfInEditor();
        MoveIfInAndroidPlatform();
    }

    private void MoveIfInEditor()
    {
#if UNITY_EDITOR
        if (!Minions.Attack)
        {
            transform.position = new Vector3(transform.position.x + _speed, transform.position.y, transform.position.z);
            if (Input.GetKey(KeyCode.A))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.05f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.05f);
            }
        }
        
#endif
    }

    private void MoveIfInAndroidPlatform()
    {

    }
}
