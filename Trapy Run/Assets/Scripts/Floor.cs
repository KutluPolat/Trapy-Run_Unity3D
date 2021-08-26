using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(Fall());
        }      
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(0.2f);
        if (gameObject.transform.parent.gameObject.GetComponent<Rigidbody>() == null && !Minions.Attack)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 0.5f, 0.5f);
            gameObject.transform.parent.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            gameObject.transform.parent.gameObject.AddComponent<Rigidbody>();
        }
    }
}
