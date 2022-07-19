using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    // 변수의 초기화(게임의 초기화 로직), 1회 호출
    void Start()
    {

    }

    // 화면을 렌더링하는 주기마다 호출(랜더링 주기)
    /*
        Vector3 (x, y, z)
     */
    void Update()
    {
        transform.position += new Vector3(0, 0, 0.01f); //Z값을 0.01f 증가

        //transform.position = transform.position + new Vector3(0, 0, 0.01f);
    }

}
