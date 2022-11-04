using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPref : MonoBehaviour

{
    // aca voy a inicializar los valores del playerpref para la primera vez que arranque el juego
    public int Monedas;
    void Start()
    {
        if(!PlayerPrefs.HasKey("isFirstTime") || PlayerPrefs.GetInt("isFirstTime") == 1)
        {
         PlayerPrefs.SetInt("Monedas", 0);
         PlayerPrefs.SetInt("SkinAct", 1);

         PlayerPrefs.SetInt("isFirstTime", 1);
         PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
