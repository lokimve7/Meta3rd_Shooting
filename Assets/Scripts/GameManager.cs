using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Ready,
    Play,
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState currGameSate;
    float currTime;
    int lastSecond = 0;

    public Text textCountDown;
    
    void Start()
    {
        instance = this;
        textCountDown.gameObject.SetActive(false);
    }

    void Update()
    {
        
        if(currGameSate == GameState.Ready)
        {
            currTime += Time.unscaledDeltaTime;
            if(currTime > 3)
            {
                textCountDown.gameObject.SetActive(true);

                int second = (6 - (int)currTime);

                if(lastSecond != second)
                {
                    lastSecond = second;
                    textCountDown.transform.localScale = Vector3.one * 2f;
                    Hashtable hash = iTween.Hash(
                        "scale", Vector3.one, 
                        "time", 0.5f,
                        "easetype", iTween.EaseType.easeOutBounce);
                    iTween.ScaleTo(textCountDown.gameObject, hash);
                }

                if(second > 0)
                {
                    textCountDown.text = second.ToString();
                }
                else if(second == 0)
                {
                    textCountDown.text = "Start!";
                }
                else
                {
                    currGameSate = GameState.Play;
                    textCountDown.gameObject.SetActive(false);
                }
            }
        }
    }
}
