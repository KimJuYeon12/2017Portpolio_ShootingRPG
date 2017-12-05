using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

namespace Player
{ 
    public class LazerDamage_per_Sec : MonoBehaviour {

        public GameObject LaserParticle;

	    // Use this for initialization
	    void Start () {
	    }
	
	    // Update is called once per frame
	    void Update () {
	    }


        void OnTriggerStay(Collider other)
        {
            if (other.tag == "EnemyBolt" || other.tag == "PlayerBolt") return;
            Debug.Log("들어옴");
            //여기서 적의 HP를 깎는 작업을 한다.
            
            Destroy(Instantiate(LaserParticle, other.transform.position, Quaternion.identity),0.1f);

            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
        }

    

    }
}