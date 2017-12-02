using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyShotAround : MonoBehaviour
    {
        public GameObject missile;

        public enum Rotation_Direct
        {
            Right, Left
        }

        public Rotation_Direct rotationDirect;
        public float rotationSpeed = 10f;

        // Use this for initialization
        private void Start()
        {
            if (rotationDirect == Rotation_Direct.Left)
            {
                rotationSpeed *= -1f;
            }
            missile.SetActive(true);
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void FixedUpdate()
        {
            missile.transform.Rotate(0f, rotationSpeed, 0f);
        }
    }
}