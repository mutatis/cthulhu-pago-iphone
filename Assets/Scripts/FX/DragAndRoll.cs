using UnityEngine;
using System.Collections;

public class DragAndRoll : MonoBehaviour
{
    bool isDragging;
    Vector3 lastPosition;
    Transform selectedTransform;

	// Update is called once per frame
	void Update ()
	{
        if (!isDragging)
            return;
        selectedTransform = ShoppingManager.shoppingManager.selectedOption.transform;
        if (selectedTransform.position.x > -20 && selectedTransform.position.x < 20)
        {
            //iTween.MoveUpdate(gameObject, iTween.Hash("x", Input.mousePosition.x - lastPosition.x)/50);
			iTween.MoveBy(selectedTransform.gameObject,iTween.Hash("x", (Input.mousePosition.x - lastPosition.x)/5));
            //selectedTransform.Translate((Input.mousePosition.x - lastPosition.x)/50,0,0);
        }
        lastPosition = Input.mousePosition;
	}

    void OnMouseDown ()
    {
        print ("OnMouseDown");
        isDragging = true;
        if (Input.touchCount > 0)
            lastPosition = Input.GetTouch(0).position;
        else
            lastPosition = Input.mousePosition;
    }
    void OnMouseUp ()
    {
        print ("OnMouseUp");
        isDragging = false;
    }
}
