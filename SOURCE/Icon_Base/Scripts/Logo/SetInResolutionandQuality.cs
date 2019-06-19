using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInResolutionandQuality : MonoBehaviour {

    private void Awake()
    {
        Screen.SetResolution(1280, 720, true);
        QualitySettings.SetQualityLevel(3, true);
    }
}
