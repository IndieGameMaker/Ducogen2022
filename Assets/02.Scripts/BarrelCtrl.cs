#pragma warning disable CS0108, IDE0051
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    private MeshRenderer renderer;
    private AudioSource audio;

    // 텍스처를 저장하기 위한 배열
    public Texture[] textures;

    // 데미지를 누적할 변수 선언
    private int hitCount = 0;

    // 폭발후 발생시킬 폭발이펙트 프리팹
    public GameObject expEffect;
    public AudioClip expSfx;

    void Start()
    {
        renderer = GetComponentInChildren<MeshRenderer>();
        audio = GetComponent<AudioSource>();

        int idx = Random.Range(0, textures.Length); // (0, 3) 0,1,2

        renderer.material.mainTexture = textures[idx];

        /*
            Random.Range(0, 10) -> 0 ~ 9
            Random.Range(0.0f, 10.0f) -> 0.0f ~ 10.0f
        */

    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            if (++hitCount == 3)
            {
                ExpBarrel();
            }
        }
    }

    void ExpBarrel()
    {
        var rb = this.gameObject.AddComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 1500.0f);

        var effect = Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(effect, 6.0f);
        Destroy(this.gameObject, 2.5f);

        audio.PlayOneShot(expSfx, 0.9f);
    }
}
