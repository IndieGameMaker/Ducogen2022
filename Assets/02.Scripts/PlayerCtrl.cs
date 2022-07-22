using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    // Private 변수선언
    private float v;
    private float h;
    private float r;

    // Public 변수선언
    public float moveSpeed = 8.0f;
    public float turnSpeed = 50.0f;

    // Player Health 변수
    private float initHp = 100.0f;
    private float currHp = 100.0f;

    // 접근할 컴포넌트를 저장할 변수를 선언
    public Animation anim;

    /*
        프로퍼티(속성)
        Car.speed = 200;
        Car.color = yellow;
        Car.capacity = 4;

        메소드(함수) - 명령(동사)
        anim.Play(인자);
        Input.GetAxis(인자);

        Camel Case (단봉 낙타)
        moveSpeed
        변수, 속성

        Pascal Case
        MoveSpeed
        클래스, 스트럭처(구조체), 메소드(함수)
    */


    // 변수의 초기화(게임의 초기화 로직), 1회 호출
    IEnumerator Start()
    {
        turnSpeed = 0.0f;
        anim = this.gameObject.GetComponent<Animation>();
        anim.Play("Idle");

        yield return new WaitForSeconds(0.3f);

        turnSpeed = 800.0f;
    }

    void Update()
    {
        v = Input.GetAxis("Vertical");   // -1.0f ~ 0.0f ~ +1.0f
        h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        r = Input.GetAxis("Mouse X");

        // 벡터의 덧셈연산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        // 이동처리
        transform.Translate(moveDir.normalized * Time.deltaTime * moveSpeed);
        // 회전처리
        transform.Rotate(Vector3.up * Time.deltaTime * r * turnSpeed);

        PlayerAnimation();
    }

    void PlayerAnimation()
    {
        // 전진
        if (v >= 0.1f)
        {
            anim.CrossFade("RunF");
        }
        else if (v <= -0.1f)    // 후진
        {
            anim.CrossFade("RunB");
        }
        else if (h >= 0.1f) //오른쪽
        {
            anim.CrossFade("RunR");
        }
        else if (h <= -0.1f) //왼쪽
        {
            anim.CrossFade("RunL");
        }
        else
        {
            anim.CrossFade("Idle");
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("PUNCH"))
        {
            Debug.Log(coll.gameObject);
        }
    }
}
