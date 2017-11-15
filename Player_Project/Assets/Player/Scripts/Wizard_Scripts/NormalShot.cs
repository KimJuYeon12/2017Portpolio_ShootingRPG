using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Player
{ 
//위자드의 기본공격
public class NormalShot// : FireShot
{
    GameObject NormalBolt;
    GameObject ShotSpawnPoint;

    public NormalShot(GameObject ShotSpawnPoint, GameObject NormalBolt)
    {
        this.NormalBolt = NormalBolt;
        this.ShotSpawnPoint = ShotSpawnPoint;
    }
    public  void Shot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("노말샷");
            MonoBehaviour.Instantiate(NormalBolt, ShotSpawnPoint.transform.position+new Vector3(0,0,1), ShotSpawnPoint.transform.rotation);
        }
    }

}
}