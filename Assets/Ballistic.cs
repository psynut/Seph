using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballistic : MonoBehaviour
{

    public int hitStrength = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.GetComponent<PlayerStats>()) {
            collision.gameObject.GetComponent<PlayerStats>().TakeHit(hitStrength);
        }
        Destroy(gameObject);
    }
}
