#pragma strict
var upState : Texture2D;
var downState : Texture2D;
private var comp : Component;
function Start () {
	comp = GetComponent(AnyResGUITexture);
}

function Update () {

	if(Input.touches.Length > 0){
		for (var touch : Touch in Input.touches) {
			if(touch.phase == TouchPhase.Began  && guiTexture.HitTest(touch.position)){
				comp.guiTexture.texture = downState;
			}
			else if(touch.phase == TouchPhase.Ended){
				comp.guiTexture.texture = upState;
			}
		}
	}
}