using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapL : MonoBehaviour
{
    //���胉�C����̃��C�g�̓_���y�я����X�N���v�g
    public float speed = 1.0f;
    private new Renderer renderer;
    private bool Lf = false;

    GameSystem manager;

    GameSystem.ResultPalam testPalam;
    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        
    }

    private void OnEnable()
    {
        Default();
    }

    private void Default()
    {
        //��������
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 1f);
    }

    private void Start()
    {
        if (speed == 0 || speed == null)
        {
            //�����܂ł̑���
            speed = 1;
        }
        manager = GameObject.Find("GameManager").GetComponent<GameSystem>();
    }

    private void Update()
    {
        //�A���t�@�l����
        if (renderer.material.color.a <= 0)
        {
            this.enabled = false;
        }
        else
        {
            if (Lf == false)
            {
                var alfa = renderer.material.color.a - speed * Time.deltaTime;
                renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, alfa);
            }
        }
    }

    public void Tap()
    {
        //�����ꂽ�ۂɌ��点�铮��
        Default();
        this.enabled = true;
        Debug.Log("Tap");
        Lf = true;
        manager.DebugTap();
    }
    public void Exit()
    {
        //����O�ɏo���Ƃ��̏����p�t���O
        Lf = false;
    }
}
