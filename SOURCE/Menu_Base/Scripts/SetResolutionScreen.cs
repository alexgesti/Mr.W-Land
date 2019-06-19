using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetResolutionScreen : MonoBehaviour
{
    public void ResolutionDefault()
    {
        Screen.SetResolution(1280, 720, true);
        Debug.Log("1280x720");
    }

    public void Resolution1600()
    {
        Screen.SetResolution(1600, 1200, true);
        Debug.Log("1600x1200");
    }

    public void Resolution1920()
    {
        Screen.SetResolution(1920, 1080, true);
        Debug.Log("1920x1080");
    }
}
