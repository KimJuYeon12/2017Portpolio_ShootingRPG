using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : Health
    {
        float PlayerCollaspedDamage = 100;
        private void OnDeath()
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != "Player" && other.tag != "PlayerBolt") return;

            Debug.Log("cheak");
            Debug.Log("tag = "+other.tag);

            //여기서 각종 탄알과 적에 대한 데미지를 구분해서 적용시켜야한다.
            //부딫힌 물체의 스크립트에 접근해서 데미지값을 받아오자.
            //부딫히는 물체는
            // 1. 적 본체
            // 2. 탄알
            //이 두개에 대하여 각각에 데미지 스크립트를 추가한 후 가져오자.


            if (other.tag == "Player")
            {
                //적의 본체에 부딫힌 경우 이 데미지를 주자.
                TakeDamage(PlayerCollaspedDamage);
            }


            else//탄알에 부딫힌 경우
            {
                Debug.Log("여기");
                //탄알마다에 있는 데미지 스크립트를 가져와서 해당 데미지를 가져온다.
                TakeDamage(other.gameObject.GetComponent<Player.Damage>().damage);
            }
        }
    }
}