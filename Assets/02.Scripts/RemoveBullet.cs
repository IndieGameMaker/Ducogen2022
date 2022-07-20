using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    // 충돌이 발생했을 때 한번 호출되는 콜백함수
    void OnCollisionEnter(Collision coll)
    {
        // 충돌한 객체가 Bullet인지 여부를 확인
        //if (coll.gameObject.tag == "BULLET") //GC

        if (coll.gameObject.CompareTag("BULLET"))
        {
            // 총알 삭제
            Destroy(coll.gameObject);
        }
    }
}


/*
    AudioListener   -> 1

    AudioSource     -> n
*/