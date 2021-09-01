using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static bool RescueMode, WinMode;

    private readonly float _speed = 0.2f;

    private void FixedUpdate()
    {
        Win();
        MoveIfInEditor();
        MoveIfInAndroidPlatform();
        Rescue();
    }

    private void MoveIfInEditor()
    {
#if UNITY_EDITOR
        if (transform.position.y < 0.5f)
            gameObject.GetComponent<Animator>().SetTrigger("Fall");
        if (!Minions.Attack && !WinMode)
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
#if PLATFORM_ANDROID

        if (transform.position.y < 0.5f)
            gameObject.GetComponent<Animator>().SetTrigger("Fall");
        if (!Minions.Attack && !WinMode)
        {
            transform.position = new Vector3(transform.position.x + _speed, transform.position.y, transform.position.z);
        }

        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z - Input.touches[0].deltaPosition.x * 0.004f);
            }
        }
#endif
    }

    private void Rescue()
    {
        var centerOfRescuePoint = GameObject.Find("RescuePoint").GetComponent<MeshRenderer>().bounds.center.x;
        var endOfRescuePoint = GameObject.Find("RescuePoint").GetComponent<MeshRenderer>().bounds.max.x;

        if (transform.position.x > centerOfRescuePoint && !RescueMode)
        {
            RescueMode = true;

            var jump = new Vector3(0, 1f, 0);
            jump = jump.normalized;
            jump = jump * 750f;

            gameObject.GetComponent<Rigidbody>().AddForce(jump);
            gameObject.GetComponent<Animator>().SetTrigger("Dance");
        }
        else if(transform.position.x > endOfRescuePoint)
        {
            return;
        }
    }

    private void Win()
    {
        var centerOfHelicopter = GameObject.Find("Helicopter").GetComponent<MeshRenderer>().bounds.center.x;

        if (transform.position.x > centerOfHelicopter)
        {
            WinMode = true;
        }
    }
}
