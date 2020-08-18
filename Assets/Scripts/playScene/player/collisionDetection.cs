using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetection : MonoBehaviour
{
    private string hitedObject;

    public delegate void CollisionOccured(string hitedObject);
    public event CollisionOccured  collisionOccured;

    private void OnTriggerEnter(Collider other)
    {
        collisionOccured.Invoke(other.gameObject.tag);
    }
}
