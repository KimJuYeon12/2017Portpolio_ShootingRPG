using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed = 10f;
	public float moveLimit = 2.3f;
	public float gravity = 1f;
	public float jumpPower = 5f;
	public bool jumpDelay;

	private Vector3 initMousePos;
	public	 float touchDelay = 0.3f;
	private float firstTouchTime;
	private bool firstTouch;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
		jumpDelay = true;
		firstTouch = false;
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		if(Input.GetMouseButtonDown(0))
		{
			// touch
			initMousePos = Input.mousePosition;
			initMousePos.z = 10;
			initMousePos = Camera.main.ScreenToWorldPoint (initMousePos);

			if (!firstTouch) 
			{
				firstTouchTime = Time.time;
				firstTouch = true;
			}
			else if(firstTouch && !jumpDelay) // double Touch
			{
				UnityEngine.Debug.Log("Double Click!");
				rb.AddForce(new Vector2 (0f, jumpPower), ForceMode.Impulse);
				jumpDelay = true;
			}
		}

		if(firstTouch && (Time.time - firstTouchTime) > touchDelay)
		{
			firstTouch = false;
		}

		if(Input.GetMouseButton(0))
		{
			// drag
			Vector3 worldPoint = Input.mousePosition;
			worldPoint.z = 10;
			worldPoint = Camera.main.ScreenToWorldPoint (worldPoint);

			Vector3 diffPos = worldPoint - initMousePos;
			diffPos.z = 0;
			diffPos.y = 0;

			initMousePos = Input.mousePosition;
			initMousePos.z = 10;
			initMousePos = Camera.main.ScreenToWorldPoint (initMousePos);

			UnityEngine.Debug.Log ("trigger Exit");
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x + diffPos.x, -moveLimit, moveLimit), transform.position.y, transform.position.z);
		}
		/*
		if (jumpDelay) 
		{
			// 점프 중일때 점점 떨어짐
			transform.Translate(0, -(gravity * Time.deltaTime), 0);
		}
		*/

		// test용 // 플레이어 낙하 방지 코드
		if (transform.position.y < -6f) {
			transform.transform.position = new Vector2(transform.position.x, -2f);
		}
	}
	void Update () 
	{
		
	}
}
