using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionLoader : MonoBehaviour
{
    GameObject section;

    // Start is called before the first frame update
    void Start()
    {
        section = GetComponentInParent<Transform>().gameObject;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            section.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            section.SetActive(false);
        }
    }
}
