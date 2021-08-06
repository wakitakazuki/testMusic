using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Humen
{
    //Json�t�@�C�����̊�b�f�[�^
    public string name;
    public int maxBlock;
    public int BPM;
    public int offset;
    public Notes[] notes;

}
[Serializable]
public class Notes
{
    //Json�t�@�C�����̃m�[�c�f�[�^
    public int LPB;
    public int num;
    public int block;
    public int type;
    public Notes[] notes;
}

public class InputJson : MonoBehaviour
{
    //[SerializeField] private Transform[] notepoints;
    //[SerializeField] private Longline longline;
    public GameObject notepref;
    public GameObject longnotespref;
    //public GameObject lineOBJ;
    // Start is called before the first frame update
    void Start()
    {
        //Json�t�@�C���̓ǂݏo��
        string inputString = Resources.Load<TextAsset>("NoteJson/test1").ToString();
        Debug.Log(inputString);
        Humen inputJson = JsonUtility.FromJson<Humen>(inputString);
        //longline = lineOBJ.GetComponent<Longline>();

        for (int a = 0; a < inputJson.notes.Length; a++)
        {

            
            //�V���O���m�[�c�̐����y�єz�u
            //Instantiate(notepref, new Vector3(-4 + inputJson.notes[a].block * 2f, 0f, 40 + inputJson.notes[a].num * 60 / inputJson.BPM * 10f), Quaternion.identity);
            notepref.GetComponent<NotesController>().SetTrack((Track)inputJson.notes[a].block + 1);
            GameObject parentlong =Instantiate(notepref, new Vector3(-4 + inputJson.notes[a].block * 2f, 0.5f, 40 + ((inputJson.notes[a].num * 600) / inputJson.BPM)/* * 1.0f*/), Quaternion.identity);
            
            Debug.Log("Num:" + inputJson.notes[a].num + "�@Block:" + inputJson.notes[a].block + "�@A:"+ "NoteType"+inputJson.notes[a].type.ToString()+"   " + a);
            if (inputJson.notes[a].type == 2)
            {
                //�����O�m�[�c�ł���Ή��L�̏��������s �����O�m�[�c�̐擪�̃I�u�W�F�N�g�𐶐�
                parentlong.name = "�����O�m�[�c�擪";
                GameObject longnote = Instantiate(longnotespref, Vector3.zero,Quaternion.identity);
                Notes[] m_note = inputJson.notes[a].notes;
                longnote.GetComponent<test1>().SetPointSize(m_note.Length+1);
                longnote.GetComponent<test1>().SetPoint(0, parentlong.transform);

                for (int i=0; i<m_note.Length;i++)
                {
                    //�擪�ȊO�̃����O�m�[�c�̐���
                    Debug.Log("long"+i);
                   // notepref.transform.parent = Notes.transform;

                    notepref.GetComponent<NotesController>().SetTrack((Track)inputJson.notes[a].block + 1);

                    GameObject notes =Instantiate(notepref, new Vector3(-4 + m_note[i].block * 2f, 0.5f, 40 + ((m_note[i].num * 600) / inputJson.BPM)/* * 1.0f*/), Quaternion.identity);
                    longnote.GetComponent<test1>().SetPoint(i+1,notes.transform);
                    if(i==m_note.Length-1)
                    {
                        notes.name = "�����O�m�[�c�I�[";
                    }
                    else
                    {
                        notes.name = "�����O�m�[�c" + i;
                    }
                    //notepoints[i] = gameobject.transform;

                    //longline.SetupLine(notepoints);
                }

            }

        }




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
