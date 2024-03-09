using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    public float turnSpeed = 50;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        foreach (var x in GetComponentsInChildren<Rigidbody>())
        {
            x.isKinematic = true;
        }
        foreach (var x in GetComponentsInChildren<Collider>())
        {
            x.enabled = false;
        }
        GetComponent<Collider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed",Mathf.Abs( Input.GetAxis("Vertical") * speed));
        transform.Translate(0, 0, Input.GetAxis("Vertical")  * speed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            OnDead();
        }
    }


    public void OnDead()
    {
        foreach (var x in GetComponentsInChildren<Rigidbody>())
        {
            x.isKinematic = false;
        }
        foreach (var x in GetComponentsInChildren<Collider>())
        {
            x.enabled = true;
        }
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
        speed = 0;
        anim.enabled = false;
    }
  

}
