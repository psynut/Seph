using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanquishSoundMaker : MonoBehaviour
{

    public AudioClip[] vanquishSounds;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundEffectCatcher>().AddSEAudioSource(audioSource);
        int rnd = Random.Range(0,vanquishSounds.Length);
        audioSource.clip = vanquishSounds[rnd];
        audioSource.Play();
        Destroy(gameObject,vanquishSounds[rnd].length + .5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
