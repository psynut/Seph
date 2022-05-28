using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

    public int fireballStrength = 60;


    private void Awake() {
        Invoke("TimeLimit",5f);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.GetComponent<Enemy>()) {
            collision.gameObject.GetComponent<Enemy>().TakeHit(fireballStrength);
        }
        Destroy(gameObject);
    }

    private void TimeLimit() {
        Destroy(gameObject);
    }
}
