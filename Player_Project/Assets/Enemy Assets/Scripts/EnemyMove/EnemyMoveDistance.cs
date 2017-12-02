using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyMoveDistance : MonoBehaviour
    {
        public float moveDistance = 5f;
        public float speed = 3f;

        private Vector3 initPos;
        private float moveDist;

        // Use this for initialization
        //private void Start()
        //{
        //    initPos = transform.position;

        //    StartCoroutine(c_MovePattern());
        //}

        private void OnEnable()
        {
            initPos = transform.position;
            StartCoroutine(c_MovePattern());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator c_MovePattern()
        {
            while (gameObject.activeSelf)
            {
                yield return StartCoroutine(c_MoveDistance(-transform.forward));

                yield return StartCoroutine(c_MoveBack());
                yield return null;
            }
        }

        private IEnumerator c_MoveDistance(Vector3 direct)
        {
            moveDist = 0f;

            while (moveDist < moveDistance)
            {
                transform.Translate(direct * speed * Time.deltaTime);

                moveDist += (direct * speed * Time.deltaTime).magnitude;

                yield return null;
            }
        }

        private IEnumerator c_MoveBack()
        {
            while (transform.position != initPos)
            {
                transform.position = Vector3.MoveTowards(transform.position, initPos, speed * Time.deltaTime);

                yield return null;
            }
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}