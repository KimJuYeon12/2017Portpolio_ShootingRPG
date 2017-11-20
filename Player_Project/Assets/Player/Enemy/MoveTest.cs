using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour {
    Rigidbody rb;
    int speed=5;
    public bool Is_Velocity;


    private IEnumerator Test()
    {
        while(true)
        {
            transform.Translate(-Vector3.forward/4f);
            Debug.Log("werwerwer");
            yield return null;
        }
    }


    void Awake()
    {
        Is_Velocity = true;
       rb = GetComponent<Rigidbody>();
    }
    
    // Use this for initialization
	void Start () {

        if(Is_Velocity) rb.velocity = -rb.transform.forward * speed;
	}
	private void OnEnable()
    {
        StartCoroutine(Test());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

	// Update is called once per frame
	void Update () {
    }
}
