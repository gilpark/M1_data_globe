//ref : http://wiki.unity3d.com/index.php?title=Saving_and_Loading_Data:_XmlSerializer

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class _clonedItem : MonoBehaviour {
	public float geo_lat;
	public float geo_long;
	public string name;
	public string text;
}
public class ItemLoder : MonoBehaviour {

	public const string path = "Assets/data/dummy.xml";
	
	public GameObject dp_prefab;
	public List<GameObject> Datapoints = new List<GameObject>();

	void Start () {
		ItemContainer ic = ItemContainer.Load(path);

		for (int i = 0; i < ic.items.Count; i++){
			GameObject dp = (GameObject) Instantiate(dp_prefab, Vector3.zero, Quaternion.identity);
			dp.name = "tweet-"+i;
			dp.transform.parent = transform;
			dp.AddComponent<_clonedItem>();
			dp.AddComponent<LatLong2XYZ>();
			dp.AddComponent<send2UI>();
			_clonedItem cp = dp.GetComponent<_clonedItem>();
			
			//@TODO : finde easier way to copy properties e.g) clone();
			cp.name = ic.items[i].name;
			cp.geo_lat = ic.items[i].geo_lat;
			cp.geo_long = ic.items[i].geo_long;
			cp.text = ic.items[i].text;

			dp.GetComponent<LatLong2XYZ>().lat = cp.geo_lat;
			dp.GetComponent<LatLong2XYZ>().lon = cp.geo_long;
			Datapoints.Add(dp);
			// print(ic.items[i].name + " cp ");
		}
	}
	
	void Update () {
	
	}
}
