using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class MusicSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.dataPath + "/";
            string[] names = Directory.GetFiles(@path, "*", SearchOption.AllDirectories);
            foreach (string name in names)
            {
                Console.WriteLine(name);
                Debug.Log(name);
            }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
