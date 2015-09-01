#pragma strict
@HideInInspector
var res : Vector2;  //The game window size in Unity
@HideInInspector
var rres : Vector2; //The actual device screen size
@HideInInspector
var x : float;      //res.x / rres.x
@HideInInspector
var y : float;		//res.y / rres.y
@HideInInspector
var g : GUIText; //The GUIText component

var FadeIn : boolean;

function Start(){
	g = GetComponent(GUIText);
	rres = Vector2(Screen.width,Screen.height);
	
	x = rres.x / res.x; 
	y = rres.y / res.y;
	g.fontSize *= x;
	
	g.pixelOffset.x *= x;
	g.pixelOffset.y *= y;
}
function Awake(){
	if(FadeIn){
		guiText.material.color.a = 0;
	}
}
function Update(){
	if(FadeIn){
		if(guiText.material.color.a < 1){
			guiText.material.color.a += Time.deltaTime * 0.6;
		}
	}
}