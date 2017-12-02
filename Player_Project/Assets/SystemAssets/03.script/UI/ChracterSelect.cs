using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jiyong{
	public class ChracterSelect : MonoBehaviour {

		InfoManager im;
		SkillPanelCtrl sctrl;

		// Use this for initialization
		void Start () {
			im = GameObject.Find ("InfoManager").GetComponent<InfoManager> ();
			sctrl = GameObject.Find ("SkillManager").GetComponent<SkillPanelCtrl> ();
		}

		// 직업값 받아온다
		public void getPlayerType() {
			im.playerType = sctrl._class;
		}
	}
}