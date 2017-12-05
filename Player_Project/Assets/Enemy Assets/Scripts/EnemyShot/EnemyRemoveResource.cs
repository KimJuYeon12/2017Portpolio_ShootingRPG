using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyRemoveResource : MonoBehaviour
    {
        public string resourceTagName = "Bottom";
        public int resourceLayerIndex = 11;

        public int cnt = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == resourceTagName && other.gameObject.layer == resourceLayerIndex && cnt > 0)
            {
                Destroy(other.gameObject);
                cnt--;
            }
        }
    }
}