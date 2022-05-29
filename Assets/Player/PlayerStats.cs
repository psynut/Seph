using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
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

    public int Karma {
        get {
            return karma;
        }
        set {
            karma = value;
            uI.UpdateKharma(karma);
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

    //To be called by Enemy script or Ballistic script
    public void TakeHit(int hitStrength) {
        PlayAudioClip(hitSound);
        Health -= hitStrength;
        AssessHealth();
    }

    //Is the player dead (out of health yet?) If so, change state
    public void AssessHealth() {
            if(Health <= 0) {
                int m_setStateInt = (int)state;
                GameObject startingPoint = GameObject.FindWithTag("StartingPoints");
                Transform[] startingPoints = startingPoint.GetComponentsInChildren<Transform>();
                if(Karma < 7) {                 //If Karma is less than 7 player goes one step down.
                    m_setStateInt--;
                    if(m_setStateInt < 0) {
                        m_setStateInt = 0;
                    }
                } else {                        //If Karma is greater than 7 player goes to heaven.
                    m_setStateInt = 2;
                    Karma = 0;
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
