using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitTrigger : MonoBehaviour
{
    public MovPlayer player;
    public ParticleSystem particle;
    public bool pushbool;

    Transform respawn_1;
    Transform respawn_2;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerNull").GetComponent<MovPlayer>();
        pushbool = false;

        respawn_1 = GameObject.Find("Respawn_1").GetComponent<Transform>();
        respawn_2 = GameObject.Find("Respawn_2").GetComponent<Transform>();

        particle.Stop();
    }

    private void Update()
    {
        if (pushbool == false) particle.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bala")
            if (player.CanHitRun == false && player.CanHitCulo == false && player.CanHitFall == false)
            {
                pushbool = true;

                player.aud.clip = player.clips[1];
                player.aud.Play();

                if (ScoreScript.scoreV > 0)
                {
                    ScoreScript.scoreV -= 100;
                    particle.Play();
                }
            }

        if (other.gameObject.name == "ResetPlayer_1") player.transform.position = respawn_1.position;
        if (other.gameObject.name == "ResetPlayer_2") player.transform.position = respawn_2.position;
    }
}
