using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class Hover_area : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	public GameObject e;
	UIEventMaster e_Mst;

	void Start(){
		if(e == null){
			print("Hover_area : event master is missing");
		}
		e_Mst = e.GetComponent<UIEventMaster>();
	}

	//Do this when the cursor enters the rect area of this selectable UI object.
	public void OnPointerEnter (PointerEventData eventData) 
	{
		e_Mst.ui_panel_e.GetComponent<Main_panel_ani>().ON();
	}
	public void OnPointerExit(PointerEventData eventData)
    {
        // e_Mst.ui_panel_e.GetComponentInParent<Main_panel_ani>().ON();
     
    }
}
