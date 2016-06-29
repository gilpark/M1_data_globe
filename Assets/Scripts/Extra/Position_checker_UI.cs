using UnityEngine;
using System.Collections;

public class Position_checker_UI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space"))
		print(gameObject.transform.position);
	}
}
