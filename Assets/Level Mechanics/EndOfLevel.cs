using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevel : MonoBehaviour
{

    public SceneLoader sceneLoader;
    public PlayerStats.State state = PlayerStats.State.hellBound;


    private void OnTriggerEnter(Collider other) {
        switch((int)state) {
            case 0:
                sceneLoader.LoadScene("EndGameHell");
                break;
            case 1:
                sceneLoader.LoadScene("EndGameEarth");
                break;
            case 2:
                sceneLoader.LoadScene("EndGameHeaven");
                break;
            default:
                sceneLoader.LoadScene("EndGameHell");
                Debug.LogWarning("State improperly declared in " + this.name);
                break;
        }
    }
}
