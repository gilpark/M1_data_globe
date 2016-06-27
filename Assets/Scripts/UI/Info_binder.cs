using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Info_binder : MonoBehaviour {

	public Text user;
	public Text tweet;
	public Text decription;
	
	public void callInfo () {
			user.text = gameObject.GetComponent<datafeild>().name;
			tweet.text = gameObject.GetComponent<datafeild>().text;
			decription.text = gameObject.GetComponent<datafeild>().description;

	}
	
}
