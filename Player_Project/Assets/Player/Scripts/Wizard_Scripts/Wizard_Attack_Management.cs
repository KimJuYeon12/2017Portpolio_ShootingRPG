using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{ 
    public class Wizard_Attack_Management : MonoBehaviour
    {
        public GameObject FireBolt;
        public GameObject ShotSpawnPoint;


        FireShot fireShot;

        MakeClone makeClone;
        public GameObject ClonePlayer;


        MakeBarrior makeBarrior;
        public GameObject Barrior;

        MateorShot mateorShot;
        public GameObject Mateor;

        GravityShot gravityShot;
        public GameObject Gravity_Set;

        NormalShot normalShot;
        public GameObject NormalBolt;
    
        void Awake()
        {
            normalShot = new NormalShot(ShotSpawnPoint, NormalBolt);
            fireShot = new FireShot(ShotSpawnPoint,FireBolt);
            makeClone = new MakeClone(gameObject,ClonePlayer);
            makeBarrior = new MakeBarrior(Barrior, ShotSpawnPoint);
            mateorShot = new MateorShot(gameObject, Mateor);
            gravityShot = new GravityShot(ShotSpawnPoint, Gravity_Set);
        }

	    // Use this for initialization
	    void Start () {
		
	    }
	
	    // Update is called once per frame
	    void Update () {
            //normalShot.Shot();
            //fireShot.Shot();
            //makeClone.Shot();
            //makeBarrior.Shot();
            //mateorShot.Shot();
            //gravityShot.Shot();
        }
    }
}