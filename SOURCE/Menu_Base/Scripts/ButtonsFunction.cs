using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using DG.Tweening;

public class ButtonsFunction : MonoBehaviour
{
    Animator anim_Fade;
    public Animator[] anim_Buttons;
    public AudioMixer aud;

    bool start;
    float counterStart;
    int num;

    void Start()
    {
        anim_Fade = GameObject.Find("FadeIn").GetComponent<Animator>();

        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (start) counterStart += Time.deltaTime;

        if (counterStart >= 2) SceneManager.LoadScene(num);
    }

    public void LoadScene(int num_scene)
    {
        start = true;
        anim_Fade.SetBool("FadeOn", true);
        anim_Buttons[0].SetBool("FadeOn", true);
        anim_Buttons[1].SetBool("FadeOn", true);
        anim_Buttons[2].SetBool("FadeOn", true);
        num = num_scene;
        aud.DOSetFloat("Volume", 0, 1);
    }

    public void LoadSceneMenu(int num_menu)
    {
        num = num_menu;
        start = true;
        anim_Fade.SetBool("FadeOn", true);
        anim_Buttons[0].SetBool("FadeOn", true);
        anim_Buttons[1].SetBool("FadeOn", true);
        aud.DOSetFloat("Volume", 0, 1);
    }

    public void ExitGame()
    {
        Debug.Log("Exit game");
        Application.Quit();
    }

}
