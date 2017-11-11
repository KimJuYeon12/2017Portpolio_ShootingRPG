using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanelCtrl : MonoBehaviour {

	public GameObject warrior, archer, magician;
    public int _class = 1; // warrior : 1, archer : 2, magician : 3

	public void WarriorActive()
	{
        _class = 1;
		warrior.SetActive (true);
		archer.SetActive (false);
		magician.SetActive (false);
	}

	public void ArcherActive()
	{
        _class = 2;
		warrior.SetActive (false);
		archer.SetActive (true);
		magician.SetActive (false);
	}

	public void MagicianActive()
	{
        _class = 3;
		warrior.SetActive (false);
		archer.SetActive (false);
		magician.SetActive (true);
	}
}