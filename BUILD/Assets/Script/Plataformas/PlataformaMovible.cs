using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovible : MonoBehaviour
{
    Transform plat;
    bool change;
    public Vector3 ini;
    public Vector3 final;
    public float speed;

    void Start()
    {
        plat = GetComponent<Transform>();

        change = false;
    }

    
    void Update()
    {
        Changer();

        if (change == false) Move1();
        if (change == true) Move2();
    }

    void Move1()
    {
        plat.position = new Vector3(plat.position.x, plat.position.y + (speed * Time.deltaTime), plat.position.z);
        //if (final.x < 0 || final.x > 0) plat.position = new Vector3(plat.position.x + speed, plat.position.y, plat.position.z);
    }

    void Move2()
    {
        plat.position = new Vector3(plat.position.x, plat.position.y - (speed * Time.deltaTime), plat.position.z);
        //if (final.x < 0 || final.x > 0) plat.position = new Vector3(plat.position.x - speed, plat.position.y, plat.position.z);
    }

    void Changer()
    {
        //if (final.y < 0 || final.y > 0)
        //{
            if (plat.position.y <= ini.y || plat.position.y >= final.y) change = !change;
        //}

        /*if (final.x < 0 || final.x > 0)
        {
            if (plat.localPosition.x <= ini.x) change = !change;
            if (plat.localPosition.x >= final.x) change = !change;
        }*/
    }
}
