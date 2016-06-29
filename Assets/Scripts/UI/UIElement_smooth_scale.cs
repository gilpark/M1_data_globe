using UnityEngine;
using System.Collections;

public class UIElement_smooth_scale : MonoBehaviour {

	public Vector3 start_scale;
	public Vector3 end_scale;
    public float duration = 5.0F;
    private float startTime;
    public bool scaled;

	// Use this for initialization
	void Start () {
		// startTime = Time.time;
		transform.localScale = start_scale;
		 // StartCoroutine(ScaleUP());
	}
	
	void Update () {
		 
	}
    public void wraper_ScaleUP(){
    	StartCoroutine(ScaleUP());
    }
    public void wraper_ScaleDOWN(){
    	// StartCoroutine(ScaleDOWN());
    	transform.localScale = start_scale;
    }
	public IEnumerator ScaleUP(){
		startTime = Time.time;

		int a = 1;
		 while(a == 1){
		 	float t = (Time.time - startTime) / duration;
		 	transform.localScale = Vector3.Slerp (transform.localScale, end_scale, Mathf.SmoothStep(0.0f, 1.0f, t));
		 	if(Mathf.SmoothStep(0.0f, 1.0f, t) > 0.9) a = 0;
		  yield return null;
		}
		scaled =!scaled;
	}
	public void ScaleDOWN(){
		transform.localScale = start_scale;
	// 	int a = 1;
	// 	 while(a == 1){
	// 	 	float t = (Time.time - startTime) / duration;
	// 	 	transform.localScale = Vector3.Slerp (transform.localScale, start_scale, Mathf.SmoothStep(0.0f, 1.0f, t));
	// 	 	if(Mathf.SmoothStep(0.0f, 1.0f, t) > 0.9) a = 0;
	// 	  yield return null;
	// 	}
	// 	scaled =!scaled;

	}
}
