using UnityEngine;


//기본적인 궁수의 공격을 위한 추상클레스
public abstract class ArcherShot
{
    public GameObject Bolt;//탄알 가져오기
    public GameObject Shot_Spawn;//총대
    public GameObject Shot_Spawn_Point;//총구
    public int Shot_Level;//스킬업을 통해 올린 레벨


    public ArcherShot(){}

    public ArcherShot(GameObject Bolt, GameObject Shot_Spawn, GameObject Shot_Spawn_Point,int Shot_Level)
    {
        this.Shot_Spawn_Point = Shot_Spawn_Point;
        this.Bolt = Bolt;
        this.Shot_Spawn = Shot_Spawn;
        this.Shot_Level = Shot_Level;
    }

    public abstract void Shot();
}
