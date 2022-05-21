using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    public enum Command {Stop, PlayOnce, LoopOne, CompoundLoop};
    [Tooltip("These are the tracks for a scene")]
    public AudioClip[] audioClips;
    public Command[] sceneCommand;
    [Header("Will play nth entry in AudioClips")]
    public int[] startTrack;
    // Start is called before the first frame update

    public AudioClip fail, success; //Use these for when player loses life, goals, etc.

    private AudioSource audioSource;

    void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode) {
        int buildIndex = scene.buildIndex;
        switch((int)sceneCommand[buildIndex]) {
            case 0:
                stop();
                break;
            case 1:
                playOnce(startTrack[buildIndex]);
                break;
            case 2:
                playLoop(startTrack[buildIndex]);
                break;
            case 3:
                playComplexLoop(startTrack[buildIndex]);
                break;
            default:
                Debug.LogWarning("Undefined command passed to OnSceneLoad Switch statement");
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AdjustMusicVolume(int newVolume) {
        audioSource.volume = ((float)newVolume) / 100f;
    }

    private void stop() {
        audioSource.clip = null;
        audioSource.Stop();
    }

    private void playOnce(int trackNo) {
        audioSource.loop = false;
        audioSource.clip = audioClips[trackNo];
        audioSource.Play();
    }

    private void playLoop(int trackNo) {
        audioSource.loop = true;
        audioSource.clip = audioClips[trackNo];
        audioSource.Play();
    }

    //Will play the first track, then loop 2nd track
    //Make the second track the following item in the startTrack array
    private void playComplexLoop(int trackNo) {
        playOnce(trackNo);
        Invoke("PlayLoop",audioClips[trackNo].length);
    }

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }
}
