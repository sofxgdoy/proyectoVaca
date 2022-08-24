using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolacontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       MoveOnZ(0.1f);
    }
    private void MoveOnZ(float velocidad)
    {
        transform.position += transform.forward * velocidad;
    }
}
