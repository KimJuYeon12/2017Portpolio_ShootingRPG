using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBolt : MonoBehaviour {

    Rigidbody rb;
    int speed = 20;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    // Use this for initialization
    void Start()
    {
        Debug.Log("노말샷 총알");
        rb.velocity =rb.transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
