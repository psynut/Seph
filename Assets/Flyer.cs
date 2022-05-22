using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : MonoBehaviour
{
    public float speed = 10f;
    public float distance = 50f;

    private float originalX;
    private float direction = -1.0f; //flips to positive 1 when turning around

    // Start is called before the first frame update
    void Start()
    {
        originalX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
        KeepInBounds();
    }

    private void Fly() {
        transform.Translate(new Vector3(direction,0f,0f) * speed * Time.deltaTime, Space.World);
    }

    private void KeepInBounds() {
        if(transform.position.x < originalX - distance) {
            direction = 1.0f;
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        if(transform.position.x > originalX) {
            direction = -1.0f;
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    private void TurnAround() {
        transform.Rotate(new Vector3(0f,180f,0f));
    }

    private void OnDrawGizmos() {
        Vector3 squareCenter = transform.position + new Vector3(-distance / 2f,0f,0f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(squareCenter,new Vector3(distance,5f,5f));
    }
}
