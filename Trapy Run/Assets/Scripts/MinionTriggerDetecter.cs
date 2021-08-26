using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionTriggerDetecter : MonoBehaviour
{
    private static bool _isMagnetTriggered;

    public static bool GetMagnetTrigger()
    {
        return _isMagnetTriggered;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MinionMagnet")
        {
            _isMagnetTriggered = true;
        }
    }
}
