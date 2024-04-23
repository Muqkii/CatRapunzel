using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haarballaunching : MonoBehaviour
{
    public float launchForce;
    private Rigidbody rb;
    public Transform Launchpoint;

    public float despawnDelay;

    void Start()
    {
        Launchpoint = GameObject.FindGameObjectWithTag("Launcher").transform;
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Geen rigidbody gevonden!");
        }
        else
        {
            LaunchHaarbal(Launchpoint.forward);
        }
        StartCoroutine(DespawnAfterDelay());
    }
    /*private void Update()
    {
        if (gameObject.CompareTag("Sticky"))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }*/
    public void LaunchHaarbal(Vector3 direction)
    {
        if (rb != null)
        {
            rb.AddForce(direction * launchForce, ForceMode.Impulse);
        }
        else
        {
            Debug.LogWarning("Geen rigidbody gevonden!");
        }
    }
    IEnumerator DespawnAfterDelay()
    {
        yield return new WaitForSeconds(despawnDelay);
        Destroy(gameObject);
    }

}
