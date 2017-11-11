using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SubStageButton : MonoBehaviour, IPointerClickHandler {

	public InfoManager info;

	void Start()
	{
		info = GameObject.Find("InfoManager").GetComponent<InfoManager>();
	}

	// change Scene to game Play stage
	public void OnPointerClick(PointerEventData data)
	{
		
		string buttonName = gameObject.name;
		SceneManager.LoadScene(buttonName);

	}

}
