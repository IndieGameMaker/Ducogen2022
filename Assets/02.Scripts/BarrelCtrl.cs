using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    private MeshRenderer renderer;
    // 텍스처를 저장하기 위한 배열
    public Texture[] textures;

    void Start()
    {
        renderer = GetComponentInChildren<MeshRenderer>();
        int idx = Random.Range(0, textures.Length); // (0, 3) 0,1,2

        renderer.material.mainTexture = textures[idx];

        /*
            Random.Range(0, 10) -> 0 ~ 9
            Random.Range(0.0f, 10.0f) -> 0.0f ~ 10.0f
        */

    }

}
