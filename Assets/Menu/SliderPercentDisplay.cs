using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderPercentDisplay : MonoBehaviour
{
    private Text text;

    private Slider slider;

    private void Awake() {
        text = GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInParent<Slider>();
        UpdateValue(slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateValue(int value) {
        text.text = value.ToString() + "%";
    }

    public void UpdateValue(float value) {
        text.text = Mathf.RoundToInt(value).ToString() + "%";
    }
}
