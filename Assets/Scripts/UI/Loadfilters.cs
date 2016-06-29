using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
 // using UnityEngine.Events;
public class Loadfilters : MonoBehaviour {

	public GameObject lang_template,place_template;
	public GameObject DataLoder;
	public List<string> filter_place = new List<string>();
	public List<string> filter_lang = new List<string>();
	public List<GameObject> places = new List<GameObject>();
	public List<GameObject> langs = new List<GameObject>();	

	//shder
	// int _MKGlowColor, _Color, _MKGlowTexColor;

	public Toggle Label;
		// foreach(GameObject dp in DataLoder.GetComponent<ItemLoder>().datapoints ){
	public void Start(){

	}
	public void Creat(){
		foreach(GameObject dp in DataLoder.GetComponent<ItemLoder>().datapoints ){
			
			createBtn(place_template, dp.GetComponent<datafeild>().place, filter_place, places);
		    createBtn(lang_template, dp.GetComponent<datafeild>().lang, filter_lang, langs);

		}
	}

	public void createBtn(GameObject template, string name ,List<string> filter_names, List<GameObject> btns){
		bool unique = true;
		if(filter_names.Count!=0){
			foreach(string t in filter_names){
				if(t.Equals(name))unique = false;
			}

		}
		if(unique){
			filter_names.Add(name);
			GameObject b = Instantiate(template);
	     	b.SetActive(true);
	     	b.transform.SetParent(template.transform.parent);
	     	b.GetComponentInChildren<Text>().text = name;
	     	b.transform.localScale = Vector3.one;
	     	btns.Add(b);
		}	
	}
	public void Clear(){
		foreach (GameObject b in places){
			Destroy(b);
		}
		foreach (GameObject b in langs){
			Destroy(b);
		}
		filter_place.Clear();
		places.Clear();
		filter_lang.Clear();
		langs.Clear();
	}

	public void FilterbyLang(string name, Color main, Color highlitght){
		foreach(GameObject dp in DataLoder.GetComponent<ItemLoder>().datapoints ){
			if( dp.GetComponent<datafeild>().lang.Equals(name)){
				dp.GetComponent<Dp_interaction>().main = main;
				dp.GetComponent<Dp_interaction>().hightlight = highlitght;
				dp.GetComponent<Dp_interaction>().ChangeSize();
				dp.transform.localScale = new Vector3(0.12f,0.12f,0.12f);
				if(!dp.GetComponent<Dp_interaction>().filtered){
					dp.transform.localScale = new Vector3(0.06f,0.06f,0.06f); 
				}
			}
		}
	}
	public void FilterbyPlace(string name, Color main, Color highlitght){
		foreach(GameObject dp in DataLoder.GetComponent<ItemLoder>().datapoints ){
			if( dp.GetComponent<datafeild>().place.Equals(name)){
				dp.GetComponent<Dp_interaction>().main = main;
				dp.GetComponent<Dp_interaction>().hightlight = highlitght;
				dp.GetComponent<Dp_interaction>().ChangeSize();
				dp.transform.localScale = new Vector3(0.12f,0.12f,0.12f); 
				if(!dp.GetComponent<Dp_interaction>().filtered){
					dp.transform.localScale = new Vector3(0.03f,0.03f,0.03f); 
				}
			}
		}
	}	
	public void Togle_label(){
		foreach(GameObject dp in DataLoder.GetComponent<ItemLoder>().datapoints ){
			dp.GetComponent<Dp_interaction>().tweet_UI.GetComponent<ActiveStateToggler>().ToggleActive();
		}
	}

}
