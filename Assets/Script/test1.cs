using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class test1 : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject longlinepre;

    public void SetPoint(int arraynum ,Transform point)
    {
        points[arraynum] = point;
    }

    public void SetPointSize(int size)
    { 
            Array.Resize(ref points,size);

    }
// Start is called before the first frame update
void Start()
    {
        GameObject obj = Instantiate(longlinepre, Vector3.zero, Quaternion.identity);
        obj.GetComponent<Longline>().SetupLine(points);
    }

   
}
