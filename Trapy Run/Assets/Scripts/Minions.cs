using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions : MonoBehaviour
{
    private void FixedUpdate()
    {
        var lerpPosition = new Vector3(GameObject.Find("Player").transform.position.x + 10f, GameObject.Find("Player").transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, lerpPosition, 0.01f);
    }
}
