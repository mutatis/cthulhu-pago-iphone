using UnityEngine;
using System.Collections;

public class UI_PopOnEventBase : MonoBehaviour
{
    public GUIType guiType;

    protected Color originalColor;
    protected string notificationEvent;

    void Awake ()
    {
        switch(guiType)
        {
            case GUIType.ONPAUSE:
            {  
                notificationEvent = "OnPause";
                break;
            }
            case GUIType.ONDEAD:
            {
                notificationEvent = "OnDead";
                break;
            }
        }
        
        NotificationCenter.DefaultCenter().AddObserver(this, notificationEvent);
        NotificationCenter.DefaultCenter().AddObserver(this, "OnResume");
    }

    public virtual void Start ()
    {
        originalColor = renderer.material.color;
    }

    public virtual void OnDead ()
    {

        originalColor.a = 1f;
        renderer.material.color = originalColor;
    }
    
    public virtual void OnPause ()
    {
        originalColor.a = 1f;
        renderer.material.color = originalColor;
    }
    
    public virtual void OnResume ()
    {
        originalColor.a = 0f;
        renderer.material.color = originalColor;
    }
}

public enum GUIType
{
    ONPAUSE,
    ONDEAD
}