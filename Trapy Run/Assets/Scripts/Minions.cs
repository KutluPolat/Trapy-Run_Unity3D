using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions : MonoBehaviour
{
    private bool _isMagnetTriggered, _isAttackTriggered;
    private float _speed = 0.015f;
    private Vector3 _playerPosition;

    public static bool Attack;
    public bool AlternativeMinionLeft, AlternativeMinionRight;
    public GameObject Minion;

    private void Start()
    {
        _playerPosition = GameObject.Find("PlayerCapsule").transform.position;
    }

    private void FixedUpdate()
    {
        if (AlternativeMinionLeft)
            MoveTowardsRight();
        else if (AlternativeMinionRight)
            MoveTowardsLeft();
        else
            MoveTowardsPlayer();

        SpawnAnotherBeforeDestroy();
    }

    private void MoveTowardsPlayer()
    {
        if (Player.RescueMode) // Don't move if player win.
            return;

        _playerPosition = GameObject.Find("PlayerCapsule").transform.position;

        if (_isAttackTriggered)
        {
            var triggeredLerpPosition = new Vector3(_playerPosition.x, transform.position.y, _playerPosition.z);
            transform.position = Vector3.Lerp(transform.position, triggeredLerpPosition, 0.03f);
            return;
        }

        if (_isMagnetTriggered)
        {
            var triggeredLerpPosition = new Vector3(_playerPosition.x + 50, transform.position.y, _playerPosition.z);
            transform.position = Vector3.Lerp(transform.position, triggeredLerpPosition, 0.003f);
            return;
        }

        var lerpPosition = new Vector3(_playerPosition.x + 50, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, lerpPosition, 0.003f);
    }
    private void MoveTowardsRight()
    {
        if (Player.RescueMode) // Don't move if player win.
            return;

        var _decisivePosition = GameObject.Find("DecisivePlane").transform.position;

        if(transform.position.z < _decisivePosition.z)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            _playerPosition = GameObject.Find("PlayerCapsule").transform.position;
            var triggeredLerpPosition = new Vector3(_playerPosition.x, transform.position.y, _playerPosition.z);
            transform.position = Vector3.Lerp(transform.position, triggeredLerpPosition, _speed);

            return;
        }

        var lerpPosition = new Vector3(_decisivePosition.x - 2, transform.position.y, _decisivePosition.z - 10);

        transform.position = Vector3.Lerp(transform.position, lerpPosition, 0.003f);
        return;
    }

    private void MoveTowardsLeft()
    {
        if (Player.RescueMode) // Don't move if player win.
            return;

        var _decisivePosition = GameObject.Find("DecisivePlaneRight").transform.position;

        if (transform.position.z > _decisivePosition.z)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            _playerPosition = GameObject.Find("PlayerCapsule").transform.position;
            var triggeredLerpPosition = new Vector3(_playerPosition.x, transform.position.y, _playerPosition.z);
            transform.position = Vector3.Lerp(transform.position, triggeredLerpPosition, _speed);

            return;
        }

        var lerpPosition = new Vector3(_decisivePosition.x + 2, transform.position.y, _decisivePosition.z + 10);

        transform.position = Vector3.Lerp(transform.position, lerpPosition, 0.003f);
        return;
    }

    private void SpawnAnotherBeforeDestroy()
    {
        if(transform.position.y < -5)
        {
            if (!_isAttackTriggered && !Player.RescueMode) // Don't spawn if game over or win.
            {
                var spawnPosition = new Vector3(_playerPosition.x - 30, 2, transform.position.z);
                Instantiate(Minion, spawnPosition, Quaternion.Euler(0, 90, 0));
            }

            Destroy(gameObject);
        }
    }

    private void Fall()
    {
        var downForce = new Vector3(0, -1f, 0).normalized;
        downForce = downForce * 100f;
        gameObject.GetComponent<Rigidbody>().AddForce(downForce);
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
                gameObject.GetComponent<Animator>().SetTrigger("Fall");
                GameObject.Find("PlayerCapsule").GetComponent<Animator>().SetTrigger("Fall");
            }

            Attack = true;
            _isAttackTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Floor")
        {
            Fall();
        }
    }
}
