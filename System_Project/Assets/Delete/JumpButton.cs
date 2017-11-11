using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour {

	public GameObject player;
	public PlayerControl playerCtrl;
	public float jumpPower = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			UnityEngine.Debug.Log ("jump??");
			if(!playerCtrl.jumpDelay)
			{
				UnityEngine.Debug.Log ("jump!!");
				player.transform.position = new Vector2 (player.transform.position.x, player.transform.position.y - jumpPower);
				playerCtrl.jumpDelay = true;
			}
		}
	}
	/*
	void OnMouseDown ()
	{
		UnityEngine.Debug.Log ("jump??");
		if(!playerCtrl.jumpDelay)
		{
			UnityEngine.Debug.Log ("jump!!");
			//player.transform.position = new Vector2 (player.transform.position.x, player.transform.position.y + jumpPower);
			//player.transform.position = new Vector3 (player.transform.position.x, Mathf.Clamp (player.transform.position.y + jumpPower, -4.5f, 4.5f), transform.position.z);
			player.transform.Translate(0, (jumpPower * Time.deltaTime), 0);
			playerCtrl.jumpDelay = true;
		}
	}
	*/	
}
