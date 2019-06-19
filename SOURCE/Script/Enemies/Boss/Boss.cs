using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    Transform bos;
    SpriteRenderer bosrender;
    MovPlayer player;
    Collider Coll;
    Collider Trigger;
    Animator anim;

    //Patron Ataque
    Bullet bullet;

    //Patron Posicion
    bool moveup;
    float counterWait;
    Vector3 position_1;
    Vector3 position_1_teleport;
    Vector3 position_2;
    Vector3 position_2_teleport;

    //Lifes
    float Vida;
    float counterdead;
    Animator fade;
    public AudioMixer aud;

    //Particulas
    public GameObject particle;

    void Start()
    {
        bos = GameObject.Find("Boss").GetComponent<Transform>();
        bosrender = GameObject.Find("Boss").GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("PlayerNull").GetComponent<MovPlayer>();
        Coll = GameObject.Find("Boss").GetComponent<Collider>();
        Trigger = GetComponent<Collider>();
        anim = GameObject.Find("Boss").GetComponent<Animator>();
        bullet = GameObject.Find("Bala").GetComponent<Bullet>();
        fade = GameObject.Find("FadeIn").GetComponent<Animator>();

        position_1 = new Vector3(30.38f, -11.41f, 0);
        position_1_teleport = new Vector3(30.38f, -18.14f, 0);
        position_2 = new Vector3(42.12f, -11.41f, 0);
        position_2_teleport = new Vector3(42.12f, -18.14f, 0);

        moveup = false;

        Vida = 3;

        particle.SetActive(false);
    }

    void Update()
    {
        //MovementLogic
        if (!moveup) counterWait += Time.deltaTime;

        if (bos.position.y >= position_1_teleport.y && bos.position.x == position_1.x && counterWait >= 10)
        {
            bos.position -= new Vector3(0, 5f * Time.deltaTime, 0);
            if (bos.position.y <= position_1_teleport.y)
            {
                bos.position = position_2_teleport + new Vector3 (0, 1, 0);
                bos.localRotation = Quaternion.Euler(0, 180, 0);
                counterWait = 0;
                moveup = true;
                bullet.speed = -bullet.speed;
                Coll.enabled = true;
                Trigger.enabled = true;
                anim.SetBool("Die", false);
            }
        }

        if (bos.position.y > position_2_teleport.y && bos.position.x == position_2.x && counterWait >= 10)
        {
            bos.position -= new Vector3(0, 5f * Time.deltaTime, 0);
            if (bos.position.y <= position_2_teleport.y)
            {
                bos.position = position_1_teleport + new Vector3(0, 1, 0);
                bos.localRotation = Quaternion.Euler(0, 0, 0);
                counterWait = 0;
                moveup = true;
                bullet.speed = -bullet.speed;
                Coll.enabled = true;
                Trigger.enabled = true;
                anim.SetBool("Die", false);
            }
        }

        if (moveup)
        {
            bos.position += new Vector3(0, 5f * Time.deltaTime, 0);
            if (bos.position.y >= position_1.y + 0.3f || bos.position.y >= position_2.y + 0.3f) moveup = false;
        }

        //Shot logic
        if (counterWait >= 6 && counterWait <= 6.2f)
        {
            bullet.shot = true;
            anim.SetBool("Attack", true);
        }
        else anim.SetBool("Attack", false);

        if (Vida == 0)
        {
            particle.SetActive(true);
            counterWait = 0;
            bos.position -= new Vector3(0, 2f * Time.deltaTime, 0);
            counterdead += Time.deltaTime;
            
            if (counterdead >= 5)
            {
                fade.SetBool("FadeOn", true);
                aud.DOSetFloat("Volume", 0, 1);
            }

            if (counterdead >= 7) SceneManager.LoadScene(3);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (player.CanHitCulo)
            {
                player.aud.clip = player.clips[2];
                player.aud.Play();

                Coll.enabled = false;
                Trigger.enabled = false;

                bosrender.color = Color.red;
                bosrender.DOColor(Color.white, 1);

                anim.SetBool("Die", true);

                Vida -= 1;

                counterWait = 10;
            }
        }
    }
}
