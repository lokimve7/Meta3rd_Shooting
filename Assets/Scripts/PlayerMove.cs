using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

// 주석: Ctrl 누른상태로 K->C
// 주석 풀기 : Ctrl 누른상태로 K -> U
// 코드 정렬 : Ctrl 누른상태로 K -> F

/*
 사용자의 입력을 받아서 이동방향을 정하고
그 방향으로 움직이고 싶다.
 */


public class PlayerMove : MonoBehaviour
{
    // 이동 속력
    public float moveSpeed = 5;
    // 회전 속력
    public float rotSpeed = 10;

    void Start()
    {
        HP hp = GetComponent<HP>();
        hp.OnDie = OnDie;
    }

    void Update()
    {
        if (!(GameManager.instance.currGameSate == GameState.Play)) return;
        #region 회전 시켜서 나의 윗방향으로 움직이기
        //// a, d 키 입력을 받아서 회전 하자.
        //float h = Input.GetAxis("Horizontal");

        //// h 값을 가지고 회전
        //transform.Rotate(0, 0, -h * rotSpeed * Time.deltaTime);

        //// 만약에 w 를 누르면 
        //if(Input.GetKey(KeyCode.W))
        //{
        //    // 너의 up 방향으로 움직이고 싶다.
        //    transform.position += transform.up * moveSpeed * Time.deltaTime;
        //}



        #endregion

        #region  키보드 입력 방향으로 움직이기
        //1.사용자의 입력을 받자(w, a, s, d)
        // a : -1, d : 1, 누르지 않으면 : 0
        float h = Input.GetAxis("Horizontal");
        // w : 1, s : -1, 누르지 않으면 : 0
        float v = Input.GetAxis("Vertical");

        //2.입력 받을 값을 이용해서 이동방향을 정하자.
        Vector3 dirH = Vector3.right * h;
        Vector3 dirV = Vector3.up * v;
        Vector3 dir = dirH + dirV;

        // dir 의 크기를 1로 만들자.
        dir.Normalize();

        //3.구해진 이동방향으로 움직이자. (속력 5)
        //transform.Translate(dir * moveSpeed * Time.deltaTime);
        // 이동 공식 (P = P0 + vt)
        //transform.position = transform.position + dir * moveSpeed * Time.deltaTime;
        Vector3 pos = transform.position;
        pos += dir * moveSpeed * Time.deltaTime;

        // 1. 오른쪽으로 이동하고싶다.
        // transform.Translate(Vector3.right * 5 * Time.deltaTime); 
        #endregion

        Vector3 leftBottom = pos + new Vector3(-0.5f, -0.5f);
        leftBottom = Camera.main.WorldToViewportPoint(leftBottom);
        Vector3 rightTop = pos + new Vector3(0.5f, 0.5f);
        rightTop = Camera.main.WorldToViewportPoint(rightTop);

        if(leftBottom.x < 0 || rightTop.x > 1)
        {
            dir.x = 0;
        }
        if(leftBottom.y < 0 || rightTop.y > 1)
        {
            dir.y = 0;
        }
        dir.Normalize();
        transform.position += dir * moveSpeed * Time.deltaTime;        
    }
 
    // 게임오브젝트가 파괴될 때 호출되는 함수
    private void OnDestroy()
    {
        // 게임오버 화면으로 전환
    }

    void OnDie()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
