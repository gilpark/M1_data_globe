using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
 // using UnityEngine.Events;
public class Xmls2DropDown : MonoBehaviour {
	DirectoryInfo info = new DirectoryInfo("Assets/data/");
	
	Dropdown dropdown;
	public GameObject E_Master;

	void Start(){
		dropdown = gameObject.GetComponent<Dropdown>();
		if(dropdown == null)print("@Loadxmls : dropdown is missing");
		readDir_createBtns ();
		dropdown.onValueChanged.AddListener(delegate { ItemClicked(dropdown);});
	}
	public void readDir_createBtns () {
		dropdown.options.Clear();
		 foreach (FileInfo f in info.GetFiles("*.xml")){
		 dropdown.options.Add (new Dropdown.OptionData() {text=f.Name});	
     	}
	}
	public void Close(){
		dropdown.options.Clear();
		ItemLoder iL  = E_Master.GetComponent<UIEventMaster>().dataLoder.GetComponent<ItemLoder>();

		if(iL.datapoints.Count !=0){
			foreach( GameObject g in iL.datapoints ){
				Destroy(g);
			}
			iL.datapoints.Clear();
		}
	}

	public void ItemClicked(Dropdown target){
		// print(dropdown.options[target.value].text);
		
		ItemLoder iL  = E_Master.GetComponent<UIEventMaster>().dataLoder.GetComponent<ItemLoder>();

		if(iL.datapoints.Count !=0){
			foreach( GameObject g in iL.datapoints ){
				Destroy(g);
			}
			iL.datapoints.Clear();
		}
		string filename = dropdown.options[target.value].text;
		iL.createItemsFromFile(filename);
	}
	
 }
