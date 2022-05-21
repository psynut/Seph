using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasSoundEffect : MonoBehaviour
{
    private SoundEffectCatcher soundEffectCatcher;
    private AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {
        soundEffectCatcher = GameObject.FindWithTag("Audio").GetComponent<SoundEffectCatcher>();

        //It's possible this may be more efficient, less time costly, etc, but I'm skitish about using static instance for this
        //soundEffectCatcher = SoundManager.Instance.GetComponent<SoundEffectCatcher>();
        if(audioSource) {
            soundEffectCatcher.AddSEAudioSource(audioSource);
        } else {
            Debug.LogWarning(this.name + "has HasSoundEffect component attached, but no AudioSource was found to send to SoundEffectCatcher");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
