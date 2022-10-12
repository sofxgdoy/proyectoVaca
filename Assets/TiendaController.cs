using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiendaController : MonoBehaviour
{
    [SerializeField] Text textoMoneda;

    public int Monedas;
    void Start()
    {
        Monedas = PlayerPrefs.GetInt("Monedas");

        textoMoneda.text = Monedas.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMonedas() {
        PlayerPrefs.SetInt("Monedas", Monedas + 500);

        Monedas = PlayerPrefs.GetInt("Monedas");

        textoMoneda.text = Monedas.ToString();

    }
}
