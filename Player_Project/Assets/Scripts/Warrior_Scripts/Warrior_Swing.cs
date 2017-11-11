using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//워리어 스윙이라는 추상클레스를 만들었고 궁수클레스처럼 만들어 쓸 예정임
public abstract class Warrior_Swing
{
    public GameObject Swing_Core;
    public GameObject Swing_Core_Point;
    public int Swing_Level;
    public GameObject Sword;


    public Warrior_Swing() { }
    public Warrior_Swing(GameObject Swing_Core, GameObject Swing_Core_Point,int Swing_Level,GameObject Sword)
    {
        this.Swing_Core = Swing_Core;
        this.Swing_Core_Point = Swing_Core_Point;
        this.Swing_Level = Swing_Level;
        this.Sword = Sword;

        Swing_Core.transform.SetPositionAndRotation(Swing_Core.transform.position, Quaternion.Euler(0, 0, 0));
    }


    public abstract void Swing();




    public static Vector3 DegreeToRadian(float degree)
    {
        float radian = degree * Mathf.Deg2Rad;
        Vector3 Position = Vector3.zero;
        Position.x = Mathf.Sin(radian);
        Position.y = Mathf.Cos(radian);
        Position.z = Mathf.Tan(radian);
        Position.Normalize();

        return Position;

    }
}

