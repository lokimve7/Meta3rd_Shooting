using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 나를 담을 수 있는 static 변수
    public static GameManager instance;

    // countdown text
    public Text countDown;

    // 현재시간을 담을 변수
    float currTime = 0;

    // 현재 게임이 시작 되었는지
    public bool isPlaying = false;

    private void Awake()
    {
        // 만약에 instance 에 값이 없다면
        if (instance == null)
        {
            // instance 에 값을 셋팅
            instance = this;
        }
        // 그렇지 않다면
        else
        {
            // 나의 게임오브젝트를 파괴하자.
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        CountDown();
    }

    void CountDown()
    {
        // 게임중이라면 함수를 나가자.
        if (isPlaying) return;

        // 1. 시간을 흐르게 하자.
        currTime += Time.deltaTime;
        // 2. 흐른시간을 countDown 에 셋팅하자.
        int second = (int)(4 - currTime);

        // 만약에 second 가 0보다 크다면
        if (second > 0)
        {
            // second 값을 보여주자.
            countDown.text = second.ToString();
        }
        // 그렇지 않고 second 가 0 이라면
        else if (second == 0)
        {
            // Start 를 보여주자.
            countDown.text = "Start!!";
        }
        // 그렇지 않으면 ( 0보다 작을 때)
        else
        {
            //countDown 을 비활성화 하자.
            countDown.gameObject.SetActive(false);
            //countDown.enabled = false;
            //게임 중으로 설정하자.
            isPlaying = true;
        }
    }
}
