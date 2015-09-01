using UnityEngine;
using System.Collections;

public class Awesome : MonoBehaviour
{
	public void Click()
	{
		transform.position = new Vector2 (transform.position.x + Random.Range (-200, 200), transform.position.y + Random.Range (-200, 200));
	}
}
