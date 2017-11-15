using System.Collections;
using UnityEngine;

namespace Player
{ 
public class Layzer_Trap_Shot : ArcherShot
{
    //양쪽벽에 트랩을 설치해서 범위에 들어오는 적들에게 일정 데미지를 준다.

    private GameObject Lazer;
    private int MaxLength = 100;
    private int speed = 100;
    private WaitForSeconds UntileTime;


    public bool Is_Lazer = false;

    public override void Shot(){ }

    public Layzer_Trap_Shot(GameObject Bolt, GameObject Shot_Spawn, GameObject Shot_Spawn_Point, int Shot_Level,GameObject Lazer)
    :base(Bolt,Shot_Spawn,Shot_Spawn_Point,Shot_Level)
    {
        this.Lazer = Lazer;
        UntileTime = new WaitForSeconds(Shot_Level * 5);
    }



    public IEnumerator Set_Lazer()
    {
        //레이져를 시작
        Is_Lazer = true;  

        //복제품을 생성
        GameObject Lazer_Clone = MonoBehaviour.Instantiate(Lazer, Shot_Spawn_Point.transform.position+new Vector3(0,0,2), Shot_Spawn_Point.transform.rotation);

        //레이저복제품의 길이를 확장시켜나간다.
        for (float i= 0; i< MaxLength; i = i + Time.deltaTime* speed)
        {
            Lazer_Clone.transform.localScale = new Vector3(i, Lazer.transform.localScale.y, Lazer.transform.localScale.z);
            yield return null;
        }

        //레이저가 지속되는 시간
        yield return UntileTime;

        //레이저를 종료
        for (float i = MaxLength; i > 0f; i = i - Time.deltaTime * speed/2)
        {
            Lazer_Clone.transform.localScale = new Vector3(i, Lazer.transform.localScale.y, Lazer.transform.localScale.z);

            //깜빡깜빡
            Lazer_Clone.SetActive(false);
            yield return null;
            Lazer_Clone.SetActive(true);
            yield return null;
        }
        MonoBehaviour.Destroy(Lazer_Clone);
        Is_Lazer = false;
    }




}
}