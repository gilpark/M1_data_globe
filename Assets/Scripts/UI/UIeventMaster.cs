using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public static class FilterMaster{
	public static bool user;
	public static bool tweet;
	public static bool lang;
}

public  class UIEventMaster : MonoBehaviour {

	public  bool user;
	public  bool tweet;
	public  bool lang;

	public Toggle p_user, p_tweet, p_lang;

	void Update(){

		user = p_user.isOn;
		tweet = p_tweet.isOn;
		lang = p_lang.isOn;

		FilterMaster.user = user;
		FilterMaster.tweet = tweet;
		FilterMaster.lang = lang;
	}
}
