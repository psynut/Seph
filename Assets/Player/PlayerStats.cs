using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int score;

    public int karma;
    public int health;
    public int Health{
        get {
            return health;
        }
        set {
            health = value;
            uI.UpdateHealth(health);
        }
    }
    public GameObject wings;
    public GameObject horns;
    public GameObject sword;
    public GameObject fireball;

    public AudioClip hitSound, hellTransition, earthTransition, heavenTransition;

    public UI uI;

    private int originalHealth;
    private AudioSource audioSource;

    public enum State { hellBound, earthBound, heavenly };
    private State state = State.earthBound;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        originalHealth = health;
        uI.GetOriginalHealth(health);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(State m_State) {
        MusicPlayer m_musicPlayer = GameObject.FindGameObjectWithTag("Audio").GetComponent<MusicPlayer>();
        AudioSource m_audioSource = m_musicPlayer.GetComponent<AudioSource>();
        state = m_State;
        switch((int)m_State) {
            case 0: //HellBound
                wings.SetActive(false);
                sword.SetActive(false);
                fireball.SetActive(true);
                horns.SetActive(true);
                PlayAudioClip(hellTransition);
                m_audioSource.Stop();
                m_audioSource.clip = m_musicPlayer.audioClips[2];
                m_audioSource.Play();
                break;
            case 1: //EarthBound
                wings.SetActive(false);
                sword.SetActive(true);
                fireball.SetActive(false);
                horns.SetActive(false);
                PlayAudioClip(earthTransition);
                m_audioSource.Stop();
                m_audioSource.clip = m_musicPlayer.audioClips[0];
                m_audioSource.Play();
                break;
            case 2: //HeavenBound
                wings.SetActive(true);
                sword.SetActive(true);
                fireball.SetActive(false);
                horns.SetActive(false);
                PlayAudioClip(heavenTransition);
                m_audioSource.Stop();
                m_audioSource.clip = m_musicPlayer.audioClips[1];
                m_audioSource.Play();
                break;
            default:
                Debug.LogWarning("Improper Integer in PlayerStats SetState() - Check State Enum");
                break;
        }
    }

    public State GetState() {
        return state;
    }

    public void TakeHit(int hitStrength) {
        Health -= hitStrength;
        AssessHealth();
    }

    public void AssessHealth() {
        if(Health <= 0) {
            GameObject startingPoint = GameObject.FindWithTag("StartingPoints");
            Transform[] startingPoints = startingPoint.GetComponentsInChildren<Transform>();
            int m_setStateInt = ((int)state) - 1;
            if(m_setStateInt <0) {
                m_setStateInt = 0;
            }
            SetState((State)m_setStateInt);
            GetComponent<Rigidbody>().transform.position = startingPoints[m_setStateInt + 1].position;
            Health = originalHealth;
        }
    }

    private void PlayAudioClip(AudioClip m_audioClip) {
        audioSource.loop = false;
        audioSource.clip = m_audioClip;
        audioSource.Play();
    }
}
