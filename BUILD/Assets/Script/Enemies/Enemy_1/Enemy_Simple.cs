using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Simple : MonoBehaviour
{
    public MovPlayer player;
    public Collider Coll;
    public Transform[] Vuelta;


    public float speed;
    public float a;
    float CounterDie;

    public bool move;
    bool hit;
    public bool CounterDieStart;

    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Coll = GetComponent<Collider>();

        hit = false;
        move = true;
        CounterDieStart = false;

        CounterDie = 0;
    }

    void Update ()
    {
        if (Vuelta[1] != null || Vuelta[2] != null)
        {
            if (transform.position.x <= Vuelta[0].position.x ||
                transform.position.x >= Vuelta[1].position.x ||
                transform.position.x >= Vuelta[2].position.x ||
                transform.position.x >= Vuelta[3].position.x)
            {
                speed = -speed;
                a = -a;
            }
        }

        if (Vuelta[1] == null)
        {
            if (transform.position.x <= Vuelta[0].position.x ||
                transform.position.x >= Vuelta[2].position.x ||
                transform.position.x >= Vuelta[3].position.x)
            {
                speed = -speed;
                a = -a;
            }
        }

        if (Vuelta[2] == null)
        {
            if (transform.position.x <= Vuelta[0].position.x ||
                transform.position.x >= Vuelta[3].position.x)
            {
                speed = -speed;
                a = -a;
            }
        }

        if (transform.position.x <= Vuelta[0].position.x) transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);

        if (transform.position.x >= Vuelta[1].position.x ||
            transform.position.x >= Vuelta[2].position.x ||
            transform.position.x >= Vuelta[3].position.x)
            transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);

        anim.SetFloat("Walk", a);

        if (move == true) transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        if (CounterDieStart) CounterDie += Time.deltaTime;

        if (CounterDie >= 0.5f) Destroy(this.gameObject);
    }
}
