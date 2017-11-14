using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab_Swing : MonoBehaviour
{

    public static Rigidbody Enemy_rb;
    private Collider Enemy;
    private float Power;

    private SphereCollider col;
    private float Alpha = 0;
    private MoveTest Enemy_Move_Scripts;

    private bool Is_Start = false;
    private float Start_RotatePow = 5;
    private float Max_RotatePow = 10;
    private Health WarriorHP;


    //현재문제는 콜라이더에 하나 이상의 오브젝트가 같이 끌려들어와서 
    //원래 돌아야할 오브젝트와 같이 돌아버리는 것.
    //따라서 애초에 콜라이더에서 하나만을 받게 만들어야한다.

    private void Awake()
    {
        //콜라이더 및 체력스크립트 캐싱
        col = GetComponent<SphereCollider>();
        WarriorHP = transform.parent.GetComponent<Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //콜라이더에 들어온 것이 에너미가 아니거나 이미 그랩을 시작한 상태라면 걍 리턴시킨다.
        if (other.tag != "Enemy") return;

        //에너미인경우 잡고 돌리기전의 선처리
        Prepare(other);
    }

    private void Prepare(Collider other)
    {
        Is_Start = true;//시작상태로 변경

        Enemy = other;//콜라이더에 들어온 것을 에너미로 지정

        Enemy_rb = other.GetComponent<Rigidbody>();//집어온 것의 리지드바디 가져오기

        ////임시적인 에너미의 움직임스크립트 가져오기
        //Enemy_Move_Scripts = other.GetComponent<MoveTest>();

        ////만일 에너미에 에너미 무브스크립트가 없었다면 여기서 거름
        //if (Enemy_Move_Scripts == null) return;

        ////잡힌 에너미의 속도 없애기
        //Enemy_Move_Scripts.Is_Velocity = false;
        Enemy_rb.velocity = Vector3.zero;

        foreach (var v in other.GetComponents<MonoBehaviour>())
        {
            v.StopAllCoroutines();
        }



        //자식으로 달기
        Enemy_rb.transform.SetParent(transform);
    }

    private Grab_Swing()
    {
        Power = 1f;
    }

    private void AddForce()//누르고있는 동안 힘을 누적시킴
    {
        if (Power >= 20f) return;
        Power = Power + Time.deltaTime * 10;
    }
    private void DoRotate()//돌리기
    {
        transform.Rotate(0, Start_RotatePow + Alpha, 0);
        Alpha = Alpha + Time.deltaTime * 10;
        if (Alpha > Max_RotatePow) Alpha = Max_RotatePow;
    }

    public void Fire()
    {
        if (Input.GetButtonDown("Fire2") && !Is_Start)//처음 버튼을 눌렀을 시
        {
            //콜라이더를 킨다.
            col.enabled = true;
            return;
        }

        if (Input.GetButton("Fire2"))//계속누르고있는 상태
        {
            if (Enemy_rb == null) return;//만일 강체가 없었다면 리턴

            WarriorHP.EnemyCollaspedDamage = 0;//슈퍼아머 발동

            AddForce();//누르고있는만큼 힘을 누적시킨다.

            DoRotate();//회전시킨다.

            //끌어당긴다.
            Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, new Vector3(0, 1, 0), Time.deltaTime * 2);
            //돌리고있는 중에는 부딪히고있는 상태이므로 무적화시킨다.
            return;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            col.enabled = false; //콜라이더 해제

            if (Enemy_rb == null) return; //강체가 없었을 경우 리턴

            Enemy_rb.AddForce(new Vector3(0, 0, Power), ForceMode.Impulse);//파워만큼 날린다.

            Enemy_rb.transform.SetParent(null);//부모에서 제거함으로써 날아갈때 부모의 영향을 안받게한다.

            Enemy_rb = null;//추가적으로 물리적인 작용을 못하게 만듬, 안하면 눌렀을 때 계속 힘받음

            Is_Start = false;

            WarriorHP.EnemyCollaspedDamage = 30;//슈퍼아머해제
        }
    }

}


