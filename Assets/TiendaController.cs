using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiendaController : MonoBehaviour
{
    [SerializeField] Text textoMoneda;

    public int Monedas;
    int RedSkin_;
    int BlueSkin_;
    int GreenSkin_;

    public int SkinActual;

    // Hacer un acumulador para la cantidad de vacas obtenidas por escena con playerprefs 
    //traer el acumulador con la cant. Definir ingame la funcion de seleccion de skin if (skinActual == 1){ etc etc etc}
    //tener cuidado con el playerpref xq una vez guardado un valor, el valor queda.

   
    void Start()
    {
    
    
        Monedas = PlayerPrefs.GetInt("Monedas");
        textoMoneda.text = Monedas.ToString();
        RedSkin_ = PlayerPrefs.GetInt("Red");
        PlayerPrefs.SetInt("Red", 0); //esto se saca luego de config bien la compra
        BlueSkin_ = PlayerPrefs.GetInt("Blue");
        PlayerPrefs.SetInt("Blue", 0);  //esto se saca luego de config bien la compra
        GreenSkin_ = PlayerPrefs.GetInt("Green");
        PlayerPrefs.SetInt("Green", 0);  //esto se saca luego de config bien la compra
        SkinActual = PlayerPrefs.GetInt("SkinAct");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMonedas() {  //Esto se re va una vez q se configure bien las monedas
        PlayerPrefs.SetInt("Monedas", Monedas + 500);

        Monedas = PlayerPrefs.GetInt("Monedas");

        textoMoneda.text = Monedas.ToString();

    }

    public void RedSkin() { 
        if (RedSkin_ != 0) 
        {
           SkinActual = 3;   // le damos un valor de skin actual diferente a cada skin
           PlayerPrefs.SetInt("CSkin", 3);
        }
        else {
            Monedas -= 200;  //valor estimativo q cuesta la skin
            PlayerPrefs.SetInt("Monedas", Monedas);
            Monedas = PlayerPrefs.GetInt("Monedas");
            textoMoneda.text = Monedas.ToString();
            PlayerPrefs.SetInt("Red", 1);
            RedSkin_ = PlayerPrefs.GetInt("Red");
            SkinActual = 3;
            PlayerPrefs.SetInt("CSkin", 3);

        }

    }

    public void BlueSkin() {
        if (BlueSkin_ != 0) 
        {
           SkinActual = 1;
           PlayerPrefs.SetInt("CSkin", 1);
        }
        else {
            Monedas -= 200;  //valor estimativo
            PlayerPrefs.SetInt("Monedas", Monedas);
            Monedas = PlayerPrefs.GetInt("Monedas");
            textoMoneda.text = Monedas.ToString();
            PlayerPrefs.SetInt("Blue", 1);
            BlueSkin_ = PlayerPrefs.GetInt("Blue");
            SkinActual = 1;
            PlayerPrefs.SetInt("CSkin", 1);

        }

    }

    public void GreenSkin() {
        if (GreenSkin_ != 0) {
            SkinActual = 2;
            PlayerPrefs.SetInt("CSkin", 2);
        }
        else {
            Monedas -= 200;  //valor estimativo
            PlayerPrefs.SetInt("Monedas", Monedas);
            Monedas = PlayerPrefs.GetInt("Monedas");
            textoMoneda.text = Monedas.ToString();
            PlayerPrefs.SetInt("Green", 1);
            GreenSkin_ = PlayerPrefs.GetInt("Green");
            SkinActual = 2;
            PlayerPrefs.SetInt("CSkin", 2);

        }

    }
}
