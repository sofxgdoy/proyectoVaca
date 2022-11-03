using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TiendaController : MonoBehaviour
{
    [SerializeField] Text textoMoneda;

    public int Monedas;
    int RedSkin_;
    int BlueSkin_;
    int GreenSkin_;

    

    public int SkinActual;
    public GameObject flecha1;
    public GameObject flecha2;
    public GameObject flecha3;

    public Text precio1;
    public Text precio2;

    //public Button button;
	//private ColorBlock theColor;
    public GameObject panelAviso;
    

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

        //button = GetComponent<Button>();

       


        

        
        
    }

    // Update is called once per frame
    void Update()
    {
        Flecha();
        //ChequearColor();
        
        
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
           PlayerPrefs.SetInt("SkinAct", 3);
        }
        else {
            if (Monedas<15) {
                panelAviso.SetActive(true);
            } else {
                Debug.Log("EntraElse");
                Monedas -= 15;  //valor estimativo q cuesta la skin
                PlayerPrefs.SetInt("Monedas", Monedas);
                Monedas = PlayerPrefs.GetInt("Monedas");
                textoMoneda.text = Monedas.ToString();
                PlayerPrefs.SetInt("Red", 1);
                RedSkin_ = PlayerPrefs.GetInt("Red");
                SkinActual = 3;
                PlayerPrefs.SetInt("SkinAct", 3);

                precio2.gameObject.SetActive(false);

            }
            

        }

    }

    public void BlueSkin() {
        if (BlueSkin_ != 0) 
        {
           SkinActual = 1;
           PlayerPrefs.SetInt("SkinAct", 1);
        }
        else {
            
            Monedas -= 0;  //valor estimativo
            PlayerPrefs.SetInt("Monedas", Monedas);
            Monedas = PlayerPrefs.GetInt("Monedas");
            textoMoneda.text = Monedas.ToString();
            PlayerPrefs.SetInt("Blue", 1);
            BlueSkin_ = PlayerPrefs.GetInt("Blue");
            SkinActual = 1;
            PlayerPrefs.SetInt("SkinAct", 1);

        }

    }

    public void GreenSkin() {
        if (GreenSkin_ != 0) {
            SkinActual = 2;
            PlayerPrefs.SetInt("SkinAct", 2);
        }
        else {
            if (Monedas<10){
                panelAviso.SetActive(true);
            } else {
                Monedas -= 10;  //valor estimativo
                PlayerPrefs.SetInt("Monedas", Monedas);
                Monedas = PlayerPrefs.GetInt("Monedas");
                textoMoneda.text = Monedas.ToString();
                PlayerPrefs.SetInt("Green", 1);
                GreenSkin_ = PlayerPrefs.GetInt("Green");
                SkinActual = 2;
                PlayerPrefs.SetInt("SkinAct", 2);

                precio1.gameObject.SetActive(false);

            }
            

        }

    }

    /*void ChequearColor(){
     if (SkinActual!=1) {
            button.GetComponent<UnityEngine.UI.Image>().color = Color.red;
            
        }   
    }*/

    void Flecha() {
        
        if (SkinActual == 1) {
            
            flecha1.SetActive(true);
            flecha2.SetActive(false);
            flecha3.SetActive(false);

        }
            

        if (SkinActual == 2) {
            flecha1.SetActive(false);
            flecha2.SetActive(true);
            flecha3.SetActive(false);

        }

        if (SkinActual == 3) {
            flecha1.SetActive(false);
            flecha2.SetActive(false);
            flecha3.SetActive(true);

        }
    }
}

