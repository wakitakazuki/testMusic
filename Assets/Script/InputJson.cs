using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Humen
{
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public Notes[] notes;

}
[Serializable]
public class Notes
{
    public int LPB;
    public int num;
    public int block;
    public int type;
    public Notes[] notes;
}

public class InputJson : MonoBehaviour
{
    public GameObject notepref;
    public GameObject Notes;
    // Start is called before the first frame update
    void Start()
    {
        string inputString = Resources.Load<TextAsset>("NoteJson/test1").ToString();
        Debug.Log(inputString);
        Humen inputJson = JsonUtility.FromJson<Humen>(inputString);
        for (int a = 0; a < inputJson.notes.Length; a++)
        {



            //Instantiate(notepref, new Vector3(-4 + inputJson.notes[a].block * 2f, 0f, 40 + inputJson.notes[a].num * 60 / inputJson.BPM * 10f), Quaternion.identity);
            notepref.GetComponent<NotesController>().SetTrack((Track)inputJson.notes[a].block + 1);
            Instantiate(notepref, new Vector3(-4 + inputJson.notes[a].block * 2f, 0.5f, 40 + ((inputJson.notes[a].num * 600) / inputJson.BPM)/* * 1.0f*/), Quaternion.identity);
            Debug.Log("Num:" + inputJson.notes[a].num + "Å@Block:" + inputJson.notes[a].block + "Å@A:"+ "NoteType"+inputJson.notes[a].type.ToString()+"   " + a);
            if (inputJson.notes[a].type == 2)
            {
                Notes[] m_note = inputJson.notes[a].notes;
                for (int i=0; i<m_note.Length;i++)
                {
                    Debug.Log("long"+i);
                   // notepref.transform.parent = Notes.transform;

                    notepref.GetComponent<NotesController>().SetTrack((Track)inputJson.notes[a].block + 1);

                    Instantiate(notepref, new Vector3(-4 + m_note[i].block * 2f, 0.5f, 40 + ((m_note[i].num * 600) / inputJson.BPM)/* * 1.0f*/), Quaternion.identity);

                }

            }

        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
