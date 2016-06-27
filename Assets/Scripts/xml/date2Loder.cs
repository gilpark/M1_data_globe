using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class date2Loder : MonoBehaviour {
	public GameObject Dataloader;

	void Start () {
		 gameObject.GetComponent<Button>().onClick.AddListener (delegate {Send2Loder ();});
		 gameObject.transform.localScale = Vector3.one;
	}
	
	// Update is called once per frame
	void Send2Loder () {
		ItemLoder iL  = Dataloader.GetComponent<ItemLoder>();
		if(iL.datapoints.Count !=0){
			foreach( GameObject g in iL.datapoints ){
				Destroy(g);
			}
			Dataloader.GetComponent<ItemLoder>().datapoints.Clear();
		}

		string filename = gameObject.GetComponentInChildren<Text>().text;
		Dataloader.GetComponent<ItemLoder>().createItemsFromFile(filename);
	}
	
}
