using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAnim : MonoBehaviour {

    public Animator Anim;

    private void OnCollisionEnter(Collision other)
    {
        Anim.SetBool("IsGround",true);
    }
}
