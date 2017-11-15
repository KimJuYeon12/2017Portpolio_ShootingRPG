using System.Collections;
using UnityEngine;

namespace Player
{ 

//점프해서 위로 올라가면서 데미지를 준다.(슈퍼아머 발동)
public class Jump_Attack
{
    Rigidbody Warrior_rb;//점프를 하기위해서 리지드바디 가져옴
    int level;//점프레벨
    private Health WarriorHP;//플레이어의 체력스크립트를 가져옴

    //슈퍼아머 동작시간
    private WaitForSeconds SuperAmmorTime = new WaitForSeconds(2f);


    public Jump_Attack(GameObject Warrior,int level)
    {
        Warrior_rb = Warrior.GetComponent<Rigidbody>();
        WarriorHP = Warrior.GetComponent<Health>();

    }
    
    public IEnumerator Shot()
    {
        //슈퍼아머 발동시키기
        float OrginDamage = WarriorHP.EnemyCollaspedDamage;
        WarriorHP.EnemyCollaspedDamage = 0;
     
        //위로 힘주기
        Warrior_rb.AddForce(new Vector3(0,0,800));

        yield return SuperAmmorTime;//슈퍼아머타임동안 슈퍼아머상태 유지

        //슈퍼아머해제
        WarriorHP.EnemyCollaspedDamage = OrginDamage;
    }

}

}