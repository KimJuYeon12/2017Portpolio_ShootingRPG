using UnityEngine;
using System.Collections;

namespace Player
{ 
//유도샷
public class GuidedShot : ArcherShot    
{
    public GameObject[] TargetArr;
    AnimationCurve GuidedShot_ac;
    Vector3 Setting_Angle;//총구의 위치 초기화
    Vector3 Setting_Position;

    private float Angle = 30f;//총알사이의 각도
    private float Distance = 2;
    private Rigidbody Spawn_rb;
    private int Min_idx;


    public GuidedShot(GameObject Bolt, GameObject Shot_Spawn, GameObject Shot_Spawn_Point, int Shot_Level, AnimationCurve GuidedShot_ac)
    :base(Bolt,Shot_Spawn, Shot_Spawn_Point,Shot_Level)
    {
        this.GuidedShot_ac = GuidedShot_ac;

        //애니메이션 연결
        //처음에 미사일이 생성될 때 자연스레 퍼져서 나오는 듯한 효과 생각

        Setting_Angle.Set(0, -(Angle * (Shot_Level - 1)) / 2,0 );
        Spawn_rb = Shot_Spawn.GetComponent<Rigidbody>();
    }


    public override void Shot(){}


    //처음에 타겟을 계산 하는 부분
    public int Set_Target()
    {
        TargetArr = GameObject.FindGameObjectsWithTag("Enemy");

        float min_Len = Vector3.Distance(Shot_Spawn.transform.position, TargetArr[0].transform.position);
        float new_Len;
        int min_idx = 0;

        for (int i = 1; i < TargetArr.Length; i++)
        {
            new_Len = Vector3.Distance(Shot_Spawn.transform.position,TargetArr[i].transform.position);
            if (new_Len < min_Len)
            {
                min_idx = i;
                min_Len = new_Len;
            }
        }
        return min_idx;
    }





    public GameObject[] Generate_Bolt(int idx)
    {
        Quaternion newRotation = Quaternion.LookRotation((TargetArr[idx].transform.position - Shot_Spawn.transform.position));
        Shot_Spawn.transform.localRotation = newRotation;
        //총구가 타겟을 바라보게 만듬
       

        Shot_Spawn.transform.Rotate(Setting_Angle);
        //바라본상태에서 총구의 각도 설정





        GameObject[] Guided_Bolt = new GameObject[Shot_Level];//생성될 숫자만큼의 유도탄알을 만든다.

        for (int i = 0; i < Shot_Level; i++)
        {
            Guided_Bolt[i] = MonoBehaviour.Instantiate(Bolt, Shot_Spawn_Point.transform.position, Quaternion.Euler(Vector3.zero));// Spawn_rb.rotation);

            Shot_Spawn.transform.Rotate(new Vector3(0, Angle,0 ));
        }


        Shot_Spawn.transform.SetPositionAndRotation(Shot_Spawn.transform.position, Quaternion.Euler(Vector3.zero));
        return Guided_Bolt;
    }






    public IEnumerator GuidedShot_(GameObject Bolt, int idx, GameObject[] BoltArr)
    {

            for (float j = 0.0f; j < 2f; j = j + Time.deltaTime)
            {
            Bolt.transform.position = Vector3.Lerp(Bolt.transform.position, TargetArr[idx].transform.position, 0.1f);
            yield return null;

                if (!Bolt) break;
                 if (Vector3.Distance(Bolt.transform.position, TargetArr[idx].transform.position) < 0.5f)
                {
                break;
                }

            }
    }
}

}