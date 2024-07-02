using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // 나를 담을 변수
    public static ScoreManager instance;

    // 현재 점수
    public int currScore;

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
        
    }

    void Update()
    {
        
    }

    // 점수 증가시키는 함수
    public void AddScore(int addValue)
    {
        // 현재 점수를 addValue 만큼 증시키자.
        currScore += addValue;

        print("현재 점수 : " + currScore);
        //Debug.Log("");
        //Debug.LogWarning("");
        //Debug.LogError("");
    }
    
}
