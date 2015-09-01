using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RectTween : MonoBehaviour
{
    public RectTransform origin;
    private Canvas screenCanvas;

    public void Start ()
    {
        screenCanvas = GameObject.Find("ScreenCanvas").GetComponent<Canvas>();
    }
    public void RectTweener ()
    {
        float centerX = (origin.anchorMin.x + origin.anchorMax.x)/2;
        float centerY = (origin.anchorMin.y + origin.anchorMax.y)/2;

        iTween.MoveTo(Camera.main.gameObject, iTween.Hash("position",new Vector3 ((centerX - 0.5f)*Screen.width,(centerY-0.5f)*Screen.height,Camera.main.transform.position.z),"time", 0.4f));
        iTween.ValueTo(gameObject, iTween.Hash("from",Camera.main.camera.orthographicSize,"to",origin.rect.width/2,"time", 0.4f,"onupdate","ChangeCameraSize"));
      //  FadeInShoppingBackground ();
    }
    
    public void ChangeCameraSize (float newValue)
    {
        Camera.main.camera.orthographicSize = newValue;
    }

    public void FadeInShoppingBackground ()
    {
       // screenCanvas.alpha = 1f;
    }
    
    
    public void ClickInBack ()
    {
      //  screenCanvas.alpha = 0f;
    }
    
}
