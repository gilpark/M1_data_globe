using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button_random_color : MonoBehaviour {
// ColorHSV(float hueMin, float hueMax, float saturationMin, float saturationMax, float valueMin, float valueMax, float alphaMin, float alphaMax);

	// Use this for initialization
	Toggle tg;
	public GameObject filterBox;
	public Color main_on,main_off,highlight;
	private ColorBlock newcolor;
	private Text text;

	void Start () {
		tg = GetComponent<Toggle>();
		text = GetComponentInChildren<Text>();
		if(tg != null)
		newcolor = tg.colors;
		tg = gameObject.GetComponent<Toggle>();
		main_on = Random.ColorHSV(0.0f, 1.0f, 0.6f, 0.8f);
		main_off.a = 0.6f;
		main_off = Random.ColorHSV(0.0f, 1.0f, 0.6f, 0.8f);
		main_off.a = 0.6f;		
		// highlight = ColorHSV(0.0f, 1.0f, 7.5f, 8.5f);
		// highlight.a = 0.6f;
		newcolor.highlightedColor = highlight;

	}
	
	// Update is called once per frame
	void Update () {
		if(tg != null){
			if(tg.isOn)newcolor.normalColor = main_on;
			if(!tg.isOn)newcolor.normalColor = main_off;
			tg.colors = newcolor;
		}
		
	}

	public void SendColor_lang(){
		filterBox.GetComponent<Loadfilters>().FilterbyLang(text.text, main_on, main_off);
	}
	public void SendColor_place(){
		filterBox.GetComponent<Loadfilters>().FilterbyPlace(text.text, main_on, main_off);
	}
}
