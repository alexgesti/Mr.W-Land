using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qualityOptions : MonoBehaviour {

	public void Fast()
    {
        QualitySettings.SetQualityLevel(2, true);
        Debug.Log("Fast");
    }

    public void Good()
    {
        QualitySettings.SetQualityLevel(3, true);
        Debug.Log("Good");
    }

    public void Fantastic()
    {
        QualitySettings.SetQualityLevel(4, true);
        Debug.Log("Fantastic");
    }

    public void Ultra()
    {
        QualitySettings.SetQualityLevel(5, true);
        Debug.Log("Ultra");
    }
}
