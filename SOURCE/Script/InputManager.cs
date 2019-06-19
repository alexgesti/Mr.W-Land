using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    MovPlayer playercontroller;
    PauseMenu pause;

    public float sen = 3.0f;

    public Vector2 inputAxis = Vector2.zero;

    void Start()
    {
        playercontroller = GameObject.FindGameObjectWithTag("PlayerNull").GetComponent<MovPlayer>();
        pause = GameObject.Find("Canvas").GetComponent<PauseMenu>();
    }

    void Update()
    {
        //Mov. player
        inputAxis.x = Input.GetAxis("Horizontal");
        inputAxis.y = Input.GetAxis("Vertical");
        playercontroller.SetAxis(inputAxis);

        //Jump
        if (Input.GetButton("Jump")) playercontroller.ChangerJump();
        if (Input.GetButtonUp("Jump")) playercontroller.jump = false;

        //AtaqueEnCarrera
        if (Input.GetButtonDown("Attack")) playercontroller.StartDash = true;

        //Culazo
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("Vertical") == -1) playercontroller.StartCulazo = true;

        //Pause
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7)) pause.WhatTimeIs();

        /*//GMode
        if (Input.GetKeyDown(KeyCode.F10) || Input.GetKeyDown(KeyCode.JoystickButton6)) gmode.ChangeGMode();*/
    }
}
