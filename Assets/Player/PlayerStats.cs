using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int score;

    public int karma;
    public int health;
    public GameObject wings;
    public GameObject horns;
    public GameObject sword;
    public GameObject fireball;

    private int originalHealth;

    public enum State { hellBound, earthBound, heavenly };
    private State state = State.earthBound;
    
    // Start is called before the first frame update
    void Start()
    {
        originalHealth = health;
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

    public void TakeHit(int hitStrength) {
        health -= hitStrength;
        AssessHealth();
    }

    public void AssessHealth() {
        if(health <= 0) {
            GameObject startingPoint = GameObject.FindWithTag("StartingPoints");
            Transform[] startingPoints = startingPoint.GetComponentsInChildren<Transform>();
            int m_setStateInt = ((int)state) - 1;
            if(m_setStateInt <0) {
                m_setStateInt = 0;
            }
            SetState((State)m_setStateInt);
            GetComponent<Rigidbody>().transform.position = startingPoints[m_setStateInt + 1].position;
            health = originalHealth;
        }
    }
}
