using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    // 몬스터의 Transform
    private Transform monsterTr;
    // 주인공의 Transform
    private Transform playerTr;

    // Start is called before the first frame update
    void Start()
    {
        monsterTr = GetComponent<Transform>(); //monsterTr = transform;
        playerTr = GameObject.FindGameObjectWithTag("PLAYER")?.GetComponent<Transform>();

        // GameObject playerObject = GameObject.FindGameObjectWithTag("PLAYER");
        // if (playerObject != null)
        // {
        //     playerTr = playerObject.GetComponent<Transform>();
        // }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
