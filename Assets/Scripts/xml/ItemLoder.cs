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

}
public class ItemLoder : MonoBehaviour {

	// public string path = "Assets/data/";
	
	public GameObject datapoint;
	public List<GameObject> datapoints = new List<GameObject>();
	public GameObject place, lang;

	GameObject DPcontainer;

	public void createItemsFromFile (String f_name) {

		 string path = "Assets/data/" + f_name;

		ItemContainer ic = ItemContainer.Load(path);
		Add_dp(ic);

	}

	public void Add_dp(ItemContainer ic){
			DPcontainer = new GameObject();
			DPcontainer.name = "dataPoints";

		for (int i = 0; i < ic.items.Count; i++){
			GameObject dp = (GameObject) Instantiate(datapoint, Vector3.zero, Quaternion.identity);
			dp.name = ""+i;
			dp.transform.SetParent(DPcontainer.transform);
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
			
			if(place != null && field.place != null)place.GetComponent<Loadfilters>().createBtn(field.place);
			if(lang != null && field.lang != null)lang.GetComponent<Loadfilters>().createBtn(field.lang);
			//
			dp.GetComponent<LatLong2XYZ>().lat = field.geo_lat;
			dp.GetComponent<LatLong2XYZ>().lon = field.geo_long;
			datapoints.Add(dp);
			// print(ic.items[i].name + " cp ");
		}
	}
	
	void Update () {
	
	}
}
