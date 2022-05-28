using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public PlayerStats.State destinationRealm;

    private Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        destination = GetComponentInChildren<Destination>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<PlayerStats>() == true) {
            other.GetComponent<PlayerStats>().SetState(destinationRealm);
            other.GetComponent<Rigidbody>().transform.position = destination.transform.position;
        }
    }
}
