using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Monement : MonoBehaviour
{


    public float spinForce = 2.5f;   // degrees per second to rotate in each axis. Set in inspector.

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;   
        
        transform.position = new Vector3 (pos.x,1.2f + Mathf.Sin(Time.time)/3 ,pos.z);
        
        transform.Rotate(0, spinForce * Time.deltaTime, 0);
    }
}
