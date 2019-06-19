using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCanKillFall : MonoBehaviour
{
    BoxCollider coll;
    MovPlayer player;

    void Start()
    {
        coll = GetComponent<BoxCollider>();
        player = GameObject.FindGameObjectWithTag("PlayerNull").GetComponent<MovPlayer>();
    }

    void Update()
    {
        if (player.CanHitFall == false) coll.enabled = false;
        else if (player.CanHitFall && player.startcoll == false) coll.enabled = true;
    }
}
