using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyEnhance : MonoBehaviour
    {
        //EnemyMoveStraight ems;
        public float speed = 20f;

        // Use this for initialization
        private void Start()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            //ems = other.GetComponent<EnemyMoveStraight>();
            //ems.speed -= speed;
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}