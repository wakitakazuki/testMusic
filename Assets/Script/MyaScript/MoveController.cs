using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    GameObject tapEventGameObj;

    [SerializeField]
    float speed = 10f;

    public Track track = Track.track3;

    const string judgmentTag = "Judgment";

    TapEvent tapEvent;

    Rigidbody rb;

    EventTrigger trigger;



    float? judgementDistance = null;

    public float? JudgementDistance
    {
        get { return judgementDistance; }
    }



    // Start is called before the first frame update
    void Start()
    {
        tapEvent = tapEventGameObj.GetComponent<TapEvent>();

        trigger = this.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((eventData) =>
        {
            switch (this.track)
            {
                case Track.track1:
                    tapEvent.OnTapTrack1();
                    break;
                case Track.track2:
                    tapEvent.OnTapTrack2();
                    break;
                case Track.track3:
                    tapEvent.OnTapTrack3();
                    break;
                case Track.track4:
                    tapEvent.OnTapTrack4();
                    break;
                case Track.track5:
                    tapEvent.OnTapTrack5();
                    break;
                default:
                    Debug.Log("error");
                    break;
            }
        });
        trigger.triggers.Add(entry);


        //rb
        rb = this.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * speed, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(JudgementDistance);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == judgmentTag)
        {
            judgementDistance = this.transform.position.z - other.gameObject.transform.position.z;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == judgmentTag)
        {
            judgementDistance = this.transform.position.z - other.gameObject.transform.position.z;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == judgmentTag)
        {
            judgementDistance = null;

        }
    }

}
