using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

public class Normal_Swing : Warrior_Swing
{
    Vector3 Start_Swing_Angle;
    Vector3 End_Swing_Angle;


    public int Normal_Lev;
    public Normal_Swing(GameObject Swing_Core, GameObject Swing_Core_Point, int Swing_Level,GameObject Sword)
    :base(Swing_Core,Swing_Core_Point,Swing_Level, Sword)
    {
        Normal_Lev = Swing_Level;

        Start_Swing_Angle.Set(0,30,0);
        End_Swing_Angle.Set(0, 60, 0);
    }


    public override void Swing(){}



    public IEnumerator Swing_()
    {
        GameObject Real_Sword = MonoBehaviour.Instantiate(Sword, Swing_Core_Point.transform.position, Sword.transform.rotation);
        Real_Sword.transform.SetParent(Swing_Core_Point.transform);

        Debug.Log("Real_Sword Rotation = " + Real_Sword.transform.rotation);

        for (float angle = -100; angle < 100; angle = angle + 30f)
        {
            Swing_Core.transform.localRotation = Quaternion.Euler(0,angle,0);
            yield return null;
        }
        Swing_Core.transform.SetPositionAndRotation(Swing_Core.transform.position, Quaternion.Euler(0, 0, 0));
        MonoBehaviour.Destroy(Real_Sword);
    }
}

