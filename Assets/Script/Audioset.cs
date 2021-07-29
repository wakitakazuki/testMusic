using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Audioset : MonoBehaviour
{
    public GameObject AudioObject;
    AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        clip = AudioObject.GetComponent<AudioSource>().clip;
        startaudio();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void startaudio()
    {
        float[] allSamples = new float[clip.samples * clip.channels];
        clip.GetData(allSamples, 0);
        float offset = (clip.frequency * clip.channels)/20000;
        Invoke("audioAwake", offset);
        Debug.Log(offset+"\n"+ clip.frequency * clip.channels);
    }
    void audioAwake()
    {
        AudioObject.SetActive(true);
    }
}
