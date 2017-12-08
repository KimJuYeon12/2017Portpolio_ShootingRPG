using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace jiyong{
	public class StageButton : MonoBehaviour, IPointerClickHandler {

		public int stageNum;

		StageManager sm;

		void Start()
		{
			sm = GameObject.Find ("StageManager").GetComponent<StageManager> ();
		}

		// panelActive ctrl
		public void OnPointerClick(PointerEventData data)
		{
			sm.panelInActive ();
			sm.panelActive (stageNum);
		}



		/*
	public void panelActive()
	{
		Debug.Log ("click");
		if(sm.stageOn[stageNum]) // stage가 on이면
			sm.panel[stageNum].SetActive(true);
	}
	*/
	}
}