using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Audioset : MonoBehaviour
{
    //オーディオのオフセット用
    public GameObject AudioObject;
    AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        //オーディオにセットされた曲データの回収
        clip = AudioObject.GetComponent<AudioSource>().clip;
        startaudio();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //オフセットの時間及びオフセット起動用
    void startaudio()
    {
        float[] allSamples = new float[clip.samples * clip.channels];
        clip.GetData(allSamples, 0);
        float offset = (clip.frequency * clip.channels)/20000;
        Invoke("audioAwake", offset);
        Debug.Log(offset+"\n"+ clip.frequency * clip.channels);
    }
    //オーディオのオブジェクトをアクティブ化
    void audioAwake()
    {
        AudioObject.SetActive(true);
    }
}
