using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public GameObject ballistic;

    private Transform player;
    private Transform shooter;
    private enum Direction {left, right};
    private Direction playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FacePlayer() {
        if(transform.position.x > player.position.x) {
            playerDirection = Direction.left;
            shooter.eulerAngles = new Vector3(0f,-90f,0f);
        } else {
            playerDirection = Direction.right;
            shooter.eulerAngles = new Vector3(0f,90f,0f);
        }
    }
}
