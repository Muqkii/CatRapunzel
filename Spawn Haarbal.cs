using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnHaarbal : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    public bool linkerBal;

    public float spawnCooldown;
    public bool haarbalBestaat = false;
    public KeyCode spawnKey;

    private void Update()
    {
        Spawn();
    }
    private void Spawn()
    {
        if (Input.GetKeyDown(spawnKey) && haarbalBestaat == false && objectToSpawn != null &&  spawnPoint != null)
        {
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            haarbalBestaat = true;
        }
        else if (Input.GetKeyDown(spawnKey) && haarbalBestaat == true)
        {
            haarbalBestaat = false;
            if (linkerBal == true)
            {
                Destroy(GameObject.FindGameObjectWithTag("Haarbal Links"));
            }
            else if (linkerBal == false)
            {
                Destroy(GameObject.FindGameObjectWithTag("Haarbal Rechts"));
            }
        }
        else
        {
            Debug.LogWarning("object can not spawn!");
        }
    }
}
