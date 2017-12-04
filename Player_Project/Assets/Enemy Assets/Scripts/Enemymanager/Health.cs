﻿using UnityEngine;

namespace Enemy
{
    public class Health : MonoBehaviour
    {
        public float EnemyCollaspedDamage = 30;

        public float StartHP = 100f;//시작 HP
        public float CurrentHP;//현재 HP

        public GameObject dieParticle;


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

        public void OnDeath()
        {
            Debug.Log("qdsdqwdsfwefdsf!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            if (transform.tag == "Player")
            {
                gameObject.SetActive(false);
                return;
            }

            if (gameObject.transform.parent)
            {
                Destroy(gameObject.transform.parent.gameObject);
                Debug.Log("부모 오브젝트까지 같이 사라짐");
            }

            if (dieParticle != null)
            {
                Debug.Log("11111111111111111111111111");
                Destroy(Instantiate(dieParticle, transform.position, dieParticle.transform.rotation), 1.5f);
            }
          
            Destroy(gameObject);
        }   

        //private void OnCollisionEnter(Collision other)
    }
}