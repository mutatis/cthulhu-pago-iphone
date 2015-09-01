using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUIText))]
public class UI_ScrollingText: UI_PopOnEventBase
{
    public string[] messages;
    ScrollingType scrollingType;
    float scrollX;
    private bool on = false;

    public override void Start ()
	{
		originalColor = guiText.color;
	}

    void Update ()
    {
        if (!on)
            return;
        transform.position = new Vector3 (scrollX, transform.position.y, transform.position.z);
    }

    public override void OnDead ()
	{
        on = true;
        originalColor.a = 1f;
        guiText.color = originalColor;
        ChangeMessage ();
	}

    public override void OnPause ()
    {
        on = true;
        originalColor.a = 1f;
        guiText.color = originalColor;
        ChangeMessage ();
    }

    public override void OnResume ()
    {
        on = false;
        iTween.Stop(gameObject);
        originalColor.a = 0f;
        guiText.color = originalColor;
    }

    IEnumerator DisplayMessage ()
    {

        switch(scrollingType)
        {
            case ScrollingType.SCROLL:
            {
                scrollX = 1;
                iTween.ValueTo(gameObject, iTween.Hash("from", scrollX, "to", -1, "time", 8, "onupdate", "SetScrollXValue", "oncomplete", "ChangeMessage", "ignoretimescale",true));
                break;
            }
            case ScrollingType.SCROLLANDBLINK:
            {
                scrollX = 1;
                iTween.ValueTo(gameObject, iTween.Hash("from", scrollX, "to", 0, "time", 4, "onupdate", "SetScrollXValue", "ignoretimescale",true));
                yield return StartCoroutine("WaitSec", 4);
                iTween.ColorTo(gameObject, iTween.Hash("a", 0, "time", 0.3f, "looptype", "pingPong", "ignoretimescale",true)); 
                yield return StartCoroutine("WaitSec", 4);
                iTween.Stop(gameObject);
                iTween.ColorTo(gameObject, iTween.Hash("a", 1, "time", 0.2f, "oncomplete", "ChangeMessage", "ignoretimescale",true)); 
                break;
            }
            case ScrollingType.BLINK:
            {
                guiText.color = new Color (guiText.color.r,guiText.color.g,guiText.color.b,1); 

                iTween.ColorTo(gameObject, iTween.Hash("a", 0, "time", 0.3f, "looptype", "pingPong", "ignoretimescale",true)); 
                yield return StartCoroutine("WaitSec", 4);
                iTween.Stop(gameObject);
                iTween.ColorTo(gameObject, iTween.Hash("a", 1, "time", 0.2f, "oncomplete", "ChangeMessage", "ignoretimescale",true)); 
                break;
            }
        }
    }

    void SetScrollXValue (float newValue)
    {
        scrollX = newValue;
    }

    void ChangeMessage ()
    {
        scrollingType = (ScrollingType)Random.Range(0,3); //working
        guiText.text = messages [Random.Range(0, messages.Length)];//working
        StartCoroutine("DisplayMessage");
    }

    IEnumerator WaitSec(float howMuch)
    {
        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < start + howMuch)
            yield return null;
    }
}

public enum ScrollingType
{
    SCROLL = 0,
    SCROLLANDBLINK = 1,
    BLINK = 2
}