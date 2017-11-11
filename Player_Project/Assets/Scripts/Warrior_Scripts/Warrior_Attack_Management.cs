using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior_Attack_Management : MonoBehaviour
{
    public GameObject Swing_Core;//휘두르는 곳의 중심점
    public GameObject Sword;
    /////////////////////////////////////////////////////


    public Normal_Swing Normal;
    public int Normal_Level;
    /////////////////////////////////////////////////////



    public WheelWind_Swing WheelWind;
    public int WheelWind_Level;
    /////////////////////////////////////////////////////


    public GameObject Grab_Swing_gameObject;
    Grab_Swing Grab;
    public int Grab_Level;
    Collider Grab_col;
    /////////////////////////////////////////////////////


    Knock_back KB;
    public GameObject Knock_Back_gameObject;
    public int Knock_back_Level;
    Collider Knock_back_col;
    /////////////////////////////////////////////////////


    Jump_Attack jump_Attack;
    int Jump_Attack_Level;
    public GameObject Warrior;


    void Awake()
    {
        Jump_Attack_Level = 1;
        jump_Attack = new Jump_Attack(Warrior, Jump_Attack_Level);


        Normal_Level = 1;
        Normal = new Normal_Swing(Swing_Core,gameObject,Normal_Level,Sword);

        WheelWind_Level = 1;
        WheelWind = new WheelWind_Swing(Swing_Core, gameObject, WheelWind_Level, Sword);


        Grab = Grab_Swing_gameObject.GetComponent<Grab_Swing>();
        Grab_col = Grab_Swing_gameObject.GetComponent<Collider>();
        Grab_col.enabled = false;



        //////////////////////////////////////////////////////////////////////////////
        KB = Knock_Back_gameObject.GetComponent<Knock_back>();
        Knock_back_col = Knock_Back_gameObject.GetComponent<Collider>();
        Knock_back_col.enabled = false;


    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        Grab.Fire();//그랩샷
    }

    
    void JumpShot()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(jump_Attack.Shot());
        }
    }


    void WheelWindShot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(WheelWind.Swing_());
        }
    }
    void GrabShot()
    {
        if (Input.GetButton("Fire2"))
        {
            Grab.Fire();//그랩샷
        }
    }


    void Knock_Back()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Knock_back_col.enabled = true;
            StartCoroutine(KB.Knock_back_());

        }
    }



    void normal_Swing()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Normal.Swing_());//평타
        }
    }
}
