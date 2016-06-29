using UnityEngine;
using System.Collections;

public class Stream_counter : MonoBehaviour {

	// Use this for initialization
	float timer;
	public float timeout = 5.0f;

	public GameObject SqlConnector;
	bool stream;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(stream){
			timer += Time.deltaTime;
			if(timer > timeout){
			timer = 0;
			SqlConnector.GetComponent<MySQLConnector>().Request("stream");	
			}
		}
		
	}
	public void Stream(){
		stream =!stream;
		timer = 0;
	}
}
