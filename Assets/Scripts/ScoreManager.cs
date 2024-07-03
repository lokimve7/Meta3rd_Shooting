using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // 나를 담을 변수
    public static ScoreManager instance;

    // 현재 점수
    int currScore;
    public int CurrScore
    {
        get { return currScore; }
        set { AddScore(value); }
    }

    // 현재 점수 UI
    public Text textCurrScore;

    // 최고 점수
    int bestScore;
    public int BestScore
    {
        get { return bestScore; }
        set {
            bestScore = value;
            textBestScore.text = "최고 점수 : " + bestScore;
        }
    }
    // 최고 점수 UI
    public Text textBestScore;


    private void Awake()
    {        
        // 만약에 instance 값이 없다면
        if(instance == null)
        {
            // 나를 instance 변수에 담자.
            instance = this;
        }
        // 그렇지 않으면
        else
        {
            // 나의 게임오브젝트 파괴하자.
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //// 저장되어 있는 최고점수를 bestScore 에 셋팅
        //bestScore = PlayerPrefs.GetInt("BEST_SCORE", 0);
        //// 최고 점수 UI 갱신
        //textBestScore.text = "최고 점수 : " + bestScore;
        BestScore = PlayerPrefs.GetInt("BEST_SCORE", 0);
    }

    void Update()
    {
        
    }

    // 점수 증가시키는 함수
    void AddScore(int addValue)
    {
        // 현재 점수를 addValue 만큼 증시키자.
        currScore += addValue;

        // 현재 점수 UI 를 갱신시키자.
        textCurrScore.text = "현재 점수 : " + currScore;

        // 만약에 현재 점수가 최고 점수를 넘었니?
        if(currScore > bestScore)
        {
            //// 최고 점수를 현재 점수로 셋팅
            //bestScore = currScore;
            //// 최고 점수 UI 를 갱신시키자.
            //textBestScore.text = "최고 점수 : " + bestScore;

            BestScore = currScore;

            // 최고 점수를 저장하자.
            PlayerPrefs.SetInt("BEST_SCORE", bestScore);
        }
        
        //Debug.Log("");
        //Debug.LogWarning("");
        //Debug.LogError("");
    }    
}
