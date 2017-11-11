using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angle_Test : MonoBehaviour {

    public GameObject Target;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1"))
        { 
              Quaternion newRotation = Quaternion.LookRotation(transform.position - Target.transform.position);
              rb.MoveRotation(newRotation);
         }

    }
}
