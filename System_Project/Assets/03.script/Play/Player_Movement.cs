using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace jiyong{

	public class Player_Movement : MonoBehaviour, IDragHandler
	{
		private int Layermask = 1 << 11;
		public Transform Player;
		Rigidbody Player_rb;
		float L_LimitX = 0;
		float R_LimitX = 9;

		public float Power;
		bool On_Drag;

		public static bool CanJump = true;
		float JumpStartTime;
		float JumpEndTime = -500f;
		private Ray rightRay;
		private Ray leftRay;

		void Awake() {
			On_Drag = false;
		}

		void Start() {
			Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
			Player_rb = Player.GetComponent<Rigidbody>();
		}

		public void OnDrag(PointerEventData data)
		{
			On_Drag = true;
			if (data.delta.x > 0)//오른쪽
			{
				rightRay = new Ray(Player.transform.position, Vector3.right);
				if (Physics.Raycast(rightRay, 0.6f ,Layermask))
				{
					return;
				}
				Player.transform.Translate(new Vector3(Mathf.Min(data.delta.x,3f) * Power, 0, 0));

			}
			else// 왼쪽
			{
				leftRay = new Ray(Player.transform.position, Vector3.left);
				if (Physics.Raycast(leftRay,0.6f, Layermask))
				{
					return;
				}
				Player.transform.Translate(new Vector3(Mathf.Max(data.delta.x, -3f) * Power, 0, 0));
			}
			//Debug.Log("플레이어의 포지션"+Player_rb.position.x);
			if (Player_rb.position.x >= L_LimitX && Player_rb.position.x <= R_LimitX) return;//0이상 9이하

			My_Clamp();
		}

		void My_Clamp()
		{
			if (Player_rb.position.x < 0) Player.transform.position = new Vector3(0.01f, Player_rb.position.y, Player_rb.position.z);
			else Player.transform.position = new Vector3(8.99f, Player_rb.position.y, Player_rb.position.z);
		}

		public void Click()
		{
			if (!CanJump) return;
			if (On_Drag) { On_Drag = false; return;}
			StartCoroutine(Up());
		}

		IEnumerator Up()
		{
			for(float i=0;i<0.3f;i = i+ Time.deltaTime*1.3f)
			{
				Player.transform.Translate(new Vector3(0, i, 0));
				yield return null;
			}
		}
	}
}