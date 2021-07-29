using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEvent : MonoBehaviour
{
    [SerializeField]
    GameObject notesGameObj;

    [SerializeField]
    AudioClip[] audioClip;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTapTrack1()
    {
        HitJudgment(Track.track1);
    }

    public void OnTapTrack2()
    {
        HitJudgment(Track.track2);
    }

    public void OnTapTrack3()
    {
        HitJudgment(Track.track3);
    }

    public void OnTapTrack4()
    {
        HitJudgment(Track.track4);
    }

    public void OnTapTrack5()
    {
        HitJudgment(Track.track5);
    }

    void HitJudgment(Track tappedTrack)
    {
        foreach (Transform note in notesGameObj.transform)
        {
            GameObject noteGameObj = note.gameObject;
            MoveController noteMC = noteGameObj.GetComponent<MoveController>();
            
            if (noteMC.track == tappedTrack)
            {
                if (noteMC.JudgementDistance != null)
                {
                    Debug.Log("’@‚¢‚½");
                    audioSource.clip = audioClip[0];
                    audioSource.Play();
                    Destroy(noteGameObj);
                }
            }
        }
    }
}
