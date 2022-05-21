using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpStrength = 5f;
    public float gravityAcceleration = 5f;

    private Rigidbody rb;
    private float xAxis = 0;
    private bool jumping = false;
    private float jumpTime;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Move();
    }

    private void FixedUpdate() {
        if(jumping == true && Time.time - jumpTime > .25f) {
            DetectFloor();
        }
        if(rb.velocity.y < 0) {
            AccelerateFall();
        }
        Move();
    }

    public void ControllerX(InputAction.CallbackContext context) {
        xAxis = context.ReadValue<Vector2>().x;
    }

    //public void Move() {
    //    transform.Translate(new Vector3(xAxis,0f,0f) * speed * Time.deltaTime);
    //}

    public void Move() {
        float m_XAxis = xAxis;
        if(jumping == true) {
            m_XAxis = xAxis / 4f;
        }
        Vector3 direction = new Vector3(m_XAxis,0f,0f);
        rb.AddRelativeForce(direction*speed, ForceMode.Impulse);
        Debug.Log(direction);
        if(rb.velocity.x != 0f && m_XAxis == 0 || ((rb.velocity.x >0 && m_XAxis < 0) || (rb.velocity.x < 0 && m_XAxis > 0))) {
            rb.velocity = new Vector3(0f,rb.velocity.y,0f);
        }
    }

    public void Jump() {
        if(jumping == false) {
            rb.AddForce(new Vector3(0f,2.0f,0) * jumpStrength, ForceMode.Impulse);
            jumping = true;
            jumpTime = Time.time;
        }
    }

    //Could either at layerMask or if hit.collider.GetComponent<floor>() if needing more specific 
    private void DetectFloor() {
        Debug.Log("Running DetectFloor()");
        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.down,out hit,6f)){
            Debug.Log(hit.collider.name);
            Debug.Log(hit.distance);
            jumping = false;
        };
    }

    private void AccelerateFall() {
        rb.AddForce(new Vector3(0f,-gravityAcceleration,0f),ForceMode.Acceleration);
    }

}
