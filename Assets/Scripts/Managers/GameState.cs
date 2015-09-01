using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class GameState
{
    public abstract void OnActivate();
    public abstract void OnDeactivate();
    public abstract void OnUpdate();
}
