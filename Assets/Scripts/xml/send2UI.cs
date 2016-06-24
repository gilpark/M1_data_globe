// ******func test
using UnityEngine;
using System.Collections;

public  class send2UI : MonoBehaviour{
	public GameObject EventSystem;
	void Start () {
		EventSystem = GameObject.Find("EventSystem");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseOver(){
		print(gameObject.transform.localScale);
		gameObject.transform.localScale = new Vector3(0.2f,0.2f,0.2f); 
		gameObject.GetComponent<Renderer>().material.color = Color.yellow;
	
	}
	void OnMouseExit(){
		gameObject.transform.localScale = new Vector3(0.08f,0.08f,0.08f); 
		gameObject.GetComponent<Renderer>().material.color = Color.green;
	}
	void OnMouseDown(){
		sendString();
		EventSystem.GetComponent<UIeventMaster>().toggle = !EventSystem.GetComponent<UIeventMaster>().toggle;
	}
	public void sendString(){
		string usr = gameObject.GetComponent<_clonedItem>().name;
		string msg = gameObject.GetComponent<_clonedItem>().text;

		EventSystem.GetComponent<UIeventMaster>().text.text = msg;
		EventSystem.GetComponent<UIeventMaster>().user.text = usr;
	}
}
