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
    // NavMeshAgent
    private NavMeshAgent agent;
    private Animator anim;

    // 추적 사정거리
    public float traceDist = 10.0f;
    // 공격 사정거리
    public float attackDist = 2.0f;

    // 몬스터의 사망여부
    public bool isDie = false;

    // Animator Parameter의 Hash값을 추출
    private int hashIsAttack = Animator.StringToHash("IsAttack");
    private int hashHit = Animator.StringToHash("Hit");
    private int hashDie = Animator.StringToHash("Die");
    private int hashPlayerDie = Animator.StringToHash("PlayerDie");

    // Monster Health
    private float hp = 100.0f;

    public GameObject bloodEffect;

    // Start is called before the first frame update
    void Start()
    {
        monsterTr = GetComponent<Transform>(); //monsterTr = transform;
        playerTr = GameObject.FindGameObjectWithTag("PLAYER")?.GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        StartCoroutine(CheckMonsterState());
        StartCoroutine(MonsterAction());
    }

    // 몬스터의 상태 변경
    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            if (state == State.DIE) yield break;

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


    // 몬스터 상태에 따라서 행동을 처리
    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            // 몬스터의 상태(state)에 따라서 로직을 분기
            switch (state)
            {
                case State.IDLE:
                    anim.SetBool("IsTrace", false);
                    agent.isStopped = true;
                    break;

                case State.TRACE:
                    anim.SetBool(hashIsAttack, false);
                    anim.SetBool("IsTrace", true);
                    agent.SetDestination(playerTr.position);
                    agent.isStopped = false;
                    break;

                case State.ATTACK:
                    anim.SetBool(hashIsAttack, true);
                    break;

                case State.DIE:
                    isDie = true;
                    anim.SetTrigger(hashDie);
                    agent.isStopped = true;
                    GetComponent<CapsuleCollider>().enabled = false;
                    break;
            }

            yield return new WaitForSeconds(0.3f);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            Destroy(coll.gameObject);



            var blood = Instantiate(bloodEffect,
                                    coll.GetContact(0).point,
                                    Quaternion.identity);
            Destroy(blood, 5.0f);

            anim.SetTrigger(hashHit);

            hp -= 20.0f;  // hp = hp - 20.0f;
            if (hp <= 0.0f)
            {
                state = State.DIE;
            }
        }
    }

    public void YouWin()
    {
        // 모든 코루틴 함수를 정지
        StopAllCoroutines();
        agent.isStopped = true;

        anim.SetFloat("DanceSpeed", Random.Range(0.8f, 1.5f));
        anim.SetTrigger(hashPlayerDie);
    }
}
