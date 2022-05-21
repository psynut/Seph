using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioSlider : MonoBehaviour
{
    //In Sleepy Time Foundation set script order to 100 in order to let SoundManager to run frist


    public enum Type { Music, SoundEffect };
    public Type type;
    private Slider slider;
    private SoundManager soundManager;

    private void Awake() {
        slider = GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();

        //using Static instead:
        //soundManager = SoundManager.Instance;

        if(type == Type.Music) {
            slider.value = soundManager.MusicVolume;
        } else if(type == Type.SoundEffect) {
            slider.value = soundManager.SEVolume;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SendValueToSoundManager() {
        if(type == Type.Music) {
            soundManager.MusicVolume = (int)slider.value;
        } else if(type == Type.SoundEffect) {
            soundManager.SEVolume = (int)slider.value;
        }
    }
}
