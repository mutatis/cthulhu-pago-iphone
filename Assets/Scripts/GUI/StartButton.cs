//  StartButton.cs
//   Author:
//       Yves J. Albuquerque <yves.albuquerque@gmail.com>
//  Last Update:
//       28-12-2013 

using UnityEngine;
using System.Collections;

/// <summary>
/// Waits any key was pressed and then call next scene
/// </summary>
public class StartButton : MonoBehaviour
{
    void OnMouseDown()
    {
        GameManager.gameManager.LoadNextLevel(Application.loadedLevel+1);
    }
}
