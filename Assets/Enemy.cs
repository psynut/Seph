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
}
