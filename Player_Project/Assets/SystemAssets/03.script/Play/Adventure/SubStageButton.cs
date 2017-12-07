using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

namespace jiyong{
	public class SubStageButton : MonoBehaviour, IPointerClickHandler {

		public InfoManager im;
		public int Lv;

		void Start()
		{
			im = GameObject.Find("InfoManager").GetComponent<InfoManager>();
		}

		// change Scene to game Play stage
		public void OnPointerClick(PointerEventData data)
		{
			if((im.maxClear + 1) >= Lv) 
			{
				im.lastPlayLv = Lv; // 플레이하는 스테이지 레벨을 im에 기록
				string buttonName = gameObject.name;
				SceneManager.LoadScene(buttonName);
			}
		}

	}
}