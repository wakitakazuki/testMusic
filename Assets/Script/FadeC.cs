using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeC : MonoBehaviour
{
    //フェードスピード
    public float speed;
    //フェード管理用フラグ
    public bool isFadein = false;
    public bool isFadeout = false;
    public bool isEnd = false;
    private float red, green, blue, alfa;
    Image fadeimage;

    public string nextSceneName;
    private void Start()
    {
        fadeimage = GetComponent<Image>();
        red = fadeimage.color.r;
        green = fadeimage.color.g;
        blue = fadeimage.color.b;
        alfa = fadeimage.color.a;
        if (alfa == 1)
        {
            isFadein = true;
        }
    }

    public void SceneChangeOut(string name)
    {
        isFadeout = true;
        nextSceneName = name;
    }
    public void FadeIn()
    {
        alfa -= speed;
        isEnd = false;
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
            isEnd = true;
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
        if(isEnd)
        {
            GameObject.Find("GameManager").GetComponent<GameSystem>().ChangeScene(nextSceneName);
        }
    }
}
