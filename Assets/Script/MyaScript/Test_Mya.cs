using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Mya : MonoBehaviour
{

    public bool IsPush = false;
  
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="note"&&IsPush)
        {
        Debug.Log(other.gameObject.name);

        Destroy(other.gameObject);
            IsPush = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "note" && IsPush)
        {
            Debug.Log(other.gameObject.name);

            Destroy(other.gameObject);
            IsPush = false;
        }
    }
    public void PushJudge()
    {
        IsPush = true;
        Invoke("Reset", 0.3f);
    }
    private void Reset()
    {
        IsPush = false;
    }
    public void ScaleUp()
    {
        transform.localScale *= 2.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
