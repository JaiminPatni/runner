using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollow : MonoBehaviour
{
    public Transform followObj;
    public Vector3 offset;
    public float followspeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (followObj)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, followObj.position + offset, followspeed * Time.deltaTime);
            this.transform.rotation=Quaternion.Lerp(this.transform.rotation,followObj.rotation, followspeed * Time.deltaTime);
        }
    }
}
