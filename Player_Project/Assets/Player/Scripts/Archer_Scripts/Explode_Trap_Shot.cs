using UnityEngine;

namespace Player
{
    public class Explode_Trap_Shot : ArcherShot
    {
        private GameObject Explode_Trap;
        public bool Is_Active = false;

        public Explode_Trap_Shot(GameObject Bolt, GameObject Shot_Spawn, GameObject Shot_Spawn_Point, int Shot_Level, GameObject Explode_Trap)
        : base(Bolt, Shot_Spawn, Shot_Spawn_Point, Shot_Level)
        {
            this.Explode_Trap = Explode_Trap;
        }



        public override void Shot()
        {
            //트랩을 생성
            //트랩의 실질적인 작동은 트랩의 프리팹에 달린 스크립트에서 처리한다.
            MonoBehaviour.Instantiate(Explode_Trap, Shot_Spawn_Point.transform.position, Shot_Spawn_Point.transform.rotation);
        }

    }
}

