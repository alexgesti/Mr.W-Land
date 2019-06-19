using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins_Logic : MonoBehaviour
{
    SpriteRenderer rend;
    CapsuleCollider coll;
    public GameObject particle;
    AudioSource aud;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        coll = GetComponent<CapsuleCollider>();
        aud = GetComponent<AudioSource>();

        particle.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScoreScript.scoreV += 100;
            rend.enabled = false;
            coll.enabled = false;
            aud.Play();
            particle.SetActive(true);
        }
    }
}
