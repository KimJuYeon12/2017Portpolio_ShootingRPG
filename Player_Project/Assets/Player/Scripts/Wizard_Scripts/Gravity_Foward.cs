using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{ 
public class Gravity_Foward : MonoBehaviour {

    float Now_Time;
    void Awake()
    {
        Now_Time = Time.time;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0,0,0.02f);
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag != "Enemy") return;
        //other.transform.position = Vector3.MoveTowards(other.transform.position, transform.position, 1/(Time.time - Now_Time)*Time.deltaTime*7);// Time.deltaTime*0.5f);
        other.transform.position = Vector3.MoveTowards(other.transform.position, transform.position, Time.deltaTime*0.8f);
    }


}
}