using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    private MeshRenderer renderer;
    // 텍스처를 저장하기 위한 배열
    public Texture[] textures;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponentInChildren<MeshRenderer>();
    }

}
