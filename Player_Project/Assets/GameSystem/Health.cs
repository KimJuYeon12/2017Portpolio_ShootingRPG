using UnityEngine;

public class Health : MonoBehaviour {

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
        gameObject.SetActive(false);
    }
    //private void OnCollisionEnter(Collision other)
}

