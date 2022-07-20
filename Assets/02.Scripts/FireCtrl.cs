using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 게임오브젝트 또는 프리팹을 생성하는 메소드
            // Instantiate(생성할객체, 위치, 각도)
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
    }
}


/* 충돌관련 Call Back Function (Event)
    if IsTrigger = false
    OnCollisionEnter    -> 1
    OnCollisionStay     -> n
    OnCollisionExit     -> 1

    if IsTrigger = true
    OnTriggerEnter
    OnTriggerStay
    OnTriggerExit    

*/