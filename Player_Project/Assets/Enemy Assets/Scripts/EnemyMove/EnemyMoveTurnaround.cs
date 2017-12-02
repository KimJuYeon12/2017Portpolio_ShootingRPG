using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Enemy
{
    public class EnemyMoveTurnaround : MonoBehaviour
    {
        private Rigidbody enemyRigidbody;
        public float speed;
        public GameObject target;
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
            while (gameObject.activeSelf)
            {
                transform.RotateAround(target.transform.position, Vector3.up, speed * Time.deltaTime);
                Quaternion init = Quaternion.Euler(0f, 0f, 0f);
                transform.rotation = init;
                yield return null;
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