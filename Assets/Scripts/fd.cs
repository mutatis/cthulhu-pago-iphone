using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Canvas))]
[ExecuteInEditMode]
public class fd : MonoBehaviour
{
	[SerializeField]
	[Tooltip("Reference resolution (for which resolution was GUI made).")]
	private Vector2 _ReferenceResolution = new Vector2(800, 600);
	
	[SerializeField]
	[Tooltip("Scale of reference gui. Use it in order to make GUI bigger / smaller.")]
	private float _GuiScale = 1.0f;
	
	/// Controlled canvas.
	private Canvas _Canvas;
	
	/// Scale of reference gui. Use it in order to make GUI bigger / smaller.
	public float GuiScale
	{
		get { return _GuiScale; }
		set { _GuiScale = value; ScaleUpdate(); }
	}
	
	
	
	protected void Awake()
	{
		_Canvas = GetComponent<Canvas>();
	}
	
	protected void Start()
	{
		//ScreenManager.Get().OnScreenSizeChanged += SetNewResolution;
		SetNewResolution(Screen.width, Screen.height);
	}
	
	
	#if UNITY_EDITOR
	
	protected void Update()
	{
		if(!Application.isPlaying)
		{
			_Canvas = GetComponent<Canvas>();
			ScaleUpdate();
		}
	}
	
	#endif
	
	protected void SetNewResolution(int width, int height)
	{
		ScaleUpdate();
	}
	
	protected void ScaleUpdate()
	{
		float width = (float)Screen.width;
		float height = (float)Screen.height;
		
		float widthScale = width / _ReferenceResolution.x;
		float heightScale = height / _ReferenceResolution.y;
		
		_Canvas.scaleFactor = Mathf.Min(widthScale, heightScale) * GuiScale;
	}
	
}