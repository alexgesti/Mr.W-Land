using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalMamaMia : MonoBehaviour
{
    AudioSource mamamia;

    float counter;

    bool onlyonetime;

    void Start()
    {
        mamamia = GetComponent<AudioSource>();

        onlyonetime = true;
    }

    void Update()
    {
        counter += Time.deltaTime;

        if (counter >= 4.3f && onlyonetime)
        {
            mamamia.Play();
            onlyonetime = false;
        }
    }
}
