using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyMoveBoss1Junior : MonoBehaviour
    {
        public Vector3 moveVerticalDist = new Vector3(0f, 0f, -2f);
        public Vector3 moveHorizontalDist = new Vector3(8f, 0f, 0f);
        private bool checkHorizontal = false;
        private Vector3 initPos;
        public float speed = 10f;

        // Use this for initialization
        //private void Start()
        //{
        //    StartCoroutine(cEnemyPattern());
        //}
        private void Awake()
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }
        private void OnEnable()
        {
            StartCoroutine(cEnemyPattern());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator cEnemyPattern()
        {
            yield return StartCoroutine("cMoveVertical");
            yield return StartCoroutine("cMoveHorizontal");
        }

        private IEnumerator cMoveVertical()
        {
            initPos = transform.parent.position;

            while (transform.position != (initPos + moveVerticalDist))
            {
                moveVertical();
                yield return null;
            }
        }

        public void moveVertical()
        {
            transform.position = Vector3.MoveTowards(transform.position, initPos + moveVerticalDist, speed * Time.deltaTime);
        }

        private IEnumerator cMoveHorizontal()
        {
            initPos = transform.position;

            while (gameObject.activeSelf)
            {
                moveHorizontal();
                yield return null;
            }
        }

        public void moveHorizontal()
        {
            if (transform.position == initPos + moveHorizontalDist)
            {
                checkHorizontal = true;
            }
            else if (transform.position == initPos)
            {
                checkHorizontal = false;
            }

            if (!checkHorizontal)
            {
                transform.position = Vector3.MoveTowards(transform.position, initPos + moveHorizontalDist, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, initPos, speed * Time.deltaTime);
            }
        }

        // Update is called once per frame
        private void Update()
        {
        }
    }
}