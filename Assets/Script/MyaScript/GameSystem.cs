using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//スコアランク
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



    //各ランクのスコアボーダー
    public int[] m_rankBorder =
    {
        950000,
        900000,
        850000,
        800000,
        750000,
        700000   
    };
    //リザルトで使用するパラメータ
    public struct ResultPalam
    {
        
        public string MusicTitle;   //ミュージックタイトル

        public int score;           //スコア       
        public ScoreRankType Rank;  //スコアランク
                                    
        public int Perfect;         //Perfectの数        
        public int Great;           //Greatの数
        public int Good;            //Goodの数
        public int Bad;             //Badの数
        public int Miss;            //Missの数

        public int MaxCombo;        //最大コンボ数
        public bool isFullCombo;    //フルコンボしたかどうか
        //public bool isAllPerfect;


    }
    //リザルト変数
    public ResultPalam m_result;
    //コンボ数
    public int Combo = 0;
    //デバッグ用タップ処理
    public void DebugTap()
    {
        //ランダム生成
        int a = Random.Range(0, 20);
        //中身適当だが判定処理が実装できれば書き換えて使うつもり。
        //実際のスコア計算(仮)：１ノーツあたり　(1,000,000/ノーツ数)＊判定指数
        //判定指数:Perfect 1.0,Great 0.9,Good 0.7,Bad 0.5, Miss 0.0
        switch (a)
        {
            case 0:
                m_result.Great++;
                m_result.score += 5000;
                Combo++;
                Debug.Log("Great!");
                //最大コンボ更新！
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
    //リザルト用パラメータを取得
    public ResultPalam GetResultPalam()
    {
        return m_result;
    }
    //シーン
    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    //格付け
    public void SetRank(int score)
    {
        int num = m_rankBorder[1];
        //ランクボーダー/50000で整数範囲switch
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

        //リザルトシーンへGO
       if( Input.GetKeyDown(KeyCode.A))
       {
            SetRank(m_result.score);
            SceneManager.LoadScene("Result");
        }
       //リザルトパラメータをデバッグ表示
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
    //シーンが切り替わっても残り続ける
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
