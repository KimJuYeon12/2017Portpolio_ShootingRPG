using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jiyong{
	public class CameraMove : MonoBehaviour {

		public Transform player;
		float offset;
		float smoothing = 5f;

		// Use this for initialization
		void Start () {
			Debug.Log ("start");
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
			offset = player.transform.position.z - transform.position.z;
		}

		// Update is called once per frame
		void LateUpdate () {
			//Vector3 camPos = new Vector3(transform.position.x , transform.position.y , player.transform.position.z - offset);


			//transform.position = new Vector3(transform.position.x , transform.position.y , player.transform.position.z - offset);
			//transform.position = Vector3.Lerp(transform.position, player.transform.position, smoothing * Time.deltaTime);

			// 기존 코드
			transform.position = new Vector3(transform.position.x , transform.position.y , player.transform.position.z - offset);
		}
	}
}