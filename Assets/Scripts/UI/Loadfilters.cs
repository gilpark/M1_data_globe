using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
 // using UnityEngine.Events;
public class Loadfilters : MonoBehaviour {

	public GameObject bt_template;
	public GameObject DataLoder;
	public List<string> filter_names = new List<string>();

	List<GameObject> btns = new List<GameObject>();
	
	void Update(){
		if(DataLoder.GetComponent<ItemLoder>().datapoints.Count == 0){
			foreach(GameObject g in btns){
				Destroy(g);
			}
		}
	}

	public void createBtn(string name){
		bool unique = true;
		if(filter_names.Count!=0){
			foreach(string t in filter_names){
				if(t.Equals(name))unique = false;
			}

		}
		if(unique){
			filter_names.Add(name);
			GameObject b = Instantiate(bt_template);
	     	b.SetActive(true);
	     	b.transform.SetParent(bt_template.transform.parent);
	     	b.GetComponentInChildren<Text>().text = name;
	     	btns.Add(b);
		}	
	}
	public void Clear(){
		foreach (GameObject b in btns){
			Destroy(b);
		}
		btns.Clear();
		filter_names.Clear();
	}
}
