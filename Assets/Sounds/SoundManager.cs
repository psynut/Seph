using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    //In Sleepy Time Foundation set script order to 200 in order to let SoundManager to run AudioSlider to run after.

    private static SoundManager _instance;
    public static SoundManager Instance {
        get {
            return _instance;
        }
    }

    private int musicVolume;

    public int MusicVolume{
        get {return musicVolume;}
        set {
            musicVolume = value;
            PlayerPrefs.SetInt(MUSIC_VOLUME_KEY,value);
            musicPlayer.AdjustMusicVolume(value);
        }
    }

    private int sEVolume;

    public int SEVolume {
        get {
            return sEVolume;
        }
        set {
            sEVolume = value;
            PlayerPrefs.SetInt(SE_VOLUME_KEY,value);
            soundEffectCatcher.AdjustSEVolume(value);
        }
    }

    const string MUSIC_VOLUME_KEY = "music_volume";
    const string SE_VOLUME_KEY = "se_volume";

    private SoundEffectCatcher soundEffectCatcher;
    private MusicPlayer musicPlayer;
    // Start is called before the first frame update

    private void Awake() {
        Singleton();
        soundEffectCatcher = GetComponent<SoundEffectCatcher>();
        musicPlayer = GetComponent<MusicPlayer>();

    }
    void Start()
    {
        if((PlayerPrefs.GetInt(MUSIC_VOLUME_KEY) > 100 || PlayerPrefs.GetInt(MUSIC_VOLUME_KEY) <= 0)) {
            MusicVolume = 100;
        } else {
            MusicVolume = PlayerPrefs.GetInt(MUSIC_VOLUME_KEY);
        }
        if((PlayerPrefs.GetInt(SE_VOLUME_KEY) > 100 || PlayerPrefs.GetInt(SE_VOLUME_KEY) <= 0)) {
            SEVolume = 100;
        } else {
            SEVolume = PlayerPrefs.GetInt(SE_VOLUME_KEY);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void Singleton() {
        if(_instance != null && _instance != this) {
            Destroy(gameObject);
        } else {
            _instance = this;
        }
    }
}
