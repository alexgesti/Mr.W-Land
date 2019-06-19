using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript: MonoBehaviour
{
    public static int scoreV = 0;
    public Text score_1;
    public Text score_2;

    void Update()
    {
        score_1.text = "X" + scoreV;
        score_2.text = "X" + scoreV;
    }
}
