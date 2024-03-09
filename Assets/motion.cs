using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motion : MonoBehaviour
{
    public float speed = 5;
    public float sidespeed = 3;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var x in GetComponentsInChildren<Rigidbody>())
        {
            x.isKinematic = true;
        }
        foreach(var x in GetComponentsInChildren<Collider>())
        {
            x.enabled = false;
        }
        GetComponent<Collider>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * sidespeed, 0, speed * Time.deltaTime);
      
    }
    public void OnDead()
    {
        foreach (var x in GetComponentsInChildren<Rigidbody>())
        {
            x.isKinematic = false;
        }
        foreach(var x in GetComponentsInChildren<Collider>())
        {
            x.enabled = true;
        }
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;
        speed = 0;
        anim.enabled= false;
    }
        private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Finish")
        {
            OnDead();
        }
    } 

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "sensor")
        {
            FindObjectOfType<StageManager>().InstantiateStage();
            Destroy(other.gameObject);
        }
    }
}
