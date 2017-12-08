using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("들어옴");
        //if (other.tag == "Drop") return;
        Destroy(other.gameObject);

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
