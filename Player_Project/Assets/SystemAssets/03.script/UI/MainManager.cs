﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace jiyong{
	public class MainManager : MonoBehaviour {

		public void toAdventureScene()
		{
			SceneManager.LoadScene("Adventure");	
		}
		public void toSkillScene()
		{
			SceneManager.LoadScene("Skill");	
		}
	}
}