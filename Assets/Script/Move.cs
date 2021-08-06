using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //ノーツを移動させるスクリプト
    public float moveTime;
    //public GameObject destination;
    public GameObject lostPosition;
    private new Transform transform;
    private float time = 0f;
    private Vector3 v_start;
    public float speed = 10f;
    //private Vector3 v_destination;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        transform = GetComponent<Transform>();
        //v_destination = destination.transform.position;
        v_start = this.transform.position;
        //rb
        rb = this.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * -speed, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        //var v = time / moveTime;
        //transform.position = Vector3.Lerp(v_start, v_destination, v);
        //time += Time.deltaTime;

        
    }
   
   
}
