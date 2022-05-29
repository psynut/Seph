using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {
    public static int score;

    public RectTransform healthForground;
    public RectTransform kharmaForground;
    public Text scoreText;
    public Text instructionsText;

    private int originalHealth;

    // Start is called before the first frame update
    void Start() {
        Invoke("RemoveInstructionText",15f);
        UpdateKharma(0);
    }

    // Update is called once per frame
    void Update() {

    }

    public void UpdateHealth(int m_health) {
        healthForground.localScale = new Vector2(((float)m_health / (float)originalHealth),1f);
    }

    //We're going with 7 kharma points is full
    public void UpdateKharma(int m_kharma) {
        Mathf.Clamp(m_kharma,0,7);
        kharmaForground.localScale = new Vector2((float)m_kharma / 7f,1f);
    }

    public void GetOriginalHealth(int m_value) {
        originalHealth = m_value;
    }

    public void RemoveInstructionText() {
        if(instructionsText) {
            instructionsText.enabled = false;
        }
    }

    public void AddToScoreint(int m_Score){
            score += m_Score;
            scoreText.text = "Score:  " + score;
    }
}
