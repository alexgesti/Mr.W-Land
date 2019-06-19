using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Intro : MonoBehaviour
{
    Transform character;
    Animator anim;
    Transform finalpoint;
    Transform title;
    Transform finalpointtitle;
    Transform menupoint;
    AudioSource WarioSound;
    public AudioClip clip_arh;
    public AudioClip clip_wow;
    AudioSource theme;
    GameObject Button;

    float counter;
    float counterPull;
    float counterPullOff;
    float counterWalkAgain;

    bool pull;
    bool pulloff;
    bool walkagain;

    void Start()
    {
        character = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        finalpoint = GameObject.Find("Suelo").GetComponent<Transform>();
        title = GameObject.Find("Title").GetComponent<Transform>();
        finalpointtitle = GameObject.Find("FinalPos_Title").GetComponent<Transform>();
        menupoint = GameObject.Find("Menu_Point").GetComponent<Transform>();
        WarioSound = GameObject.Find("Wario").GetComponent<AudioSource>();
        theme = GameObject.Find("Menu").GetComponent<AudioSource>();
        Button = GameObject.Find("Start");

        Button.SetActive(false);

        character.DOMoveX(finalpoint.position.x, 3).OnComplete(Pull).SetDelay(1);
    }

    void Update()
    {
        counter += Time.deltaTime;

        if (counter >= 1f && counter <= 1.2f) WarioSound.Play();

        if (pull) counterPull += Time.deltaTime;

        if (counterPull >= 2 && counterPull <= 2.2f)
        {
            anim.SetBool("IntroPullOff", true);
            anim.SetBool("IntroPulling", false);
            pulloff = true;

            title.DOMoveY(finalpointtitle.position.y, 1f).OnComplete(Title);
        }

        if (pulloff)
        {
            counterPullOff += Time.deltaTime;
            if (counterPullOff >= 1 && counterPullOff <= 1.1f)
            {
                anim.SetBool("IntroLookingUp", true);
                WarioSound.clip = clip_wow;
                WarioSound.Play();
                theme.Play();
            }
        }

        if (walkagain) counterWalkAgain += Time.deltaTime;

        if(counterWalkAgain >= 2 && counterWalkAgain <= 2.2f)
        {
            anim.SetBool("IntroWalkAgain", true);
            character.DOMoveX(finalpoint.position.x * 2.5f, 5);

            Button.SetActive(true);
        }
    }

    void Pull()
    {
        anim.SetBool("IntroPulling", true);
        pull = true;

        WarioSound.clip = clip_arh;
        WarioSound.Play();
    }

    void Title()
    {
        walkagain = true;
    }

    public void TitleMove()
    {
        title.DOMoveX(menupoint.position.x, 0.1f);
    }
}
