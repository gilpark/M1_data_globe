using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//store all boolean for events
public static class BoolMaster{

	public static bool user;
	public static bool tweet;
	public static bool lang;
}

public  class UIEventMaster : MonoBehaviour {
	//UI
	public GameObject canvas_e,
					  hover_e,
					  ui_panel_e,
					  ui_e,
					  filter_e,
					  data_e,
					  strea_e,
					  data_box,
					  lang_filter,
					  palce_filter;
	//data
	public GameObject dataLoder;
	public bool mouseOnUI;

	public void Data_e_Clicked(){
		data_box.gameObject.SetActive(!data_box.gameObject.active);
	}
}
