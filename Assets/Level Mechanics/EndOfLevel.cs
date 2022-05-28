using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{

    public SceneLoader sceneLoader;

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<PlayerMovement>()) {
            sceneLoader.LoadScene("LevelEnd");
        }
    }
}
