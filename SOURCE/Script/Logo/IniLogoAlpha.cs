using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class IniLogoAlpha : MonoBehaviour
{
    public int num;

    float counter;
    float counterduck;

    Transform FinalPos;
    Image alphaBlack;
    RectTransform duck;
    Animator title;
    AudioSource aud;

    bool start;
    bool onlyOneTime;

    void Start()
    {
        FinalPos = GameObject.Find("DuckPoint").GetComponent<Transform>();
        alphaBlack = GetComponent<Image>();
        duck = GameObject.Find("Duck").GetComponent<RectTransform>();
        title = GameObject.Find("Nombre").GetComponent<Animator>();
        aud = GetComponent<AudioSource>();

        counter = 0;
        counterduck = 0;

        title.enabled = false;
        aud.Stop();

        start = false;
        onlyOneTime = true;

        alphaBlack.DOColor(new Color(alphaBlack.color.r, alphaBlack.color.g, alphaBlack.color.b, 0), 1.5f).OnComplete(PAnimStart);
    }

    private void Update()
    {
        if (start)
        {
            title.enabled = true;
            counter += Time.deltaTime;
        }

        if (counter >= 0.2f && onlyOneTime)
        {
            aud.Play();

            onlyOneTime = false;
        }

        if (counter >= 0.5f)
        {
            DuckAnim();
        }
    }

    void PAnimStart()
    {
        start = true;
    }
    
    void DuckAnim()
    {
        duck.DOMoveX(FinalPos.position.x, 0.75f).OnComplete(BlackScreen).SetDelay(1);
    }

    void BlackScreen()
    {
        alphaBlack.DOColor(new Color(alphaBlack.color.r, alphaBlack.color.g, alphaBlack.color.b, 1), 1.5f).OnComplete(ChangeScene).SetDelay(3);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(num);
    }
}
