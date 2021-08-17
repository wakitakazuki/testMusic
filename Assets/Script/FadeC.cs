using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeC : MonoBehaviour
{
    //�t�F�[�h�X�s�[�h
    public float speed;
    //�t�F�[�h�Ǘ��p�t���O
    public bool isFadein = false;
    public bool isFadeout = false;

    private float red, green, blue, alfa;
    Image fadeimage;
    private void Start()
    {
        fadeimage = GetComponent<Image>();
        red = fadeimage.color.r;
        green = fadeimage.color.g;
        blue = fadeimage.color.b;
        alfa = fadeimage.color.a;
        
    }
    public void FadeIn()
    {
        alfa -= speed;
        setalfa();
        if (alfa <= 0)
        {
            isFadein = false;
            fadeimage.enabled = false;
        }
    }
    public void FadeOut()
    {
        fadeimage.enabled = true;
        alfa += speed;
        setalfa();
        if (alfa >= 1)
        {
            isFadeout = false;
        }
    }
    void setalfa()
    {
        fadeimage.color = new Color(red, green, blue, alfa);
    }
    // Update is called once per frame
    void Update()
    {
        if (isFadein)
        {
            FadeIn();
        }
        if (isFadeout)
        {
            FadeOut();
        }
    }
}
