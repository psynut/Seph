using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int score;

    public int karma;
    public GameObject wings;

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
        if(m_State == State.heavenly) {
            wings.SetActive(true);
        } else {
            wings.SetActive(false);
        }
    }

    public State GetState() {
        return state;
    }
}
