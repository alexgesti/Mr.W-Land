using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Simple_Trigger : MonoBehaviour
{
    Enemy_Simple enemy;
    public GameObject Particle;
    PlayerHitTrigger playertrig;

    void Start()
    {
        enemy = GetComponentInParent<Enemy_Simple>();
        enemy.player = GameObject.FindGameObjectWithTag("PlayerNull").GetComponent<MovPlayer>();
        playertrig = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHitTrigger>();

        Particle.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.name == "KillFallTrigger")
        {
            if (enemy.player.CanHitCulo || enemy.player.CanHitRun || enemy.player.CanHitFall)
            {
                enemy.player.aud.clip = enemy.player.clips[2];
                enemy.player.aud.Play();

                enemy.move = false;
                enemy.Coll.enabled = false;

                enemy.anim.SetTrigger("Die");

                Particle.transform.position = this.transform.position;
                Particle.SetActive(true);

                enemy.CounterDieStart = true;
            }

            if (playertrig.player.CanHitRun == false && playertrig.player.CanHitCulo == false && playertrig.player.CanHitFall == false)
            {
                playertrig.pushbool = true;

                playertrig.player.aud.clip = playertrig.player.clips[1];
                playertrig.player.aud.Play();

                if (ScoreScript.scoreV > 0)
                {
                    ScoreScript.scoreV -= 100;
                    playertrig.particle.Play();
                }
            }

            if (other.gameObject.name == "KillFallTrigger")
            {
                if (enemy.player.CanHitFall)
                {
                    enemy.player.aud.clip = enemy.player.clips[2];
                    enemy.player.aud.Play();

                    enemy.move = false;
                    enemy.Coll.enabled = false;

                    enemy.anim.SetTrigger("Die");

                    Particle.transform.position = this.transform.position;
                    Particle.SetActive(true);

                    enemy.CounterDieStart = true;
                }
            }
        }
    }
}
