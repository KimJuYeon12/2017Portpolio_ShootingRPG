using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class PlayerControl : MonoBehaviour
    {
        public float speed = 0.1f;

        // Use this for initialization
        private void Start()
        {
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void FixedUpdate()
        {
            PlayerController();
        }

        public void PlayerController()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-speed, 0f, 0f));
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(speed, 0f, 0f));
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0f, 0f, speed));
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0f, 0f, -speed));
            }
        }
    }
}