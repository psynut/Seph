using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [Tooltip("Period of Time Between Hops")]
    public float period = 20;
    public float bounceX = 60f;
    public float bounceY = 50f;
    public float gravityAcceleration = 5f;

    private Rigidbody rb;
    private float nextPeriod;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        nextPeriod = Time.time + period;
        Debug.Log(nextPeriod);
    }
    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.velocity.y < 0) {
            AccelerateFall();
        }
    }

    private void Jump() {
        Debug.Log("Jumped");
        rb.AddForce(new Vector3(bounceX*RandomDirection(),bounceY,0f),ForceMode.Impulse);
        Invoke("Jump",period);
    }

    private float RandomDirection() {
        float m_direction = (float)((Random.Range(0,2) * 2) - 1);
        if(m_direction < 0) {
            transform.eulerAngles = new Vector3(0f,0f,0f);
        } else {
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        return m_direction;
    }

    private void AccelerateFall() {
        rb.AddForce(new Vector3(0f,-gravityAcceleration,0f),ForceMode.Acceleration);
    }


}
