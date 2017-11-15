using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{ 
public class MateorShot
{
    GameObject player;
    GameObject Mateor;
    public static GameObject Mateor_Clone;
    Mateor A;

    public MateorShot(GameObject player,GameObject Mateor)
    {
        this.player = player;
        this.Mateor = Mateor;
    }

    public void Shot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Mateor.transform.position = new Vector3(Random.Range(-11, 11), 25f, Random.Range(-11, 40));
            //메테오의 스폰위치를 랜덤으로
            Mateor_Clone = MonoBehaviour.Instantiate(Mateor, Mateor.transform.position, Mateor.transform.rotation);

            A = Mateor_Clone.GetComponent<Mateor>();
            A.Player_pos = player.transform.position;
        }
    }
}
}