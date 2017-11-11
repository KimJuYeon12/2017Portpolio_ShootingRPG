using System.Collections;
using UnityEngine;

public class ResourceMove : MonoBehaviour {

    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player") { Debug.Log("여기걸림"); return; }
        if (other.transform.tag != "Resource") return;
        
        //자원일때만 밑으로 내려가게 만든다.
        Destroy(rb);
        tag = "Resource";
    }

}
