using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class MakeBarrior
{
    GameObject barrior;
    GameObject ShotSpawnPoint;
    static int Pivot=0;


    public MakeBarrior(GameObject barrior, GameObject ShotSpawnPoint)
    {
        Pivot++;
        this.barrior = barrior;
        this.ShotSpawnPoint = ShotSpawnPoint;
    }

    public void Shot()
    {
        if(Input.GetButtonDown("Fire1") && Pivot == 1)
        {
            MonoBehaviour.Instantiate(barrior,ShotSpawnPoint.transform.position + new Vector3(0,0,2), ShotSpawnPoint.transform.rotation);
            Pivot++;
        }
    }
}

