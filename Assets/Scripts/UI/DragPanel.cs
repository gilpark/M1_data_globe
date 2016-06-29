using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DragPanel : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

    private Vector2 pointerOffset;
    public RectTransform canvasRectTransform;
    public RectTransform panelRectTransform;
    public Canvas boundingBox;
    public GameObject E_Master;

    bool mouse_down,mouse_drag;

    RectTransform boundBoxRectTransform;
    void Awake () {
        Canvas canvas = GetComponentInParent <Canvas>();
        boundBoxRectTransform = boundingBox.transform as RectTransform;
        if (canvas != null) {
            canvasRectTransform = canvas.transform as RectTransform;
            panelRectTransform = transform as RectTransform;
        }
    }
    // public void OnPointerExit (PointerEventData data) {
    //     mouse_down = false;
    //     mouse_drag = false;
    //     E_Master.GetComponent<UIEventMaster>().mouseOnUI = false;
    // }
    public void OnPointerUp (PointerEventData data) {
        mouse_down = false;
        mouse_drag = false;
        E_Master.GetComponent<UIEventMaster>().mouseOnUI = false;
    }

    public void OnPointerDown (PointerEventData data) {
        mouse_down = true;
        panelRectTransform.SetAsLastSibling ();
        RectTransformUtility.ScreenPointToLocalPointInRectangle (panelRectTransform, data.position, data.pressEventCamera, out pointerOffset);
    }

    public void OnDrag (PointerEventData data) {
        mouse_drag = true;
        if(mouse_drag && mouse_down){
            E_Master.GetComponent<UIEventMaster>().mouseOnUI = true;
        }
        if (panelRectTransform == null)
            return;

        Vector2 pointerPostion = ClampToWindow (data);
        // Vector2 pointerPostion = data.position;
        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle (
            canvasRectTransform, pointerPostion, data.pressEventCamera, out localPointerPosition
        )) {
            panelRectTransform.localPosition = localPointerPosition - pointerOffset;
        }
    }

    Vector2 ClampToWindow (PointerEventData data) {
        Vector2 rawPointerPosition = data.position;

        Vector3[] canvasCorners = new Vector3[4];
        boundBoxRectTransform.GetWorldCorners (canvasCorners);
        
        float clampedX = Mathf.Clamp (rawPointerPosition.x, canvasCorners[0].x, canvasCorners[2].x);
        float clampedY = Mathf.Clamp (rawPointerPosition.y, canvasCorners[0].y, canvasCorners[2].y);

        Vector2 newPointerPosition = new Vector2 (clampedX, clampedY);
        return newPointerPosition;
    }
}