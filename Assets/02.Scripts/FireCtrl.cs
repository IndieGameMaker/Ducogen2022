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
        Debug.DrawRay(firePos.position, firePos.forward * 10.0f, Color.green);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    RaycastHit hit;

    void Fire()
    {
        // 게임오브젝트 또는 프리팹을 생성하는 메소드
        // Instantiate(생성할객체, 위치, 각도)
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);

        if (Physics.Raycast(firePos.position, firePos.forward, out hit, 10.0f, 1 << 8))
        {
            hit.collider.GetComponent<MonsterCtrl>().OnDamage(hit.point);
        }


        // 총 발사 사운드 실행
        audio.PlayOneShot(fireSfx, 0.8f);
        StartCoroutine(ShowMuzzleFlash());
    }

    // Co-routine
    IEnumerator ShowMuzzleFlash()
    {
        // 텍스처 변경
        Vector2 offset = new Vector2(Random.Range(0, 2) * 0.5f, Random.Range(0, 2) * 0.5f);
        muzzleFlash.material.mainTextureOffset = offset;

        // 회전처리
        float angle = Random.Range(0, 360);
        muzzleFlash.transform.localRotation = Quaternion.Euler(0, 0, angle);
        //Quaternion.Euler(Vector3.forward * angle);

        // Scale 변경
        float scale = Random.Range(1.0f, 2.5f);
        muzzleFlash.transform.localScale = Vector3.one * scale;
        // new Vector3(scale, scale, scale);

        muzzleFlash.enabled = true;

        yield return new WaitForSeconds(0.3f);

        muzzleFlash.enabled = false;
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