using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool shot;
    public float speed;

    void Start()
    {
        shot = false;
    }

    void Update()
    {
        if (shot) transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "Trigger" && other.gameObject.name != "Boss")
        {
            transform.localPosition = new Vector3 (0, -0.6f, 0);
            shot = false;
        }
    }
}
