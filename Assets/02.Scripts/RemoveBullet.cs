using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;

    // 충돌이 발생했을 때 한번 호출되는 콜백함수
    void OnCollisionEnter(Collision coll)
    {
        // 충돌한 객체가 Bullet인지 여부를 확인
        //if (coll.gameObject.tag == "BULLET") //GC

        if (coll.gameObject.CompareTag("BULLET"))
        {
            // 총알 삭제
            Destroy(coll.gameObject);

            // 충돌 정보
            ContactPoint cp = coll.GetContact(0);
            // 충돌한 접점의 법선벡터 (90도 각도를 이루는 벡터, Normal Vector)
            Vector3 _normal = -cp.normal;
            // 충돌 좌표
            Vector3 _point = cp.point;
            // 벡터를 쿼터니언 타입으로 변환
            Quaternion rot = Quaternion.LookRotation(_normal);

            var spark = Instantiate(sparkEffect, _point, rot);
            Destroy(spark, 0.5f);
        }
    }
}


/*
    Quaternion 쿼터니언 (사원수) : x, y, z, w

    오일러 회전(Euler Rotation) x -> y -> z

    Gimbal Lock (짐벌락, 김벌락)

    Quaternion.Euler(x, y, z)
    Quaternion.LookRotation(벡터)
    Quaternion.identity


    Muzzle Flash
*/