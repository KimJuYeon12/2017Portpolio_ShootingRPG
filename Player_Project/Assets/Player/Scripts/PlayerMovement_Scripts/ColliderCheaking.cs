using UnityEngine;


namespace Player
{ 
    public class ColliderCheaking : MonoBehaviour
    {
        void OnCollisionEnter(Collision other)
        {
            if (other.transform.tag != "New") return;
            gameObject.transform.position = other.transform.position + new Vector3(0,0,0.55f);
            //other.transform.tag = "Resource";
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