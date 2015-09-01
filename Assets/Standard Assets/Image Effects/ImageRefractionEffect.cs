using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Image Refraction")]
public class ImageRefractionEffect : SlinImageEffectBase
{
	bool isOn = false;

	void Start()
	{
		Time.timeScale = 1;
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			isOn = true;
		}
	}

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		if(isOn == false)
		NImageEffects.BlitWithMaterial(material, source, destination);
	}
}
