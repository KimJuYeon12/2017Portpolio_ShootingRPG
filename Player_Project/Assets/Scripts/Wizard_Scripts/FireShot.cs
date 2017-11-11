using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

public class FireShot
{
  public  GameObject ShotSpawnPoint;
  public  GameObject FireBolt;

    public FireShot() { }
    public FireShot(GameObject ShotSpawnPoint, GameObject FireBolt)
    {
        this.ShotSpawnPoint = ShotSpawnPoint;
        this.FireBolt = FireBolt;
    }


    public void Shot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("들어옴");
            MonoBehaviour.Instantiate(FireBolt, ShotSpawnPoint.transform.position, ShotSpawnPoint.transform.rotation);
        }
    }


}

