using UnityEngine;

namespace jiyong{
	public class ColliderCheaking : MonoBehaviour
	{
		void OnCollisionEnter(Collision other)
		{
			if (other.transform.tag == "Drop") 
			{
				//transform.position = other.transform.position + new Vector3(0,0,0.5f);
				transform.position = new Vector3(transform.position.x, 0, other.transform.position.z + 0.5f);
				//other.transform.tag = "Crash";	
			}
			return;
		}

		void OnCollisionStay(Collision other)
		{
			Player_Movement.CanJump = true;
		}
		void OnCollisionExit(Collision other)
		{
			Player_Movement.CanJump = false;
		}
	}
}
