using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{ 
public class Core_Move : MonoBehaviour {

    //int speed = 5;
    public GameObject bolt;

    void Awake()
    {

    }

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        //transform.Translate(new Vector3(0, 0, 0.1f));
        transform.Rotate(new Vector3(0, 20f, 0));
        bolt.transform.localPosition = new Vector3(0,0, bolt.transform.localPosition.z - Time.deltaTime*0.1f);
    }
}
}