using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    // 변수선언
    private float v;

    // 변수의 초기화(게임의 초기화 로직), 1회 호출
    void Start()
    {

    }

    // comment : 화면을 렌더링하는 주기마다 호출(랜더링 주기)

    /*
        Vector3 (x, y, z)
        벡터 스터럭처
    */

    void Update()
    {
        v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        Debug.Log(v);

        //transform.position += new Vector3(0, 0, 0.01f);
        transform.Translate(Vector3.forward * v * 0.01f);
    }

    /* 정규화 벡터(Normalized Vector)
        Vector3 -> 구조체(Structure)


        Vector3.forward = new Vector3(0, 0, 1)
        Vector3.up      = new Vector3(0, 1, 0)
        Vector3.right   = new Vector3(1, 0, 0)

        Vector3.one     = new Vector3(1, 1, 1)
        Vector3.zero    = new Vector3(0, 0, 0)
    */
}
