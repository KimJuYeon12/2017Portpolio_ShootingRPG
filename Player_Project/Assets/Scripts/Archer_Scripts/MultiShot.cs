using UnityEngine;


public class MultiShot : ArcherShot
{
    Vector3 Setting_Angle;//총구의 위치 초기화
    float Angle;//총알사이의 각도


    public MultiShot(GameObject Bolt, GameObject Shot_Spawn, GameObject Shot_Spawn_Point, int Shot_Level) 
    : base(Bolt,Shot_Spawn, Shot_Spawn_Point,Shot_Level)
    {
        Angle = 10f;
        Setting_Angle.Set(0, -(Angle * (Shot_Level - 1)) / 2, 0);
        //각도에 멀티샷의 레벨만큼의 각도를 회전할 것이므로 그것의 반틈만큼 돌려서 초기각을 설정해줘야한다.
    }


    public override void Shot()
    {
        //초기각을 0도로 설정
        Shot_Spawn.transform.rotation = Quaternion.Euler(Vector3.zero);

        //0도를 기준으로 총알이 나가는 총 각도 범위의 반틈만큼 총구를 회전시킨다.
        Shot_Spawn.transform.Rotate(Setting_Angle);

        //루프를 돌면서 총알을 생성
        for (int i = 0; i < Shot_Level; i++)
        {
            //총알을 생성해서 초기 위치를 설정
            MonoBehaviour.Instantiate(Bolt, Shot_Spawn_Point.transform.position, Shot_Spawn.transform.rotation);
            Shot_Spawn.transform.Rotate(new Vector3(0, Angle, 0));

        }
    }

}

