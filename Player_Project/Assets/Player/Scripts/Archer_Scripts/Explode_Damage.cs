using System.Collections;
using UnityEngine;
using System.Collections.Generic;

//폭발트랩샷을 위한 동작 표현
namespace Player
{ 
public class Explode_Damage : MonoBehaviour {

    

    private Rigidbody My_rb;
    private List<Collider> Enemys = new List<Collider>();
    private MoveTest[] Enemy_Move_Scripts; //적에 대한 동작스크립트를 임시로 작성한 부분
    private Rigidbody[] Enemy_rb; //적의 리지드바디 가져오기
    private bool Trigger = false;
    private WaitForSeconds WaitTime = new WaitForSeconds(0.2f);
    private int Power = 500;
    private int Radius = 5;

    public static bool Is_Active;
    //범위에 들어온 적의 갯수를 카운팅 후 리스트에 저장해놓는다.
    private void OnTriggerEnter(Collider other)
    {
        //그 후 몇초정도 기절 후 안죽은 적들은 다시 내려오는 걸로
        //전사의 함성스킬과 많이 흡사함

        if (other.tag != "Enemy") return; //적이 아니라면  그냥 리턴
        if (Enemys.Contains(other)) return;

        if (Enemys.Count == 1) Trigger = true;
        Enemys.Add(other);

    }
    private void Update()
    {
        if (Trigger)
        {
            StartCoroutine(Explode());
            Trigger = false;
        }
    }

    private IEnumerator Explode()
    {
        yield return WaitTime;//콜라이더에서 적이 들어온 갯수를 체킹하는 동안 잠깐 기다리자
        int Cnt = Enemys.Count;//카운팅된 갯수를 가져온다.
        Enemy_Move_Scripts = new MoveTest[Cnt];//가져올 스크립트를 갯수만큼 생성
        Enemy_rb = new Rigidbody[Cnt];//가져올 리지드바디를 갯수만큼 생성

        Collider other;
        for(int i=0;i<Cnt;i++)
        {
            other = Enemys[0];//리스트에서 가져오고
            Enemys.RemoveAt(0);//지워주고

            Enemy_Move_Scripts[i] = other.GetComponent<MoveTest>();//적의 스크립트 가져오기
            Enemy_Move_Scripts[i].Is_Velocity = false;//적의 움직임을 중단시킨다.
            Enemy_rb[i] = other.GetComponent<Rigidbody>();//적 리지드 바디 가져옴
            Enemy_rb[i].AddExplosionForce(Power,transform.position,Radius);

            Enemy_rb[i].velocity = Vector3.zero;//적이 벨로시티 값으로 움직인다면 해당값을 0으로
            StartCoroutine(After_Collider(i));
        }

        gameObject.GetComponent<CanvasGroup>().alpha = 0;
        Destroy(gameObject,2f);

        Is_Active = false;
    }


    private IEnumerator After_Collider(int i)
    {
        yield return new WaitForSeconds(0.5f);//0.5초 동안 올라감
        Enemy_rb[i].velocity = Vector3.zero;
        yield return new WaitForSeconds(1f);//1초기절
        Enemy_rb[i].velocity = -Vector3.forward;//그냥 천천히 내려오게 만듦
    }

}
}