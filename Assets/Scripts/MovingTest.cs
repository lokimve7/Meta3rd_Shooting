using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTest : MonoBehaviour
{

    bool canMove = true;
    float distance = 0;
    void Start()
    {
        
    }

    void Update()
    {
        // 만약에 canMove true 
        if(canMove == true)
        {
            // 오른쪽으로 움직이자.
            transform.Translate(transform.right * 5 * Time.deltaTime, Space.World);

            // 이동한 거리를 누적하자.
            distance += 5 * Time.deltaTime;

            // 만약에 내가 이동한 거리가 5보다 크면
            if (distance > 5)
            {
                // 나의 위치를 5, 0, 0 하자.
                transform.position -= transform.right * (distance - 5);
                // canMove 를 false
                canMove = false;
            }
        }
        


        //// 만약에 나의 위치의 x 값이 5보다 작으면
        //if (transform.position.x < 5)
        //{
        //    // 오른쪽으로 이동하자.
        //    transform.Translate(Vector3.right * 5 * Time.deltaTime);
        //}
        //// 만약에 나의 위치의 x 값이 5보다 커지면
        //if(transform.position.x > 5)
        //{
        //    // 나의 위치를 (5, 0, 0)
        //    transform.position = new Vector3(5, 0, 0);
        //}
    }
}
