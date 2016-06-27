using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
 // using UnityEngine.Events;
public class Loadxmls : MonoBehaviour {
	DirectoryInfo info = new DirectoryInfo("Assets/data/");
	public GameObject bt_template;
	List<GameObject> btns = new List<GameObject>();

	void Start(){
		readDir_createBtns();
	}
	void readDir_createBtns () {
		btns.Clear();

		 foreach (FileInfo f in info.GetFiles("*.xml")){
         	GameObject b = Instantiate(bt_template);
         	b.SetActive(true);

         	b.transform.SetParent(bt_template.transform.parent);
         	b.GetComponentInChildren<Text>().text = f.Name;
         	btns.Add(b);
     	}
	}
	void Close(){
		btns.Clear();
	}

}
