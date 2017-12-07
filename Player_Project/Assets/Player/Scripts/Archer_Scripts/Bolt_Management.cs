using UnityEngine;


namespace Player
{ 
//탄알의 속도를 조절해주고 탄알이 콜라이더에 부딪혔을 때 탄알의 제거를 판단
public class Bolt_Management : MonoBehaviour {

    private Rigidbody rb;
    private int speed;

        public GameObject Bolt_Particle;
    public string Bolt_attribute;

    void Awake()
    {   
        rb = GetComponent<Rigidbody>();
        speed = 5;
        Bolt_attribute = "Nomal";
    }
    
    // Use this for initialization
	void Start () {

            //기본적으로 4초가 지나면 자동적으로 탄알을 제거한다.
            Destroy(gameObject, 2f);

            //탄알의 기본속도를 지정
            rb.velocity = rb.transform.forward * speed;   
    }
	
    void OnTriggerEnter(Collider other)
    {
            if (other.tag == "PlayerBolt" || other.tag == "Player" || other.tag == "Outer") return;

            //Debug.Log("Tag = "+other.tag);
            Destroy(Instantiate(Bolt_Particle, transform.position,Quaternion.identity),1f);
            //Instantiate(Bolt_Particle).transform.position = transform.position;
            
            //태그가 타겟이고 유도샷이었을 경우 이곳에 진입
            if (other.tag == "Enemy" && Bolt_attribute == "Guided")
        {
                
                gameObject.SetActive(false);
                Destroy(gameObject, 0.1f);
            //가이드샷의 Lerp메소드가 볼트가 소멸후에도 볼트에 접근을 지속적으로 함 -> 지워진 오브젝트에 지속적으로 접근을 해서 널익셉션이 뜸
            //해결: 바로 지우지않고 게임상에서만 보이지않으면 되므로 비활성화 시킨 후 1초후에 게임오브젝트를 제거함
        }


        //일반적인 총알이 발사되었고 적이 일반탄에 맞았을 경우의 처리
        else if (other.tag != "Player"  && other.tag != "PlayerBolt" && Bolt_attribute == "Nomal" && other.tag != "EnemyBolt")
        {
                Destroy(gameObject);
        }

   }
}
}