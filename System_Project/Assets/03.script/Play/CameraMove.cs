using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jiyong{
	public class CameraMove : MonoBehaviour {

		public GameObject player;
		float offset;

		// Use this for initialization
		void Start () {
			//player = GameObject.FindGameObjectWithTag("Player");
			offset = player.transform.position.z - transform.position.z;
		}

		// Update is called once per frame
		void LateUpdate () {
			//transform.position = player.transform.position - offset;
			transform.position = new Vector3(transform.position.x , transform.position.y , player.transform.position.z - offset);
		}
	}
}