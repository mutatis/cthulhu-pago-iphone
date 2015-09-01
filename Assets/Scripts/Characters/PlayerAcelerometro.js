#pragma strict

var speed = 50;
var virar = false;

function Start () 
{

}

function Update () 
{
	var dir : Vector2 = Vector2.zero;
	
	dir.y = (Input.acceleration.y * 4.5);
	
	dir.x = Input.acceleration.x * 4.5f;
		
	if(dir.sqrMagnitude > 1)
	{
		dir.Normalize();
		virar = true;
	}
	
	dir *= Time.deltaTime;
	
	transform.position += dir * speed;
}