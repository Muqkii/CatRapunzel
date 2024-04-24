using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject respawnPoint;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTag"))
        {
            other.transform.position = respawnPoint.transform.position;
        }
    }
}
