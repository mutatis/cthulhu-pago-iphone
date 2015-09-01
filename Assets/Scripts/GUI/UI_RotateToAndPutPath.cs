using UnityEngine;
using System.Collections;

public class UI_RotateToAndPutPath : UI_PopOnEventBase
{
    public Vector3 to;
	public Vector3 to2;
    public Sprite pathMarker;
    public Sprite endPath;
    public Sprite endTarget;
    private bool cthulhuPlaceOnPath = false;
    private float proportionOfPath;
    private float propotionOfRotation;
    private float totalAngleToRotate;
    private float timer;
    private int pathNumber = 0;
    private Vector3 lastMarker = Vector3.zero;
	int x;
	int y;
    
	void Start()
	{
		transform.eulerAngles = new Vector3(18.2706f, -34.92065f, -16.03186f);
		if(GameManager.gameManager.to.Count <= 0)
		{
			y = 1;
		}
		else
		{
			y = GameManager.gameManager.to.Count;
		}
	}

    public override void OnDead ()
    {
        cthulhuPlaceOnPath = false;
		proportionOfPath = (PlayerPrefs.GetFloat("percorreuS") + PlayerStatus.playerStatus.transform.position.x)/(MissionManager.missionManager.limit * y);
        totalAngleToRotate = Vector3.Angle(transform.localEulerAngles, to);
        timer = Time.realtimeSinceStartup;
		iTween.RotateTo (gameObject, iTween.Hash("rotation", GameManager.gameManager.to[x], "speed", 12,"easetype", "Linear", "onupdate", "SetMarkers", "oncomplete", "SetTarget", "ignoretimescale",true));
		StartCoroutine("Go");
		x++;
    }

	IEnumerator Go()
	{
		System.DateTime timeToShowNextElement = System.DateTime.Now.AddSeconds(20);
		while (System.DateTime.Now < timeToShowNextElement)
		{
			yield return null;
		}
		iTween.RotateTo (gameObject, iTween.Hash("rotation", GameManager.gameManager.to[x], "speed", 12,"easetype", "Linear", "onupdate", "SetMarkers", "oncomplete", "SetTarget", "ignoretimescale",true));
		if(GameManager.gameManager.to.Count <= x)
		{
			x ++;
		}
		StartCoroutine("Go");
	}
    
	void Update()
	{

	}

    public override void OnPause ()
    {
    }
    
    public override void OnResume ()
    {
    }
    
    /// <summary>
    /// Sets the markers between the start and the end of the path.
    /// </summary>
    void SetMarkers ()
    {
        GameObject pathMarkerObject;
        SpriteRenderer spriteRenderer;
 
        if (cthulhuPlaceOnPath)
            return;

        if ((Time.realtimeSinceStartup - timer) < 0.6)
            return;

        timer = Time.realtimeSinceStartup;
        lastMarker = transform.localEulerAngles;
        pathNumber ++;
        pathMarkerObject = new GameObject("pathMarkerObject"+pathNumber.ToString(), typeof(SpriteRenderer));
        spriteRenderer = pathMarkerObject.GetComponent <SpriteRenderer>();
        if ((totalAngleToRotate-Vector3.Angle(transform.localEulerAngles, to))/totalAngleToRotate > proportionOfPath)//campares if how the proportion between how much it has rotated and how much will be rotated and the proportion between how much cthulhu has moved
        {
            spriteRenderer.sprite = endPath;
            cthulhuPlaceOnPath = true;
        }
        else
            spriteRenderer.sprite = pathMarker;
        TraceImageToGlobeCenter (pathMarkerObject.transform);
    }

    /// <summary>
    /// Sets the target marker at the end of mission.
    /// </summary>
    void SetTarget ()
    {
        GameObject endTargetObject = new GameObject("EndTarget", typeof(SpriteRenderer));
        SpriteRenderer spriteRenderer = endTargetObject.GetComponent <SpriteRenderer>();
		spriteRenderer.sprite = endTarget;
		TraceImageToGlobeCenter (endTargetObject.transform);
    }

    /// <summary>
    /// Traces the image to globe center.
    /// </summary>
    /// <param name="markerTransform">Marker transform.</param>
    void TraceImageToGlobeCenter (Transform markerTransform)
    {
        Vector3 screenPos;
        RaycastHit hitInfo;
        Ray ray;
        screenPos = Camera.main.WorldToScreenPoint (transform.position);
        hitInfo = new RaycastHit();
        ray = Camera.main.ScreenPointToRay (screenPos);
        collider.Raycast (ray,out hitInfo, 10.0f);
        markerTransform.position = hitInfo.point;
        markerTransform.parent = transform;
    }
    /*IEnumerator WaitSec(float howMuch)
    {
        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < start + howMuch)
            yield return null;
    }*/
}
