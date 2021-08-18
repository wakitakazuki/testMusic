using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clook : MonoBehaviour
{
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 cl = Camera.main.transform.position;
        cl.y = transform.position.y;
        transform.LookAt(cl);*/
        this.transform.LookAt(this.camera.transform.position);
    }
}
