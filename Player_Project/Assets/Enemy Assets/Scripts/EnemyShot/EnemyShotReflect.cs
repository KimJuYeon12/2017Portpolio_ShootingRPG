using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyShotReflect : MonoBehaviour
    {
        public Rigidbody rb;
        private Vector3 initVector;
        public float speed = -5f;
        public int conflicCnt = 4;

        // Use this for initialization
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            rb.velocity = gameObject.transform.forward * speed;

            initVector = transform.position;
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.tag == "Enemy" || other.tag == "EnemyBolt") return;
        //    Debug.Log("tag = "+ other.tag);
        //    Debug.Log("aaa");

        //    Vector3 incomingVector = transform.position - initVector;
        //    incomingVector = incomingVector.normalized;

        //    Vector3 normalVector = transform.position.normalized;
        //    Vector3 reflectVector = Vector3.Reflect(incomingVector, normalVector);
        //    reflectVector = reflectVector.normalized;

        //    rb.velocity = reflectVector * Mathf.Abs(speed);

        //    initVector = transform.position;
    //    confliccnt--;
    //        if (confliccnt <= 0)
    //        {
    //            destroy(gameobject);
    //}
    //}
    //private void Func()
    //{
    //    //Vector3 incomingVector = transform.position - initVector;
    //    //incomingVector = incomingVector.normalized;

    //    //Vector3 normalVector = collision.contacts[0].normal;
    //    //Vector3 reflectVector = Vector3.Reflect(incomingVector, normalVector);
    //    //reflectVector = reflectVector.normalized;

    //    //rb.velocity = reflectVector * Mathf.Abs(speed);

    //    //initVector = transform.position;
    //    //conflicCnt--;
    //    //if (conflicCnt <= 0)
    //    //{
    //    //    Destroy(gameObject);
    //    //}
    //}
    private void OnCollisionEnter(Collision collision)
    {

            //    Vector3 incomingVector = transform.position - initVector;
            //    incomingVector = incomingVector.normalized;

            //    Vector3 normalVector = collision.contacts[0].normal;
            //    Vector3 reflectVector = Vector3.Reflect(incomingVector, normalVector);
            //    reflectVector = reflectVector.normalized;

            //    rb.velocity = reflectVector * Mathf.Abs(speed);

            //    initVector = transform.position;
            if (collision.transform.tag == "EnemyBolt") return;
            conflicCnt--;
            if (conflicCnt <= 0)
            {
                Destroy(gameObject);
            }
        }
}
}