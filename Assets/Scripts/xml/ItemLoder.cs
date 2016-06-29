//ref : http://wiki.unity3d.com/index.php?title=Saving_and_Loading_Data:_XmlSerializer

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class datafeild : MonoBehaviour {
	
	public double tweet_id;
	public string text;
	public DateTime time;
	public float geo_lat;
	public float geo_long;
	public string name;
	public string place;
	public string lang;
	public string description;
	public bool label;

	public bool Filter(string _filter_name){
		if(place.Equals(_filter_name)){
			return true;
		}else{
			return false;
		}
		if(lang.Equals(_filter_name)){
			return true;
		}else{
			return false;
		}
	}

}
public class ItemLoder : MonoBehaviour {

	public GameObject datapoint;
	public List<GameObject> datapoints = new List<GameObject>();
	public GameObject E_Mst;

	GameObject DPcontainer;
	int index, old_index, new_index;

	public void createItemsFromFile (String f_name) {

		 string path = "Assets/data/" + f_name;

		ItemContainer ic = ItemContainer.Load(path);
		Add_dp(ic);

	}

	public void Add_dp(ItemContainer ic){
			// DPcontainer = new GameObject();
			// DPcontainer.name = "dataPoints";
			print(ic.items.Count);
		for (int i = 0; i < ic.items.Count; i++){
			GameObject dp = (GameObject) Instantiate(datapoint, Vector3.zero, Quaternion.identity);
			dp.name = ""+i;
			dp.transform.SetParent(gameObject.transform);
			dp.AddComponent<datafeild>();
			dp.AddComponent<LatLong2XYZ>();
			datafeild field = dp.GetComponent<datafeild>();
			
			//@TODO : finde easier way to copy properties e.g) clone();
			field.name = ic.items[i].name;
			field.geo_lat = ic.items[i].geo_lat;
			field.geo_long = ic.items[i].geo_long;
			field.text = ic.items[i].text;
			field.description = ic.items[i].description;
			field.lang = ic.items[i].lang;
			field.place = ic.items[i].place;
		
			dp.GetComponent<LatLong2XYZ>().lat = field.geo_lat;
			dp.GetComponent<LatLong2XYZ>().lon = field.geo_long;
			datapoints.Add(dp);
			// print(ic.items[i].name + " cp ");
		}
	}
	public void Add_dp_with_label(ItemContainer ic){

		for (int i = 0; i < ic.items.Count; i++){
	
			GameObject dp = (GameObject) Instantiate(datapoint, Vector3.zero, Quaternion.identity);
			dp.name = ic.items[i].name;
			dp.transform.SetParent(gameObject.transform);
			dp.AddComponent<datafeild>();
			dp.AddComponent<LatLong2XYZ>();
			datafeild field = dp.GetComponent<datafeild>();
			
			//@TODO : finde easier way to copy properties e.g) clone();
			// field.name = ic.items[i].name;
			field.geo_lat = ic.items[i].geo_lat;
			field.geo_long = ic.items[i].geo_long;
			// field.text = ic.items[i].text;
			// field.description = ic.items[i].description;
			field.lang = ic.items[i].lang;
			field.place = ic.items[i].place;
			//
			dp.GetComponent<Dp_interaction>().user.text = ic.items[i].name;;
			dp.GetComponent<Dp_interaction>().ds.text = ic.items[i].description;
			dp.GetComponent<Dp_interaction>().text.text = ic.items[i].text;
			//
			dp.GetComponent<LatLong2XYZ>().lat = field.geo_lat;
			dp.GetComponent<LatLong2XYZ>().lon = field.geo_long;

			dp.GetComponentInChildren<Dp_interaction>().tweet_UI.GetComponent<ActiveStateToggler>().ToggleActive();
			datapoints.Add(dp);

		}
			// old_index = old_index + new_index;
	}	
	public void stream_index_2_zero () {
		index = 0;
	}
	public void dataClear(){
		foreach( GameObject g in datapoints){
			Destroy(g);
		}
		datapoints.Clear();
	}
}
