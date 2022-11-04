using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gancho : MonoBehaviour
{
    public float delta = 0.5f; 
    public float speed = 2.0f;
    private Vector3 startPos;
    public bool derecha;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       startPos = transform.position;
       Vector3 v = startPos;
       if (derecha == true) {
        v.x += delta * Mathf.Sin( Time.time * speed );
        transform.position = v;

       } else {
        v.x -= delta * Mathf.Sin( Time.time * speed );
        transform.position = v;
       }
        
    }
}
