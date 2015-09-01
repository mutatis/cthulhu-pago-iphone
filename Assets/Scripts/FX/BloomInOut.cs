using UnityEngine;
using System.Collections;

public class BloomInOut : MonoBehaviour
{
    FastBloom fastBloom;
    public float amount = 0.4f;
    public float time = 5;
	// Use this for initialization
	void Start ()
    {
        fastBloom = GetComponent<FastBloom>();
        BloomIn();
	}
    
    void BloomIn ()
    {
        iTween.ValueTo(gameObject,iTween.Hash("from", 0f, "to", amount, "time", time, "onupdate","ChangeBloom", "oncomplete","BloomOut"));
    }
    void BloomOut ()
    {
        iTween.ValueTo(gameObject,iTween.Hash("from", amount, "to", 0f, "time", time, "onupdate","ChangeBloom", "oncomplete","BloomIn"));

    }
    void ChangeBloom (float my_Value)
    {
        fastBloom.intensity = my_Value;
    }
}
