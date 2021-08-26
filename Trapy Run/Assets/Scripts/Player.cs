using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static bool RescueMode, WinMode;

    private readonly float _speed = 0.15f;
    private Vector2 _initialFingerPosition;

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
            if (Input.touches[0].phase == TouchPhase.Began || Input.touches[0].phase == TouchPhase.Stationary)
            {
                // Basically, I'm saving the finger position when the player touches the screen the first time or holds still.
                // And I compare that positions with new ones after player moved his finger.
                // Rescuing action will start if the player moves his or her finger only in the y-axis. (Player has 50 pixels of the x-axis error margin.)
                _initialFingerPosition = Input.touches[0].position;
            }

            if (Input.touches[0].phase == TouchPhase.Moved)
            {
                if (Input.touches[0].position.y > _initialFingerPosition.y + 50 || Input.touches[0].position.y < _initialFingerPosition.y - 50) //If finger moves in y axis, return.
                {
                    return;
                }
                if (Input.touches[0].position.x > _initialFingerPosition.x)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.05f);
                }
                else if (Input.touches[0].position.x < _initialFingerPosition.x)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.05f);
                }
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
