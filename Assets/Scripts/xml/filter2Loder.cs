using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class filter2Loder : MonoBehaviour {
	public GameObject Dataloader ;
	public string field;

	void Start () {
		 gameObject.GetComponent<Button>().onClick.AddListener (delegate {Send2Loder ();});
		 gameObject.transform.localScale = Vector3.one;
	}
	
	// Update is called once per frame
	void Send2Loder () {
		ItemLoder iL  = Dataloader.GetComponent<ItemLoder>();
		if(iL.datapoints.Count !=0){
			Text filter = gameObject.GetComponentInChildren<Text>();
			
			if(field.Equals("place")){
				foreach( GameObject g in iL.datapoints ){
					if(filter.text.Equals(g.GetComponent<datafeild>().place)){		
						// g.SetActive(true);
						// g.GetComponent<Dp_interaction>().ChangeColor(Color.red, Color.red);
						g.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
						g.GetComponent<Renderer>().material.color = Color.red;
					}
					
				}
			}
			
			if(field.Equals("lang")){
				foreach( GameObject g in iL.datapoints ){
					if(filter.text.Equals(g.GetComponent<datafeild>().lang)){
						// g.SetActive(true);
						// g.GetComponent<Dp_interaction>().ChangeColor(Color.red, Color.red);
						g.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
						g.GetComponent<Renderer>().material.color = Color.red;
					}	
				}
			}
			
			// Dataloader.GetComponent<ItemLoder>().datapoints.Clear();
		}

		// string filename = gameObject.GetComponentInChildren<Text>().text;
		// Dataloader.GetComponent<ItemLoder>().createItemsFromFile(filename);
	}

}
