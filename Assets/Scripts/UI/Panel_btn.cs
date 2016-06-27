using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Panel_btn : MonoBehaviour {

	Button btn;
	// Use this for initialization
	void Start () {
		btn = gameObject.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InteractiveSToggle(){
		btn.interactable = ! btn.interactable;

	}
	public void ToggleActive () {
		btn.enabled = !btn.enabled;
	}
}