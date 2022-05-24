using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class TheEndText : MonoBehaviour
{
    [TextArea]
    public string message = "The End...\nFor Now..";
    [Tooltip("Higher number = Slower speed / Lower number = Faster speed")]
    public float speed;

    private Text m_text;
    private StringBuilder sb;
    private int stringLength;
    private int placeHolder;

    // Start is called before the first frame update
    void Start()
    {
        sb = new StringBuilder();
        m_text = GetComponent<Text>();
        stringLength = message.Length;
        placeHolder = stringLength;
        NextLetter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void NextLetter() {
        if(placeHolder > 0) {
            sb.Append(message[stringLength - placeHolder]);
            placeHolder--;
            m_text.text = sb.ToString();
            Debug.Log(sb.ToString());
            Invoke("NextLetter",speed);
        }
    }
}
