using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Result : MonoBehaviour
{

    public enum ResultPalam
    { 
        score,
        Perfect,
        Great,
        Good,
        Bad,
        Miss,
        MaxCombo,
        Rank
    }
    public ScoreRankType m_rank;
    public ResultPalam m_resultPalam;
    private GameSystem gameSystem;
    // Start is called before the first frame update
    void Start()
    {
        gameSystem = GameObject.Find("GameManager").GetComponent<GameSystem>();

        switch (m_resultPalam)
        {
            case ResultPalam.score:
                GetComponent<Text>().text = gameSystem.GetResultPalam().score.ToString();

                break;
            case ResultPalam.Perfect:
                GetComponent<Text>().text = gameSystem.GetResultPalam().Perfect.ToString();

                break;
            case ResultPalam.Great:
                GetComponent<Text>().text = gameSystem.GetResultPalam().Great.ToString();

                break;
            case ResultPalam.Good:
                GetComponent<Text>().text = gameSystem.GetResultPalam().Good.ToString();

                break;
            case ResultPalam.Bad:
                GetComponent<Text>().text = gameSystem.GetResultPalam().Bad.ToString();

                break;
            case ResultPalam.Miss:
                GetComponent<Text>().text = gameSystem.GetResultPalam().Miss.ToString();

                break;
            case ResultPalam.MaxCombo:
                GetComponent<Text>().text = gameSystem.GetResultPalam().MaxCombo.ToString();

                break;
            case ResultPalam.Rank:
                if (gameSystem.GetResultPalam().Rank == m_rank)
                {
                    GetComponent<SpriteRenderer>().enabled = true;
                }
                break;
        }

        // Update is called once per frame
        void Update()
    {
        
    }

    }
}