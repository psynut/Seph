using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private ParticleSystem pSystem;
    private Collider m_collider;
    private MeshRenderer meshRenderer;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        pSystem = GetComponentInChildren<ParticleSystem>();
        m_collider = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<PlayerStats>()) {
            other.gameObject.GetComponent<PlayerStats>().Karma++;
            audioSource.Play();
            StartCoroutine(Appears(false,0f));
            StartCoroutine(Appears(true,60f));
            
        }
    }


    IEnumerator Appears(bool m_bool,float delayTime) {
        yield return new WaitForSeconds(delayTime);
        if(m_bool == false) {
            pSystem.Stop();
        } else {
            pSystem.Play();
        }
        m_collider.enabled = m_bool;
        meshRenderer.enabled = m_bool;
    }

    private void OnEnable() {
        m_collider.enabled = true;
        meshRenderer.enabled = true;
    }
}
