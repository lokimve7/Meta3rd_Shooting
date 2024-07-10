using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // countdown text
    public Text countDown;

    // 현재시간을 담을 변수
    float currTime = 0;

    void Start()
    {
        
    }

    void Update()
    {
        // 1. 시간을 흐르게 하자.
        currTime += Time.deltaTime;
        // 2. 흐른시간을 countDown 에 셋팅하자.
        int second = 4 - (int)currTime;
        countDown.text = second.ToString();        
    }
}
