using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
        //이방식은 일일히 오브젝트 만들어서 확장해나가는식
        //int n = 1;
        //int[] Idx = { -1, -1 };//new int[2];
        //int[] Add = { 1, 1, -1, -1 };


        //for (int p = 0; p < 4; p++)
        //{
        //    for (int q = 0; q <= n; q++)
        //    {
        //        Idx[p % 2] = Idx[p % 2] + Add[p];
        //        MonoBehaviour.Instantiate(gameObject, transform.position + new Vector3(Idx[0], 0, Idx[1]), transform.rotation);
        //    }
        //}

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
