#pragma warning disable CS0108, IDE0051

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCtrl : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePos;

    // AudioSource 컴포넌트를 저장할 변수
    private AudioSource audio;
    // 발생시킬 음원파일을 저장할 변수
    public AudioClip fireSfx;

    public MeshRenderer muzzleFlash;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        // 게임오브젝트 또는 프리팹을 생성하는 메소드
        // Instantiate(생성할객체, 위치, 각도)
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        // 총 발사 사운드 실행
        audio.PlayOneShot(fireSfx, 0.8f);
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