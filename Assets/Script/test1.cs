using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private Longline longline;
    // Start is called before the first frame update
    void Start()
    {
        longline.SetupLine(points);
    }

   
}
