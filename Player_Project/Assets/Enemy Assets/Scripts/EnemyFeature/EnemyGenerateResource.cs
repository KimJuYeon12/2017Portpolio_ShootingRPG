using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyGenerateResource : MonoBehaviour
    {
        private int health = 3;

        // Use this for initialization
        private void Start()
        {
            Debug.Log(Mathf.Floor(-4.5f));

            Physics.gravity = new Vector3(0f, 0f, -9.8f);
            StartCoroutine(testc());
        }

        private IEnumerator testc()
        {
            while (gameObject.activeSelf)
            {
                health--;
                if (health < 0)
                {
                    Debug.Log(1);
                    Destroy(gameObject);
                }
                yield return new WaitForSeconds(1f);
            }
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void OnDestroy()
        {
            GenerateResource();
        }

        public void GenerateResource()
        {
            GameObject resource = GameObject.CreatePrimitive(PrimitiveType.Cube);
            resource.transform.position = Vector3Round(transform.position);
            resource.transform.localScale = new Vector3(1f, 1f, 1f);
            Rigidbody rrb = resource.AddComponent<Rigidbody>();
            rrb.useGravity = true;
        }

        public Vector3 Vector3Round(Vector3 v)
        {
            Vector3 tmp = v;
            float adder = 0.5f;

            if (tmp.x < 0)
            {
                adder *= -1;
            }
            tmp.x = Mathf.Floor(tmp.x) + adder;
            return tmp;
        }
    }
}