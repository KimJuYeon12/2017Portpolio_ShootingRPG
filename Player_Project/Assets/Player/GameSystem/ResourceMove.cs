using System.Collections;
using UnityEngine;
using Player;

namespace Jiyong
{ 
public class ResourceMove : MonoBehaviour {

    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player") { Debug.Log("여기걸림"); return; }
        if (other.transform.tag != "Bottom") return;

            Debug.Log("땅에 부딫힘");


            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z+0.25f));


            foreach (var v in other.gameObject.GetComponents<MonoBehaviour>())
            {
                v.enabled = false;
            }
                //자원일때만 밑으로 내려가게 만든다.
                Destroy(rb);
            tag = "Bottom";
    }

}
}