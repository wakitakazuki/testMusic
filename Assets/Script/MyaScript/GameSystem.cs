using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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



    
    public int[] m_rankBorder =
    {
        950000,
        900000,
        850000,
        800000,
        750000,
        700000   
    };
    
    public struct ResultPalam
    {
        public string MusicTitle;

        public int score;
        public ScoreRankType Rank;
        
        public int Perfect;
        public int Great;
        public int Good;
        public int Bad;
        public int Miss;

        public int MaxCombo;
        public bool isFullCombo;
        //public bool isAllPerfect;


    }
    
    public ResultPalam m_result;
    public int Combo = 0;

    public void DebugTap()
    {
        int a = Random.Range(0, 20);
        
        switch (a)
        {
            case 0:
                m_result.Great++;
                m_result.score += 5000;
                Combo++;
                Debug.Log("Great!");
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
    public ResultPalam GetResultPalam()
    {
        return m_result;
    }
    public void SetRank(int score)
    {
        int num = m_rankBorder[1];
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
       if( Input.GetKeyDown(KeyCode.A))
       {
            SetRank(m_result.score);
            SceneManager.LoadScene("Result");
        }
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
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
