using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningTrap : MonoBehaviour
{
    public int Speed;
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up * Speed * Time.deltaTime, Space.Self);
    }
}
