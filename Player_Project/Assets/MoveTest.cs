using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour {
    Rigidbody rb;
    int speed=5;
    public bool Is_Velocity;


    void Awake()
    {
        Is_Velocity = true;
       rb = GetComponent<Rigidbody>();
    }
    
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            if(Is_Velocity) rb.velocity = -rb.transform.forward * speed;
    }
}
