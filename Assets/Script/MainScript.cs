using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    //���ݎg�p���Ă��Ȃ����쓝���p�X�N���v�g�t�@�C��

    public GameObject linecolor1;
    public GameObject linecolor2;
    public GameObject linecolor3;
    public GameObject linecolor4;
    public GameObject linecolor5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //���݂̓^�b�v�����p���Ă��Ȃ����߁A�L�[�R�[�h���擾�B
        if (Input.GetKeyDown(KeyCode.Q))
        {
            linecolor1.GetComponent<TapL>().Tap();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            linecolor2.GetComponent<TapL>().Tap();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            linecolor3.GetComponent<TapL>().Tap();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            linecolor4.GetComponent<TapL>().Tap();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            linecolor5.GetComponent<TapL>().Tap();
        }
    }

}
