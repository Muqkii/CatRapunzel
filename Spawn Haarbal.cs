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
    public float armingTime;

    private bool ableToBoom = false;

    public float spawnCooldown;
    private bool haarbalBestaat = false;
    public KeyCode spawnKey;

    public AudioSource src;
    public AudioClip sfx2, sfx3;

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

            BlechSound();

            Invoke(nameof(BoomPrimer), armingTime);
        }
        else if (Input.GetKeyDown(spawnKey) && haarbalBestaat == true && ableToBoom == true)
        {
            haarbalBestaat = false;
            if (linkerBal == true)
            {
                spawnedObject.GetComponent<HaarbalBOOM>().Bang();
                Destroy(GameObject.FindGameObjectWithTag("Haarbal Links"));

                BoomSound();

                ableToBoom = false;
            }
            else if (linkerBal == false)
            {
                spawnedObject.GetComponent<HaarbalBOOM>().Bang();
                Destroy(GameObject.FindGameObjectWithTag("Haarbal Rechts"));

                BoomSound();

                ableToBoom = false;
            }
        }
    }
    private void BoomPrimer()
    {
        ableToBoom = true;
    }

    public void BlechSound()
    {
        src.clip = sfx2;
        src.Play();
    }

    public void BoomSound()
    {
        src.clip = sfx3;
        src.Play();
    }
}
