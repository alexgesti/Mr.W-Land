using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaTraspasable : MonoBehaviour
{
    public BoxCollider platforma;
    BoxCollider detect;
    bool active;

    void Start()
    {
        detect = GetComponent<BoxCollider>();

        active = false;
    }

    void Update()
    {
        if (active)
        {
            platforma.enabled = false;
            //detect.enabled = false;
        }
        else
        {
            platforma.enabled = true;
            //detect.enabled = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") active = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") active = false;
    }
}
