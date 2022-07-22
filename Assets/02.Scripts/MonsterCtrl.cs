using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// NavMeshAgent를 사용하기 위해 네임스페이스 추가
using UnityEngine.AI;

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

        StartCoroutine(CheckMonsterState());
    }

    void Update()
    {

    }

    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            // 몬스터와 주인공간의 거리를 계산
            float dist = Vector3.Distance(monsterTr.position, playerTr.position);

            if (dist <= attackDist)
            {
                state = State.ATTACK;
            }
            else if (dist <= traceDist)
            {
                state = State.TRACE;
            }
            else
            {
                state = State.IDLE;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

}
