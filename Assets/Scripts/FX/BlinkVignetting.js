#pragma strict
var vignette : Vignetting;
function Blink ()
{
	StartCoroutine(BlinkWhite());
}

function BlinkWhite()
{
	vignette.intensity = -300;
	yield WaitForSeconds(0.1f);
	vignette.intensity = 0;
}