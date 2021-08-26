using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions : MonoBehaviour
{
    private bool _isMagnetTriggered, _isAttackTriggered;
    public static bool Attack;

    private void FixedUpdate()
    {
        Move();
        SpawnAnotherBeforeDestroy();
        Fall();
    }

    private void Move()
    {
        var playerPosition = GameObject.Find("PlayerCapsule").transform.position;

        if (_isAttackTriggered)
        {
            var triggeredLerpPosition = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
            transform.position = Vector3.Lerp(transform.position, triggeredLerpPosition, 0.03f);
            return;
        }

        if (_isMagnetTriggered)
        {
            var triggeredLerpPosition = new Vector3(playerPosition.x + 50, transform.position.y, playerPosition.z);
            transform.position = Vector3.Lerp(transform.position, triggeredLerpPosition, 0.003f);
            return;
        }

        var lerpPosition = new Vector3(playerPosition.x + 50, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, lerpPosition, 0.003f);
    }

    private void SpawnAnotherBeforeDestroy()
    {
        if(transform.position.y < -5)
        {
            if (!_isAttackTriggered)
            {
                var spawnPosition = new Vector3(transform.position.x - 20, 1, transform.position.z);
                Instantiate(gameObject, spawnPosition, gameObject.transform.rotation);
            }

            Destroy(gameObject);
        }
    }

    private void Fall()
    {
        if(transform.position.y < 0.9f && !_isAttackTriggered)
        {
            gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MinionMagnet")
        {
            _isMagnetTriggered = true;
        }
        if (other.tag == "TriggerAttack")
        {
            if (!_isAttackTriggered) // I prevent it from repeating on every trigger.
            {
                var random = Random.Range(1f, 2f);
                var jump = new Vector3(0, random, 0);
                jump = jump.normalized;
                jump = jump * 500f;

                gameObject.GetComponent<Rigidbody>().AddForce(jump);
            }

            Attack = true;
            _isAttackTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Floor")
        {
            Debug.Log("Exit");
            var downForce = new Vector3(0, -1f, 0).normalized;
            downForce = downForce * 100f;
            gameObject.GetComponent<Rigidbody>().AddForce(downForce);
        }
    }
}
