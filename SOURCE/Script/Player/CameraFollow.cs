using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float CameraMovSpeed;
    private GameObject CameraFollowObject;
    //private PauseMenu pause;
    //private GodMode god;

    private MovPlayer player;

    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        CameraFollowObject = GameObject.Find("CameraFollow");
        //pause = GameObject.Find("Canvas").GetComponent<PauseMenu>();
        //god = GameObject.Find("Canvas").GetComponent<GodMode>();

        player = GameObject.FindGameObjectWithTag("PlayerNull").GetComponent<MovPlayer>();
    }
	
	void Update ()
    {
        /*//Pausa
        if (pause.GameIsPaused == true || god.GodModeActivated == true)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }*/

        //Camara
        //Dar el "target" a seguir
        Transform target = CameraFollowObject.transform;

        //La camara se pone detrás del "target" a seguir
        float step = CameraMovSpeed;
        //if(player.canWallJump == false) 
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        //if(player.canWallJump == true) transform.position = new Vector3 (transform.position.x, target.position.y, transform.position.z);
    }
}
