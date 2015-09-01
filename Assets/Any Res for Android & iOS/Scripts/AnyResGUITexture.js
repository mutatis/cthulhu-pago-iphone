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
var g : GUITexture; //The GUITexture component

var FadeIn : boolean;

function Start(){
	g = GetComponent(GUITexture);
	rres = Vector2(Screen.width,Screen.height);
	
	x = rres.x / res.x; 
	y = rres.y / res.y;
	g.pixelInset.width *= x; g.pixelInset.height *= x;
	g.pixelInset.x *= x; 
	g.pixelInset.y *= y;
}
function Awake(){
	if(FadeIn){
		guiTexture.color.a = 0;
	}
}
function Update(){
	if(FadeIn){
		if(guiTexture.color.a < 1){
			guiTexture.color.a += Time.deltaTime * 0.6;
		}
	}
}