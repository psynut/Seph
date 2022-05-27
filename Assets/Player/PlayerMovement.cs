using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpStrength = 5f;
    public float fireballForce = 50f;
    public float fireballPeriod = 3f;
    public float gravityAcceleration = 5f;

    public Transform sephTransform;
    public GameObject fireballPrefab;

    private Animator animator;
    private Rigidbody rb;
    private PlayerStats playerStats;
    private Blade blade;

    private float xAxis = 0;
    //private bool jumping = false;
    //private float jumpTime;
    private bool grounded;
    private float nextFireball = 0f;

    private void Awake() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerStats = GetComponent<PlayerStats>();
        blade = GetComponentInChildren<Blade>();
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
        //if(jumping == true && Time.time - jumpTime > .25f) {
        //    DetectFloor();
        //}
        if(Grounded() == false) {
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
        //if(jumping == true) {
        //    m_XAxis = xAxis / 4f;
        //}
        if(Grounded() == false && playerStats.GetState() != PlayerStats.State.heavenly) {
            m_XAxis = xAxis / 3f;
        }
        Vector3 direction = new Vector3(m_XAxis,0f,0f);
        rb.AddRelativeForce(direction*speed, ForceMode.Impulse);

        //Comes to quicker stop if changing directions or stopping.
        if(rb.velocity.x != 0f && m_XAxis == 0 || ((rb.velocity.x >0 && m_XAxis < 0) || (rb.velocity.x < 0 && m_XAxis > 0))) {
            rb.velocity = new Vector3(0f,rb.velocity.y,0f);
        }

        //Face proper direction of movement
        if(rb.velocity.x > 0 && sephTransform.eulerAngles.y == 180) {
            sephTransform.eulerAngles = new Vector3(0f,0f,0f);
        }
        if(rb.velocity.x < 0 && sephTransform.eulerAngles.y == 0) {
            sephTransform.eulerAngles = new Vector3(0f,180f,0f);
        }
    }

    public void Jump() {
        if(Grounded() || playerStats.GetState() == PlayerStats.State.heavenly) {
            rb.AddForce(new Vector3(0f,2.0f,0) * jumpStrength,ForceMode.Impulse);
        }
        //if(jumping == false) {
        //    rb.AddForce(new Vector3(0f,2.0f,0) * jumpStrength, ForceMode.Impulse);
        //    jumping = true;
        //    jumpTime = Time.time;
        //}
    }

    //Could either at layerMask or if hit.collider.GetComponent<floor>() if needing more specific 
    //private void DetectFloor() {
    //    Debug.Log("Running DetectFloor()");
    //    RaycastHit hit;
    //    if(Physics.Raycast(transform.position,Vector3.down,out hit,6f)){
    //        Debug.Log(hit.collider.name);
    //        Debug.Log(hit.distance);
    //        jumping = false;
    //    };
    //}

    private bool Grounded() {
        bool m_bool = false;
        RaycastHit hit;
        if(Physics.Raycast(transform.position,Vector3.down,out hit,10.5f)) {
            if(hit.collider.gameObject.tag == "Floor" || hit.collider.GetComponent<Enemy>()) {
                m_bool = true;            
            }
        }
        return m_bool;
    }

    private void AccelerateFall() {
        rb.AddForce(new Vector3(0f,-gravityAcceleration,0f),ForceMode.Acceleration);
    }

    public void FireButton() {
        //If Player isn't HellBound     SwingSword
        if((int)playerStats.GetState() != 0) {
            SwingSword();
        } else {
            //If Player is in Hell          UseFireball
            UseFireBall();
        } 
    }

    private void SwingSword() {
        animator.SetTrigger("SwingSword");
        blade.beingSwung = true;
    }

    public void SwordSwang() {
        blade.beingSwung = false;
    }

    private void UseFireBall() {
        if(Time.time > nextFireball) {
            int directionMultiplier;
            if(sephTransform.eulerAngles.y == 0) {
                directionMultiplier = 1;
            } else {
                directionMultiplier = -1;
            }
            GameObject newFireball = Instantiate(fireballPrefab,transform.position + new Vector3(1f * directionMultiplier,1f,0f) * 3,Quaternion.identity);
            newFireball.transform.eulerAngles = new Vector3(0f,((directionMultiplier + 2) / 1) * 180f,0f);
            newFireball.GetComponent<Rigidbody>().AddForce(new Vector3(directionMultiplier * fireballForce,0f,0f),ForceMode.Impulse);
            nextFireball = Time.time + fireballPeriod;
        }
    }

}
