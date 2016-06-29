using UnityEngine;
using System.Collections;

public class test_loder : MonoBehaviour {

	// Use this for initialization
	public GameObject E_Master;
	public string path;
	void Start () {
		ItemLoder iL  = E_Master.GetComponent<UIEventMaster>().dataLoder.GetComponent<ItemLoder>();

		if(iL.datapoints.Count !=0){
			print("asdf");
			foreach( GameObject g in iL.datapoints ){
				Destroy(g);
			}
			iL.datapoints.Clear();
		}
		// string filename = dropdown.options[target.value].text;
		iL.createItemsFromFile(path);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
