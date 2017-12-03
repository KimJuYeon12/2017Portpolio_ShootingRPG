using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyMoveDistance : MonoBehaviour
    {
        [HideInInspector]
        public float moveDistance = 5f;

        public float speed = 3f;
        public GameObject mainCamera;

        public float forwardDist = 5f;
        public float backwardDist = 5f;
        public float bossCenterPosZAdder = 10f;

        private Vector3 initPos;
        private float moveDist;
        private Vector3 bossCenterPos;

        // Use this for initialization
        //private void Start()
        //{
        //    initPos = transform.position;

        //    StartCoroutine(c_MovePattern());
        //}
        private void Awake()
        {
            mainCamera = Camera.main.gameObject;
        }


        private void OnEnable()
        {
            //initPos = transform.position;
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
                //yield return StartCoroutine(c_MoveDistance(-transform.forward));
                yield return StartCoroutine(c_MoveForward());

                yield return StartCoroutine(c_MoveBackward());
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

        private IEnumerator c_MoveForward()
        {
            bossCenterPos = mainCamera.transform.position
                + new Vector3(0f, -mainCamera.transform.position.y, 0f);

            while (transform.position != bossCenterPos)
            {
                bossCenterPos = mainCamera.transform.position
            + new Vector3(0f, -mainCamera.transform.position.y, -forwardDist + bossCenterPosZAdder);

                transform.position = Vector3.MoveTowards(transform.position,
                    bossCenterPos, speed * Time.deltaTime);

                yield return null;
            }
        }

        private IEnumerator c_MoveBackward()
        {
            bossCenterPos = mainCamera.transform.position
                + new Vector3(0f, -mainCamera.transform.position.y, 0f);

            while (transform.position != bossCenterPos)
            {
                bossCenterPos = mainCamera.transform.position
            + new Vector3(0f, -mainCamera.transform.position.y, backwardDist + bossCenterPosZAdder);

                transform.position = Vector3.MoveTowards(transform.position,
                    bossCenterPos, speed * Time.deltaTime);

                yield return null;
            }
        }
    }
}