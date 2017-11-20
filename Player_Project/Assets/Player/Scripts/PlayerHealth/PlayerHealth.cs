using UnityEngine;
using UnityEngine.UI;


namespace Player
{ 
public class PlayerHealth : Health
{

    public Slider Player_Slider;
    public Image CurrentHP_color;

    private Color MaxHP_color = Color.green;//맥스일때의 색깔
    private Color MinHP_color = Color.red;//민일때의 색깔
    private bool Is_Dead = false;


    //warrior
    public bool SuperAmmor = false;


    //활성화 될때 세팅되는 부분
    private void OnEnable()
    {
        CurrentHP = StartHP;
        Is_Dead = false;
    }


    //데미지입음
    public override void TakeDamage(float Damage)
    {
        CurrentHP -= Damage;//데미지만큼 깐다.
        SetHealthUI();

        if (CurrentHP <= 0f && !Is_Dead)
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        Is_Dead = true;
        gameObject.SetActive(false);
    }


    private void SetHealthUI()
    {
        Player_Slider.value = CurrentHP;

        CurrentHP_color.color = Color.Lerp(MinHP_color, MaxHP_color, CurrentHP / StartHP);
    }


    //컴포넌트의 isTrigger과는 별개로 아래 메소드 두개가 모두 동작함
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Enemy" && other.tag != "EnemyBolt") return;
            Debug.Log(other.tag);

        //여기서 각종 탄알과 적에 대한 데미지를 구분해서 적용시켜야한다.
        //부딫힌 물체의 스크립트에 접근해서 데미지값을 받아오자.
        //부딫히는 물체는
        // 1. 적 본체
        // 2. 탄알
        //이 두개에 대하여 각각에 데미지 스크립트를 추가한 후 가져오자.


        if (other.tag == "Enemy")
        {
            //적의 본체에 부딫힌 경우 이 데미지를 주자.
            TakeDamage(EnemyCollaspedDamage);
        }


        else//탄알에 부딫힌 경우
        {
            //탄알마다에 있는 데미지 스크립트를 가져와서 해당 데미지를 가져온다.
            TakeDamage(other.gameObject.GetComponent<Damage>().damage);
        }
    }
    //private void OnCollisionEnter(Collision other)
}

}