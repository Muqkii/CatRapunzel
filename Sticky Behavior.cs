using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBehavior : MonoBehaviour
{
    private bool stopped = false;

    private void OnCollisionEnter(Collision collision)
    {
        StickyContact(collision);
    }

    void StickyContact(Collision collision)
    {
        if (!stopped && collision.gameObject.CompareTag("Sticky"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }
            stopped = true;
        }
    }
}
