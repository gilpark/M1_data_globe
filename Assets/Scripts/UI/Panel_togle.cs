
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Panel_togle : MonoBehaviour {

	Toggle tg;
	// Use this for initialization
	void Start () {
		tg = this.gameObject.GetComponent<Toggle>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToggleOn () {
		tg.isOn = true;
	}
	public void ToggleOff () {
		tg.isOn = false;
	}
}
