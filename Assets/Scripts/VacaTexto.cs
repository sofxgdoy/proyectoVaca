using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacaTexto : MonoBehaviour
{
    public GameObject texto_floatPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TextoFlotante() {
        if (texto_floatPrefab){
            MostrarTextoFlotante();
        }

    }

    void MostrarTextoFlotante() {
        Debug.Log("texto");
        Instantiate(texto_floatPrefab, transform.position, Quaternion.identity, transform);
    }
}
