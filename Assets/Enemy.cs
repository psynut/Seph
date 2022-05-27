using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hP;

    public void TakeHit(int damage) {
        hP -= damage;
        if(hP <= 0) {
            Vanquish();
        }
    }

    private void Vanquish() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.GetComponent<PlayerStats>()) {
            collision.gameObject.GetComponent<PlayerStats>().TakeHit(hP / 2);
        }
    }
}
