using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hP;


    public AudioClip[] vanquishedClips;

    private int originalHP;
    private AudioSource audioSource;

    private void Start() {
        originalHP = hP;
        audioSource = GetComponent<AudioSource>();
    }

    public void TakeHit(int damage) {
        hP -= damage;
        if(hP <= 0) {
            Vanquish();
        }
    }

    private void Vanquish() {
        Transform[] childTransforms = GetComponentsInChildren<Transform>();
        for(int i = childTransforms.Length - 1; i < 0; i--) {
            Destroy(childTransforms[i]);
        }
        GetComponent<Collider>().enabled = false;            
        PlayAudioClip(vanquishedClips[Random.Range(0,vanquishedClips.Length)]);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UI>().AddToScoreint(originalHP);
        Destroy(gameObject,3f);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.GetComponent<PlayerStats>()) {
            collision.gameObject.GetComponent<PlayerStats>().TakeHit(hP / 2);
        }
    }
    private void PlayAudioClip(AudioClip m_audioClip) {
        audioSource.loop = false;
        audioSource.clip = m_audioClip;
        audioSource.Play();
    }
}
