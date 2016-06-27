using UnityEngine;
using System.Collections;

public class Cam_rotate : MonoBehaviour {
	public GameObject target;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target.transform);
		transform.Translate(Vector3.right * Time.deltaTime);
	}
}
