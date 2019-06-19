using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedPlatformDash : MonoBehaviour
{
    public GameObject Muro;
    public Collider coll;
    public Animator anim;
    MovPlayer player;
    public GameObject col_1;
    
    bool startcounter;

    float counter;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerNull").GetComponent<MovPlayer>();
        
        anim.SetBool("Destroy", false);

        startcounter = false;

        counter = 0;
    }

    private void Update()
    {
        if (startcounter == true) counter += Time.deltaTime;
        if (counter >= 0.5f) Destroy(Muro);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (player.CanHitRun || player.CanHitCulo)
            {
                coll.enabled = false;
                anim.SetBool("Destroy", true);
                startcounter = true;
                Destroy(col_1);

                player.aud.clip = player.clips[3];
                player.aud.Play();
            }
        }
    }
}
