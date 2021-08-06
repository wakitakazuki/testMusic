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
        //配列に代入
        points[arraynum] = point;
    }

    public void SetPointSize(int size)
    { 
        //配列のサイズの決定
            Array.Resize(ref points,size);

    }
// Start is called before the first frame update
void Start()
    {
        //ロングライン生成
        GameObject obj = Instantiate(longlinepre, Vector3.zero, Quaternion.identity);
        obj.GetComponent<Longline>().SetupLine(points);
    }

   
}
