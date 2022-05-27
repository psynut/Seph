using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCylinder : MonoBehaviour
{
    //If player is higher than 360 switch to heaven
    //If player is lower than -200 switch to hell
    public Transform player;
    public Material hellBackgroudMaterial, earthBackgroundMaterial, heavenBackgroundMaterial;
    public float speed;

    private float lastX;

    // Start is called before the first frame update
    void Start()
    {
        lastX = player.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f,(player.position.x- lastX)*speed,0f));
        lastX = player.position.x;
        if(player.position.y > 360f) {
            GetComponent<MeshRenderer>().material = heavenBackgroundMaterial;
        } else if(player.transform.position.y < -200) {
            GetComponent<MeshRenderer>().material = hellBackgroudMaterial;
        } else {
            GetComponent<MeshRenderer>().material = earthBackgroundMaterial;
        }
    }
}
