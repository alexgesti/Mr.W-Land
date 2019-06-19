using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MovPlayer : MonoBehaviour 
{
    //Movement Controles/Movement Valores
	public CharacterController controller;
    public float speed;
    public float Inispeed;
    Vector2 axis;
    Vector3 moveDirection;
    Vector3 transformDir;
    Transform playermodel;
    Transform playercontroller;

    //Ground/Fly Physics Control
    float forceToGround = Physics.gravity.y;
    public float gravitymagnitude;
    public float gravityFall;
    public float Inigravitymagnitude;
    public float InigravityFall;
    public float jumpSpeed;
    public float InijumpSpeed;
    float jumpcounter;
    float jumpanimcounter;
    public bool jump;
    bool canjump;
    public bool CanHitFall;

    //AtaqueEnCarrera Logic
    float counterDash;
    public float DashForce;
    public float IniDashForce;
    public bool StartDash;
    public bool CanHitRun;

    //Culazo Logic
    public float counterCulazo;
    public float CulazoForceFall;
    public float CulazoForcemagnitude;
    public float IniCulazoForceFall;
    public float IniCulazoForcemagnitude;
    public bool StartCulazo;
    public bool CanHitCulo;

    //Hit Logic
    PlayerHitTrigger playertrigger;
    Collider modelColl;
    Collider HitColl;
    SpriteRenderer sprite;
    public float force;
    float pushcounter;
    public bool startcoll;
    float collcounter;

    //Anim
    Animator anim;

    //Sounds
    public AudioSource aud;
    public AudioClip[] clips;

    void Start () 
	{
        //Componentes a coger
        controller = GetComponent<CharacterController>();
        playermodel = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playercontroller = GetComponent<Transform>();
        anim = GameObject.Find("Player_Sprite").GetComponent<Animator>();
        playertrigger = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHitTrigger>();
        modelColl = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();
        HitColl = GameObject.Find("KillFallTrigger").GetComponent<Collider>();
        sprite = GameObject.Find("Player_Sprite").GetComponent<SpriteRenderer>();
        aud = GetComponent<AudioSource>();

        //Inicializadores/Valores predeterminados
        Inispeed = speed;
        InijumpSpeed = jumpSpeed;
        InigravityFall = gravityFall;
        Inigravitymagnitude = gravitymagnitude;
        IniCulazoForceFall = CulazoForceFall;
        IniCulazoForcemagnitude = CulazoForcemagnitude;
        IniDashForce = DashForce;

        counterDash = 0;
        counterCulazo = 0;

        jump = false;
        canjump = false;
        CanHitFall = false;
        CanHitRun = false;
        StartDash = false;
        StartCulazo = false;
        CanHitCulo = false;

        ScoreScript.scoreV = 0;
    }

    void Update()
    {
        if (playertrigger.pushbool) PushForce();

        else if (playertrigger.pushbool == false)
        {
            anim.SetBool("Hit", false);

            if (startcoll)
            {
                collcounter += Time.deltaTime;

                if (collcounter < 4f)
                {
                    if (sprite.color.a == 1) sprite.DOColor(new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f), 0.1f);
                    if (sprite.color.a == 0.5f) sprite.DOColor(new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1), 0.1f);
                }

                if (collcounter >= 4f)
                {
                    collcounter = 0;

                    sprite.DOColor(new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1), 0.1f);

                    modelColl.enabled = true;
                    HitColl.enabled = true;
                    controller.radius = 0.58f;

                    startcoll = false;
                }
            }

            if (StartDash) AtaqueEnCarrera();

            if (StartCulazo) Culazo();

            if (axis.x < 0)
            {
                playermodel.transform.localRotation = Quaternion.Euler(0, 180, 0);
                anim.SetFloat("Run_Walk", 1f);
            }
            if (axis.x > 0)
            {
                playermodel.transform.localRotation = Quaternion.Euler(0, 0, 0);
                anim.SetFloat("Run_Walk", 1f);
            }
            if (axis.x == 0)
            {
                anim.SetFloat("Run_Walk", 0f);
            }

            if (axis.x != 0) playercontroller.transform.localPosition = new Vector3(transform.position.x, transform.position.y, 0f);

            //Jump
            if (canjump == true) StartJump();

            if (controller.isGrounded == false && canjump == false)
            {
                moveDirection.y = forceToGround * gravityFall;
                anim.SetTrigger("Fall");
            }

            if (controller.isGrounded == false) CanHitFall = true;
            else if (controller.isGrounded)
            {
                CanHitFall = false;
            }

            //Mov
            transformDir = axis.x * transform.right + axis.y * transform.up;

            moveDirection.x = transformDir.x * speed;

            controller.Move(moveDirection * Time.deltaTime);

            if (controller.isGrounded) anim.SetBool("TouchingFloor", true);
            else anim.SetBool("TouchingFloor", false);
        }
    }

	public void SetAxis (Vector2 inputAxis)
    {
        axis = inputAxis;
    }
    
    public void ChangerJump()
    {
        canjump = true;

        if (jumpcounter == 0 && controller.isGrounded)
        {
            jump = true;

            anim.SetTrigger("Jump");

            aud.clip = clips[0];

            aud.Play();
        }
    }

    public void StartJump()
    {
        if (jump == true)
        {
            moveDirection.y = jumpSpeed;

            jumpcounter += Time.deltaTime;
        }

        if (jumpcounter >= 0.2f) jump = false;

        if (jump == false)
        {
            jumpcounter = 0;
            jumpanimcounter += Time.deltaTime;
            moveDirection.y += forceToGround * gravitymagnitude * Time.deltaTime;
            if (jumpanimcounter >= 0.1f) anim.SetTrigger("Fall");
        }

        if (controller.isGrounded && jump == false)
        {
            canjump = false;
            jumpanimcounter = 0;
        }

    }

    public void AtaqueEnCarrera()
    {
        counterDash += Time.deltaTime;

        if (counterDash <= 1f)
        {
            CanHitRun = true;
            speed = DashForce;
            anim.SetBool("CarreraAtack", true);
        }

        if (counterDash >= 1f || axis.x == 0)
        {
            counterDash = 0;
            StartDash = false;
            CanHitRun = false;
            speed = Inispeed;
            anim.SetBool("CarreraAtack", false);
        }
    }

    public void Culazo()
    {
        counterCulazo += Time.deltaTime;

        if (counterCulazo >= 0.1f && controller.isGrounded == false)
        {
            CanHitCulo = true;
            gravityFall = CulazoForceFall;
            gravitymagnitude = CulazoForcemagnitude;
            anim.SetBool("Culazo", true);
        }

        if (controller.isGrounded)
        {
            StartCulazo = false;
            counterCulazo = 0;
            CanHitCulo = false;
            gravityFall = InigravityFall;
            gravitymagnitude = Inigravitymagnitude;
            anim.SetBool("Culazo", false);
        }
    }

    void PushForce()
    {
        pushcounter += Time.deltaTime;

        modelColl.enabled = false;
        HitColl.enabled = false;
        controller.radius = 0.1f;

        if (pushcounter < 0.05f)
        {
            playercontroller.position += new Vector3(0, force * Time.deltaTime, 0);

            anim.SetBool("Hit", true);
        }

        else if (pushcounter >= 0.5f)
        {
            playertrigger.pushbool = false;

            pushcounter = 0;

            startcoll = true;
        }
    }
}
