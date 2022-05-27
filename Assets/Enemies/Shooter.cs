using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{   
    [Tooltip("Amount of time between shooting ballistic")]
    public float period = 10f;
    public float ballisticForce = 50f;
    public GameObject ballistic;
    public Transform shooter;

    private Transform player;
    private enum Direction {left, right};
    private Direction playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        FacePlayer();
        ShootBallistic();
    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();
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

    private void ShootBallistic() {
        int m_playerDirection = ((int)playerDirection * 2) - 1; //If player is to the left -1 / If player is to the right +1
        GameObject m_ballistic = Instantiate(ballistic,transform.position + new Vector3(m_playerDirection*8f,4f,0f),Quaternion.identity);
        m_ballistic.transform.parent = transform;
        m_ballistic.transform.eulerAngles = new Vector3(0f,0f,-m_playerDirection*90f);
        Rigidbody ballisticRB = m_ballistic.GetComponent<Rigidbody>();
        ballisticRB.AddForce(m_playerDirection * ballisticForce,0f,0f,ForceMode.Impulse);
        Invoke("ShootBallistic",period);
    }
}
