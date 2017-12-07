using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyMoveStraight : MonoBehaviour
    {
        private Rigidbody rb;
        public float speed = 1f;
        public string outerTagName = "Outer";

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            StartCoroutine(c_Move());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator c_Move()
        {
            while (gameObject.activeSelf)
            {
                rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
                yield return null;
            }
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            //rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
            //rb.transform.Rotate(new Vector3(0f, 10f, 0f));
        }

        //private void OnTriggerEnter(Collider other)
        //{
        //    if (other.tag == outerTagName)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
    }
}