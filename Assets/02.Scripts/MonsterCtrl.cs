using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCtrl : MonoBehaviour
{
    // 열거형 변수(Enumerator)
    // 몬스터의 상태를 정의
    public enum State
    {
        IDLE, TRACE, ATTACK, DIE
    }

    // 몬스터의 상태 변수
    // 접근제한자 변수_데이터_타입 변수명
    public State state;

    // 몬스터의 Transform
    private Transform monsterTr;
    // 주인공의 Transform
    private Transform playerTr;

    // 추적 사정거리
    public float traceDist = 10.0f;
    // 공격 사정거리
    public float attackDist = 2.0f;

    // 몬스터의 사망여부
    public bool isDie = false;

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

    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            // 몬스터와 주인공간의 거리를 계산
            float dist = Vector3.Distance(monsterTr.position, playerTr.position);


            yield return new WaitForSeconds(0.3f);
        }
    }

}
