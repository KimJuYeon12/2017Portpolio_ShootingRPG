using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Enemy
{
    public class PlayerMove : MonoBehaviour
    {
        public void Update()
        {
            keyEvent();
        }

        public void keyEvent()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-0.1f, 0f, 0f));
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(0.1f, 0f, 0f));
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0f, 0f, 0.1f));
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0f, 0f, -0.1f));
            }
        }
    }
}