using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;// Required when using Event data.

public class Main_panel_ani : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {


	public GameObject st,dt,target;
	public float timeout = 5.0f;
	float timer;
	bool pointerIn;
	public void Start(){
		target.transform.position = st.transform.position;
	}
	void Update(){

		
	}
	public void ON(){
		iTween.MoveTo(target,iTween.Hash("position", dt.transform.position, "easeType", "easeInOutExpo", "delay", .1));
	}
	public void OFF(){
		iTween.MoveTo(target,iTween.Hash("position", st.transform.position, "easeType", "easeInOutExpo", "delay", .1));

	}
	public void OnPointerEnter (PointerEventData eventData){
     	pointerIn = true;
	}
	public void OnPointerExit(PointerEventData eventData){
     	pointerIn = false;
    }
}
