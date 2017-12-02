using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace jiyong{
	public class BackButton : MonoBehaviour {
		public void toMainScene()
		{
			SceneManager.LoadScene("Main");	
		}
	}
}
