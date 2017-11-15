using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{ 
    public class LazerDamage_per_Sec : MonoBehaviour {

	    // Use this for initialization
	    void Start () {
	    }
	
	    // Update is called once per frame
	    void Update () {
	    }


        void OnTriggerEnter(Collider other)
        {
            Debug.Log("들어옴");
            //여기서 적의 HP를 깎는 작업을 한다.


        }

    

    }
}