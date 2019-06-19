using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused;
    public GameObject pauseMenuUI;
    Animator anim_Fade;
    public Animator[] anim_Buttons;
    public AudioSource aud;
    public AudioSource aud2;
    public AudioClip[] clips_aud2;

    bool start;
    float counterStart;

    private void Start()
    {
        GameIsPaused = false;

        anim_Fade = GameObject.Find("FadeIn").GetComponent<Animator>();
    }

    public void WhatTimeIs()
    {
        if (GameIsPaused)
        {
            Resume();
            aud.UnPause();
            aud2.clip = clips_aud2[1];
            aud2.Play();
        }
        else
        {
            Pause();
            aud.Pause();
            aud2.clip = clips_aud2[0];
            aud2.Play();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        aud.UnPause();
        aud2.clip = clips_aud2[1];
        aud2.Play();
    }

    private void Update()
    {
        if (start) counterStart += Time.deltaTime;

        if (counterStart >= 2) SceneManager.LoadScene(1);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Resume();
    }

    public void ReturnMenu()
    {
        Time.timeScale = 1f;
        start = true;
        anim_Fade.SetBool("FadeOn", true);
        anim_Buttons[0].SetBool("FadeOn", true);
        anim_Buttons[1].SetBool("FadeOn", true);
    }
}
