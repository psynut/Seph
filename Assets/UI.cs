using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{

    public RectTransform healthForground;

    private int originalHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(int m_health) {
        healthForground.localScale = new Vector2(((float)m_health / (float)originalHealth),1f);
    }

    public void GetOriginalHealth(int m_value) {
        originalHealth = m_value;
    }
}
