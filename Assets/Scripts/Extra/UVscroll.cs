using UnityEngine;
using System.Collections;

public class UVscroll : MonoBehaviour {
	public Renderer water;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			water.material.mainTextureOffset = new Vector2(Time.time / 100, 0);
			water.material.SetTextureOffset("_DetailAlbedoMap", new Vector2(0, Time.time / 80));
	}
}
