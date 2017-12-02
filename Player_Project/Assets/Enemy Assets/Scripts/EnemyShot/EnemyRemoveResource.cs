using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyRemoveResource : MonoBehaviour
    {
        public string resourceTagName = "Resource";
        public int cnt = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == resourceTagName && cnt > 0)
            {
                Destroy(other.gameObject);
                cnt--;
            }
        }
    }
}