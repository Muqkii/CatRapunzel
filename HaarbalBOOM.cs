using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaarbalBOOM : MonoBehaviour
{
    public float radius;
    public float force;
    public void Bang()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, radius); //search for gameobjects in the blast radius

        foreach (Collider nearbystuff in collider) //search in every object that is found
        {
            Rigidbody rb = nearbystuff.GetComponent<Rigidbody>(); //do they have rigidbodies?
            if (rb != null) //if they do
            {
                rb.AddExplosionForce(force, transform.position, radius); //then boom
            }
        }
    }
}
