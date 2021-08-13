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
        try
        {
            string[] names = Directory.GetFiles(@"/Assets", "*", SearchOption.AllDirectories);
            foreach (string name in names)
            {
                Console.WriteLine(name);
                Debug.Log(name);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
