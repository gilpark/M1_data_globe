using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.


public class small_circls_ani :  MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	public GameObject text;
	public bool clicked;

	public void OnPointerEnter (PointerEventData eventData){
		if(text.gameObject != null)
		text.gameObject.SetActive(true);
	}
	public void OnPointerExit(PointerEventData eventData){
		if(text.gameObject != null)
		text.gameObject.SetActive(false);

    }

    public void OnPointerClick(PointerEventData eventData){
    	print("clicked");
    	clicked = !clicked;
    }
    public void Clicked(){
        	clicked = !clicked;	
    }
}
