using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{ 
    public class Archer_Attack_Management : MonoBehaviour {

        public GameObject GuidedBolt;
        public GameObject Bolt;
        public GameObject Shot_Spawn;
        public static GameObject Shot_Spawn_Point;
        ///////////////////////////////////////////////////////////////////

        MultiShot Mul;
        public int MultiShot_Lev;
        ///////////////////////////////////////////////////////////////////



        GuidedShot Guided;
        public int GuidedShot_Lev;
        public AnimationCurve GuidedShot_ac;
        public GameObject Guided_Enemy;
        /// ///////////////////////////////////////////////////////////////////


        Layzer_Trap_Shot Lazer_Shot;
        public GameObject Lazer;
        public int LazerShot_Lev;

        /// ////////////////////////////////////////////////////////////////

        Explode_Trap_Shot Explode_Shot;
        public GameObject Explode;
        public int Explode_Lev;


    
        void Awake()
        {
            Shot_Spawn_Point = gameObject;
            GuidedShot_Lev = 1;
            //MultiShot_Lev = 1;//우선 임의의 값을 넣음
            LazerShot_Lev = 3;
            Explode_Lev = 1;


            Mul = new MultiShot(Bolt,Shot_Spawn,gameObject,MultiShot_Lev);
            Guided = new GuidedShot(GuidedBolt, Shot_Spawn, gameObject, GuidedShot_Lev, GuidedShot_ac);
            Lazer_Shot = new Layzer_Trap_Shot(Bolt, Shot_Spawn, gameObject, LazerShot_Lev,Lazer);
            Explode_Shot = new Explode_Trap_Shot(Bolt, Shot_Spawn, gameObject, LazerShot_Lev,Explode);

        }
        // Update is called once per frame
        void Start()
        {
            StartCoroutine(Test());
        }
        IEnumerator Test()
        {
            while(true)
            {

                //List<Transform> TargetArr = Guided.Make_TargetArr();
                //int idx = Guided.Set_Target(TargetArr);

                ////탄알을 생성
                //GameObject[] Bolt = new GameObject[GuidedShot_Lev];
                //Bolt = Guided.Generate_Bolt(idx, TargetArr);


                ////생성된 탄알의 갯수만큼 루프를 돌면서 탄알을 발사한다.
                //for (int i = 0; i < GuidedShot_Lev; i++)
                //{
                //    Bolt_Management Attribute = Bolt[i].GetComponent<Bolt_Management>();
                //    Attribute.Bolt_attribute = "Guided";
                //    StartCoroutine(Guided.GuidedShot_(Bolt[i], idx, TargetArr));
                //}


                Mul.Shot();
                yield return new WaitForSeconds(Time.deltaTime*0.1f);
            }
        }
        void FixedUpdate () 
        {
            //Guided_Shot();
            
        }



        void Explode_Shot_()
        {
            if (Input.GetButtonDown("Fire1") && Explode_Damage.Is_Active == false)
            {
                Explode_Damage.Is_Active = true;
                Explode_Shot.Shot();
            }
        }



        void Lazer_Shot_()
        {
            if (Input.GetButtonDown("Fire1") && Lazer_Shot.Is_Lazer == false)
            {
                StartCoroutine(Lazer_Shot.Set_Lazer());
            }
        }


        void Mul_Shot()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("aaaaa");
                Mul.Shot();
            }
        }




        //지금 하고있는 작엄 : 최대한 OPP의 컨셉에 맞춰서 코드 정리하기
        //유도샷은 코루틴을 사용
        //코루틴이 돌기전에 사전에 세팅되어야 할 부분들이 있기 때문에 유도샷의 구현클레스 내부에
        //코루틴을 제외한 나머지 부분을 모두 넣을 수 없었다.
        void Guided_Shot()
        {
        
            if (Input.GetButtonDown("Fire1"))
            {
                ////타겟을 설정하고 해당타겟의 인덱스를 받아옴
                ////인덱스를 가이드 클레스 내부에 만들어버리면 플레이어가 움직일 때 이미 발사된
                ////탄알도 같이 움직여져버리므로 밖에서 따로 선언 후 받아와서 아래에서 사용한다.
                //int idx = Guided.Set_Target();

                ////탄알을 생성
                //GameObject[] Bolt = new GameObject[GuidedShot_Lev];
                //Bolt = Guided.Generate_Bolt(idx);


                ////생성된 탄알의 갯수만큼 루프를 돌면서 탄알을 발사한다.
                //for (int i = 0; i < GuidedShot_Lev; i++)
                //{
                //    Bolt_Management Attribute = Bolt[i].GetComponent<Bolt_Management>();
                //    Attribute.Bolt_attribute = "Guided";
                //    StartCoroutine(Guided.GuidedShot_(Bolt[i], idx, Bolt));
                //}
            }
        }
    }
}
