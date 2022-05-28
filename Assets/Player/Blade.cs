using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public int swordStrength = 50;

    private PlayerStats playerStats;
    private AudioSource audioSource;
    public bool beingSwung = false;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(!GetComponent<AudioSource>().clip) {
            Debug.LogWarning("No clip for swordstrike added to " + this.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Enemy>() == true && beingSwung == true) {
            other.GetComponent<Enemy>().TakeHit(swordStrength);
            audioSource.Play();
        }
    }
}
