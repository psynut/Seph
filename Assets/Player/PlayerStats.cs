using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int score;

    public int karma;
    public GameObject wings;
    public GameObject horns;
    public GameObject sword;
    public GameObject fireball;

    public enum State { hellBound, earthBound, heavenly };
    private State state = State.earthBound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState(State m_State) {
        state = m_State;
        if(m_State != State.heavenly) {
            wings.SetActive(false);
        } else {
            wings.SetActive(true);
        }
        if(m_State != State.hellBound) {
            Debug.Log("If statement sword=true, fireball=false, horns=false");
            sword.SetActive(true);
            fireball.SetActive(false);
            horns.SetActive(false);
        } else {
            Debug.Log("If statement sword=false, fireball=true, horns=true");
            sword.SetActive(false);
            fireball.SetActive(true);
            horns.SetActive(true);
        }
    }

    public State GetState() {
        return state;
    }
}
