using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    public float speed;


    private float direction = -1f; //will switch from -1 to +1 when changing direction
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        DetectEndOfPlatform();
    }

    private void Move() {
        transform.Translate(new Vector3(-speed,0f,0f));

    }

    private void DetectEndOfPlatform() {
        RaycastHit noDropHit;
        bool noDropAhead = Physics.Raycast(transform.position,new Vector3(1f * direction,-1.5f,0f),out noDropHit,12f);
        RaycastHit floorAheadHit;
        bool floorAhead = Physics.Raycast(transform.position + new Vector3(0f, -3f,0f),Vector3.left*-direction,out floorAheadHit,6f);
        Debug.Log(Vector3.forward);
        if(floorAhead == true) {
            Debug.Log(floorAheadHit.collider.name);
            if(floorAheadHit.collider.gameObject.tag == "Floor") {
                ChangeDirection();
            }
        }
        if(noDropAhead == false){
            ChangeDirection();
        };

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position,transform.position + new Vector3(1f*direction,-1.5f,0f).normalized * 12f);
        Gizmos.DrawLine(transform.position + new Vector3(0f,-3f,0f), transform.transform.position + new Vector3(direction *6f,-3f,0f));
    }

    private void ChangeDirection() {
        Debug.Log("Changing Direction");
        if(direction > 0) {
            direction = -1f;
            transform.eulerAngles = new Vector3(0f,0f,0f);
        } else {
            direction = 1f;
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        Debug.Log(direction);
    }
}
