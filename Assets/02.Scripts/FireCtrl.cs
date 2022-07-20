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
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
    }
}
