using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MakeClone
{
    public GameObject ClonePlayer;
    public GameObject Real;
    static int Pivot =0;


    public MakeClone(GameObject Real ,GameObject ClonePlayer)
    {
        Pivot++;
        this.ClonePlayer = ClonePlayer;
        this.Real = Real;
    }

    public void Shot()
    {   
        if(Input.GetButtonDown("Fire2") && Pivot == 1)
        {
            GameObject clone;
            clone = MonoBehaviour.Instantiate(ClonePlayer, Real.transform.position + new Vector3(1,0,0), Real.transform.rotation);
            clone.transform.SetParent(Real.transform);
        }
    }
    //분신의 갯수는 무조건 하나로 제약
    //만일 분신이 죽어서 다시 소환가능한 상태가 된다면 피벗을 다시 1로 초기화시킨다.
}

