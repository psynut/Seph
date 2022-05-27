using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hP;

    private int originalHP;

    private void Start() {
        originalHP = hP;
    }

    public void TakeHit(int damage) {
        hP -= damage;
        if(hP <= 0) {
            Vanquish();
        }
    }

    private void Vanquish() {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UI>().AddToScoreint(originalHP);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.GetComponent<PlayerStats>()) {
            collision.gameObject.GetComponent<PlayerStats>().TakeHit(hP / 2);
        }
    }
}
