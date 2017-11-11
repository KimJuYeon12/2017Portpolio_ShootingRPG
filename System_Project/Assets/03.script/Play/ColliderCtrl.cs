using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCtrl : MonoBehaviour {

	GameManager gm = new GameManager();

	void Start()
	{
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();
	}

	void OnCollisionEnter(Collision col)
	{
		// 바닥에 닿으면 tag를 변경하고 dictionary에 추가
		if (transform.tag != "Drop" && col.transform.tag == "Drop" || col.transform.tag == "Crash") {
			col.transform.tag = "Bottom";

			// z값 > x값으로 가중치 계산하여 위치정보를 담은 int값을 key로 사용
			double x,z;
			x = Mathf.Round(col.transform.position.x);
			z = Mathf.Round(col.transform.position.z);
			//Debug.Log ("Stack!! z : " + z + "// x : " + x);
			int key = (int)(z * 10 + x);
			gm.stackBlock (key, col.gameObject);
		}
	}
}
