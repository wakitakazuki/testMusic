using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Longline : MonoBehaviour
{
    //ラインレンダラーの定義
    private LineRenderer longnote;
    private Transform[] points;
    //public Vector3[] position = new Vector3[] { };
    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < points.Length; i++)
        {
            //位置座標の更新
            longnote.SetPosition(i, points[i].position);
        }
    }
    private void Start()
    {
        //longnote = GetComponent<LineRenderer>();
       
    }
    public void SetupLine(Transform[] points)
    {
        //ロングノーツに配列を渡す
        longnote = GetComponent<LineRenderer>();
        longnote.positionCount = points.Length;
        this.points = points;
    }
    
}
