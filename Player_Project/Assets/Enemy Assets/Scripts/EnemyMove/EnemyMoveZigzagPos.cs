using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Enemy
{
    public class EnemyMoveZigzagPos : MonoBehaviour
    {
        public float speed;
        private Rigidbody enemyRigidbody;
        public Vector3[] turnPoint = new Vector3[3];
        public string outerTagName = "Outer";

        private void Awake()
        {
            enemyRigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            //StartCoroutine(move());
        }

        private void OnEnable()
        {
            StartCoroutine(move());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        private IEnumerator move()
        {
            for (int i = 0; i < turnPoint.Length; i++)
            {
                while (transform.position != turnPoint[i])
                {
                    transform.position = Vector3.MoveTowards(transform.position, turnPoint[i], speed * Time.deltaTime);
                    yield return null;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == outerTagName)
            {
                Destroy(gameObject);
            }
        }
    }
}