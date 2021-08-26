using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
    }

    private void FixedUpdate()
    {
        Move();
        SpawnAnotherBeforeDestroy();
        Fall();
    }

    private void Move()
    {
        var lerpPosition = new Vector3(GameObject.Find("Player").transform.position.x + 50, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, lerpPosition, 0.004f);
    }

    private void SpawnAnotherBeforeDestroy()
    {
        if(transform.position.y < -5)
        {
            var spawnPosition = new Vector3(transform.position.x - 20, 1, transform.position.z);
            Instantiate(gameObject, spawnPosition, gameObject.transform.rotation);

            Destroy(gameObject);
        }
    }
    private void Fall()
    {
        if(transform.position.y < 0.9f)
        {
            gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        }
    }
}
