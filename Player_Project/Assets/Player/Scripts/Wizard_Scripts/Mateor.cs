using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{ 
public class Mateor : MonoBehaviour {

    Rigidbody rb;
    public int speed;
    public Vector3 Player_pos;

    void Awake()
    {
        speed = 20;
        rb = GetComponent<Rigidbody>();
       
        


    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position 
        = Vector3.MoveTowards(gameObject.transform.position, Player_pos + new Vector3(0, -1, 7), Time.deltaTime * 10);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Map") return;

        StartCoroutine(Size_Up());
    }
    IEnumerator Size_Up()
    {
        for(float i=0;i<5;i = i+ Time.deltaTime*10)
        {
            gameObject.transform.localScale = new Vector3(1+i,1,1+i);
            yield return null;
        }
        Destroy(gameObject,1f);
    }
}
}