using UnityEngine;

namespace Enemy
{
    public class Health : MonoBehaviour
    {
        public float EnemyCollaspedDamage = 30;

        public float StartHP = 100f;//시작 HP
        public float CurrentHP;//현재 HP

        private void Awake()
        {
            CurrentHP = StartHP;
        }

        //데미지입음
        public virtual void TakeDamage(float Damage)
        {
            CurrentHP -= Damage;//데미지만큼 깐다.

            if (CurrentHP <= 0f)
            {
                OnDeath();
            }
        }

        private void OnDeath()
        {
            if (transform.tag == "Player")
            {
                gameObject.SetActive(false);
                return;
            }

            if (gameObject.transform.parent)
            {
                Destroy(gameObject.transform.parent.gameObject);
                Debug.Log("aawefdsferdfacefiaefjerioio2jioio");
            }
            Destroy(gameObject);
        }   

        //private void OnCollisionEnter(Collision other)
    }
}