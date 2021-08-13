using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//�X�R�A�����N
public enum ScoreRankType
{
    SSS = 0,
    SS,
    S,
    A,
    B,
    C,
    D,
    TypeNum
}
public class GameSystem : MonoBehaviour
{



    //�e�����N�̃X�R�A�{�[�_�[
    public int[] m_rankBorder =
    {
        950000,
        900000,
        850000,
        800000,
        750000,
        700000   
    };
    //���U���g�Ŏg�p����p�����[�^
    public struct ResultPalam
    {
        
        public string MusicTitle;   //�~���[�W�b�N�^�C�g��

        public int score;           //�X�R�A       
        public ScoreRankType Rank;  //�X�R�A�����N
                                    
        public int Perfect;         //Perfect�̐�        
        public int Great;           //Great�̐�
        public int Good;            //Good�̐�
        public int Bad;             //Bad�̐�
        public int Miss;            //Miss�̐�

        public int MaxCombo;        //�ő�R���{��
        public bool isFullCombo;    //�t���R���{�������ǂ���
        //public bool isAllPerfect;


    }
    //���U���g�ϐ�
    public ResultPalam m_result;
    //�R���{��
    public int Combo = 0;
    //�f�o�b�O�p�^�b�v����
    public void DebugTap()
    {
        //�����_������
        int a = Random.Range(0, 20);
        //���g�K���������菈���������ł���Ώ��������Ďg������B
        //���ۂ̃X�R�A�v�Z(��)�F�P�m�[�c������@(1,000,000/�m�[�c��)������w��
        //����w��:Perfect 1.0,Great 0.9,Good 0.7,Bad 0.5, Miss 0.0
        switch (a)
        {
            case 0:
                m_result.Great++;
                m_result.score += 5000;
                Combo++;
                Debug.Log("Great!");
                //�ő�R���{�X�V�I
                if(m_result.MaxCombo<Combo)
                {
                    m_result.MaxCombo = Combo;
                }
                break;
            case 1:
                m_result.Great++;
                m_result.score += 5000;
                Combo++;
                Debug.Log("Great!");
                if (m_result.MaxCombo < Combo)
                {
                    m_result.MaxCombo = Combo;
                }
                break;
            case 2:
                m_result.Good++;
                Debug.Log("Good");
                Combo = 0;
                break;
            case 3:
                m_result.Bad++;
                Debug.Log("Bad");
                Combo = 0;
                break;
            case 4:
                m_result.Miss++;
                Debug.Log("Miss");
                Combo = 0;
                break;

            default:
                m_result.Perfect++;
                m_result.score += 10000;
                Debug.Log("Perfect!");
                Combo++;
                if (m_result.MaxCombo < Combo)
                {
                    m_result.MaxCombo = Combo;
                }
                break;
        }

    }
    //���U���g�p�p�����[�^���擾
    public ResultPalam GetResultPalam()
    {
        return m_result;
    }
    //�V�[��
    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    //�i�t��
    public void SetRank(int score)
    {
        int num = m_rankBorder[1];
        //�����N�{�[�_�[/50000�Ő����͈�switch
        switch (score/50000)
        {
      
            case 14:
                m_result.Rank = ScoreRankType.C;
                break;
            case 15:
                m_result.Rank = ScoreRankType.B;
                break;
            case 16:
                m_result.Rank = ScoreRankType.A;
                break;
            case 17:
                m_result.Rank = ScoreRankType.S;
                break;
            case 18:
                m_result.Rank = ScoreRankType.SS;
                break;
            case 19:
                m_result.Rank = ScoreRankType.SSS;
                break;
            case 20:
                m_result.Rank = ScoreRankType.SSS;
                break;
            default:
                m_result.Rank = ScoreRankType.D;
                return;
                
        }

       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //���U���g�V�[����GO
       if( Input.GetKeyDown(KeyCode.A))
       {
            SetRank(m_result.score);
            SceneManager.LoadScene("Result");
        }
       //���U���g�p�����[�^���f�o�b�O�\��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Debug.Log("score " + m_result.score +
                "\nRank " +m_result.Rank+
                "\nMaxCombo "+m_result.MaxCombo+
                "\nPerfect "+m_result.Perfect+
                "\nGreat "+m_result.Great+
                "\nGood "+m_result.Good+
                "\nBad "+m_result.Bad+
                "\nMiss "+m_result.Miss);
        }

    }
    //�V�[�����؂�ւ���Ă��c�葱����
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
