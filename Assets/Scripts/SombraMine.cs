using UnityEngine;
using System.Collections;

public class SombraMine : MonoBehaviour 
{
	public Transform mine;
	float posY;
	public Rigidbody2D player;
	Vector3 scale;
	public Transform playerT;
	bool jump = true;
	int alpha = 154;
	public SpriteRenderer sprite;
	public float max;
	public float min;

	// Use this for initialization
	void Start () 
	{
		posY = PlayerStatus.playerStatus.sombraBomb.position.y;
		if(Application.loadedLevelName == "Lua")
		{
			transform.position = new Vector3(transform.position.x, transform.position.y, 5);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = new Vector3(mine.position.x, posY, transform.position.z);
		transform.eulerAngles = new Vector3(0, 0, 0);
		transform.position = new Vector3 (playerT.position.x, transform.position.y, transform.position.z);
		if(player.rigidbody2D.velocity.y > 0 && jump)
		{
			transform.localScale -= new Vector3(0.004f, 0.004f, 0.04f);
			sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - 0.0085f);
		}
		else if(player.rigidbody2D.velocity.y < 0 && jump)
		{
			transform.localScale += new Vector3(0.004f, 0.004f, 0.04f);
			sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a + 0.0085f);
		}
		if(transform.localScale.x < min)
		{
			transform.localScale = new Vector3(min, min, min);
			jump = false;
		}
		else if(transform.localScale.x > max)
		{
			transform.localScale = new Vector3(max, max, max);
			jump = false;
		}
		else
		{
			jump = true;
		}
	}
}
