using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FileDisp : MonoBehaviour
{

    public Text m_text;
    
    public void SetText(string name)
    {
        m_text.text = name;
    }
    // Start is called before the first frame update
    void Start()
    {
        m_text = GetComponent<Text>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
