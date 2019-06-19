using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStop : MonoBehaviour
{
    PlayerHitTrigger playertrig;

    void Start()
    {
        playertrig = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHitTrigger>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
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
        }
    }
}
