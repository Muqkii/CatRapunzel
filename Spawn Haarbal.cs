using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class SpawnHaarbal : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Transform spawnPoint;
    public bool linkerBal;

    public float spawnCooldown;
    public bool haarbalBestaat = false;
    public KeyCode spawnKey;

    private GameObject spawnedObject;

    private void Update()
    {
        Spawn();
    }
    private void Spawn()
    {
        if (Input.GetKeyDown(spawnKey) && haarbalBestaat == false && objectToSpawn != null &&  spawnPoint != null)
        {
            spawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
            //obj.GetComponent<HaarbalBOOM>().Bang();
            haarbalBestaat = true;
        }
        else if (Input.GetKeyDown(spawnKey) && haarbalBestaat == true)
        {
            haarbalBestaat = false;
            if (linkerBal == true)
            {
                spawnedObject.GetComponent<HaarbalBOOM>().Bang();
                Destroy(GameObject.FindGameObjectWithTag("Haarbal Links"));
            }
            else if (linkerBal == false)
            {
                spawnedObject.GetComponent<HaarbalBOOM>().Bang();
                Destroy(GameObject.FindGameObjectWithTag("Haarbal Rechts"));
            }
        }
        else
        {
            Debug.LogWarning("object can not spawn!");
        }
    }
}
