using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosionagain : MonoBehaviour
{
    public float radius;
    public float force;
    bool kaboom;


    void Update()
    {
        keyTrigger();

        bang();
    }

    void bang()
    {
        if (kaboom) //if 'e' is pressed
        {
            knockBack(); // call knockback
            Destroy(gameObject); //destroy bomb

            kaboom = false; //stop it from repeating
        }
    }

    void knockBack()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, radius); //search for gameobjects in the blast radius

        foreach(Collider nearbystuff in collider) //search in every object that is found
        {
            Rigidbody rb = nearbystuff.GetComponent<Rigidbody>(); //do they have rigidbodies?
            if(rb != null) //if they do
            {
                rb.AddExplosionForce(force, transform.position, radius); //then boom
            }
        }
    }

    void keyTrigger()
    {
        if (Input.GetKeyDown(KeyCode.E)) //check if 'e' is pressed
        {
            kaboom = true;
        }
    }
}
