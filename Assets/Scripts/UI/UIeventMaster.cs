using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIeventMaster : MonoBehaviour {

	// Use this for initialization
	public Canvas canvas;
	public bool toggle;

	public Text user,text;

	void Start () {

	}
	
	void Update () {
		if(toggle){
			user.enabled = true;
			text.enabled = true;
		}else{
			user.enabled = false;
			text.enabled = false;
		}
	}
}
