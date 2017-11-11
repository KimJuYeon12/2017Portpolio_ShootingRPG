using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;


public class WheelWind_Swing : Warrior_Swing
{
    public int WheelWind_Lev;

    Vector3 Start_Swing_Angle;
    Vector3 End_Swing_Angle;

    public WheelWind_Swing(GameObject Swing_Core, GameObject Swing_Core_Point, int Swing_Level, GameObject Sword)
    :base(Swing_Core,Swing_Core_Point,Swing_Level, Sword)
    {
        WheelWind_Lev = Swing_Level;

        Start_Swing_Angle.Set(0, 0, 0);
        End_Swing_Angle.Set(0, 360, 0);
    }

    public override void Swing() { }



    public IEnumerator Swing_()
    {
        
        GameObject Real_Sword =
            MonoBehaviour.Instantiate(Sword, Swing_Core_Point.transform.position, Sword.transform.rotation);
        Real_Sword.transform.SetParent(Swing_Core_Point.transform);

        for (float angle = -360*4; angle < 360*4; angle = angle + 50f)
        {
            Swing_Core.transform.localRotation = Quaternion.Euler(0, angle, 0);
            yield return null;
        }
        Swing_Core.transform.SetPositionAndRotation(Swing_Core.transform.position, Quaternion.Euler(0,0,0));
        MonoBehaviour.Destroy(Real_Sword);
    }
}

