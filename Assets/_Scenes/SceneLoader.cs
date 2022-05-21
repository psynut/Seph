using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public enum Command {LoadNextOnDelay, LoadNextOnCall};
    [Tooltip("LoadNextOnDelay will load next scene in DelayTime (seconds) otherwise SceneLoader will wait for call from other source")]
    public Command sceneCommand;
    public float delayTime = 5;

    private void Awake() {
    }

    // Start is called before the first frame update
    void Start()
    {
        if(sceneCommand == SceneLoader.Command.LoadNextOnDelay) {
            Invoke("LoadNextScene",delayTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode) {

    }

    public void LoadNextScene() {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentBuildIndex + 1);
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene("sceneName");
    }

    public void LoadScene(int sceneBuildIndex) {
        SceneManager.LoadScene(sceneBuildIndex);
    }
}
