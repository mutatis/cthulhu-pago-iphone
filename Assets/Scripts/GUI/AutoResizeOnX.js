#pragma strict
private var perfectProportion : float;
private var initialYProportion:float;
function Start ()
{
    perfectProportion = 3f/2f;
    initialYProportion = transform.localScale.y;
}

function Update ()
{
    var height:float = Screen.height;
    var width:float = Screen.width;

    var proportionalCorrection = (width/height)/perfectProportion;
    transform.localScale.y = proportionalCorrection*initialYProportion;
}
