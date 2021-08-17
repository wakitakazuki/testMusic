using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class MusicSelect : MonoBehaviour
{
    public string[] names;
    public GameObject listItemPre;
    public List<GameObject> m_nameList;
    public GameObject canvasOBJ;
    private Vector3 pos;

    public void EraceList()
    {
        foreach(GameObject obj in m_nameList)
        {
            Destroy(obj);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.dataPath + "/Resources/NoteJson/";
             names = Directory.GetFiles(@path, "*.json",SearchOption.TopDirectoryOnly);
        
        Debug.Log(names[0]);
        

        foreach (string name in names)
        {
 
        }

        for(int i =0;i<names.Length;i++)
        {
            pos.Set(-150, -40, 600);

            if (i == 1)
            {
                pos.y -= 150.0f;
            }
            else if(i ==names.Length-1)
            {
                pos.y += 150.0f;
            }
            names[i] = Path.GetFileNameWithoutExtension(names[i]);
            GameObject m_obj = Instantiate(listItemPre,pos,Quaternion.identity);
            m_obj.transform.parent = canvasOBJ.transform;
            m_nameList.Add(m_obj);
            m_nameList[i].transform.Find("Text").GetComponent<Text>().text = names[i];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            EraceList();
        }
    }
}
