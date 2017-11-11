using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomal_FireBolt : MonoBehaviour {

    Rigidbody rb;
    float speed = 5f;
	void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // Use this for initialization
	void Start ()
    {
        StartCoroutine(Bigger(gameObject));
        rb.velocity = rb.transform.forward * speed;
	}
	
	// Update is called once per frame
	void Update () {
    }

    IEnumerator Bigger(GameObject Instantiate_FireBolt)
    {

        
            for (float i = 0.1f; i < 5; i = i + Time.deltaTime)
            {
                Instantiate_FireBolt.transform.localScale = new Vector3(i, i, i);
                yield return null;
            }
        
    }
}
