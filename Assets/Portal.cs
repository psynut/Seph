using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

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
        Debug.Log("OnTriggerEnter Called " + other.name);
        if(other.tag == "Player") {
            other.attachedRigidbody.transform.Translate(destination.transform.position);
        }
    }
}
