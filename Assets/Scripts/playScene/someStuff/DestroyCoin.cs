using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ball")
        {
            Destroy(this.gameObject);
        }
    }
}
