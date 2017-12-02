using System.Collections;
using UnityEngine;

namespace jiyong{
	public class ResourceMove : MonoBehaviour {

		Rigidbody rb;
		void Awake()
		{
			rb = GetComponent<Rigidbody>();
		}
		void OnCollisionEnter(Collision other)
		{
			if (other.transform.tag == "Drop")
				rb.velocity = new Vector3(0,0,-1f);
			if (other.transform.tag == "Player") { Debug.Log("여기걸림"); return; }
			if (other.transform.tag != "Bottom") return;

			//자원일때만 밑으로 내려가게 만든다.
			Destroy(rb);
			tag = "Bottom";
		}
	}
}