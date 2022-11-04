using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TiendaController : MonoBehaviour
{
    [SerializeField] Text textoMoneda;

    public int Monedas;
    
    int Default_;
    int GreenSkin_;
    int Blanca_;

    int Naranja_;

    int Negro_;
    int Rosa_;

    

    public int SkinActual;
    public GameObject flecha1;
    public GameObject flecha2;
    public GameObject flecha3;
    public GameObject flecha4;
    public GameObject flecha5;
    public GameObject flecha6;

    public Text precio1;
    public Text precio2;
    public Text precio3;
    public Text precio4;
    public Text precio5;

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
        
        //default
        Default_ = PlayerPrefs.GetInt("Default");
        PlayerPrefs.SetInt("Default", 0);  //esto se saca luego de config bien la compra
        
        //skin2 verde
        GreenSkin_ = PlayerPrefs.GetInt("Green");
        PlayerPrefs.SetInt("Green", 0);  //esto se saca luego de config bien la compra
        SkinActual = PlayerPrefs.GetInt("SkinAct");
        
        //skin blanca 3
        Blanca_ = PlayerPrefs.GetInt("White");
        PlayerPrefs.SetInt("White", 0);

        //naranja 4
        Naranja_ = PlayerPrefs.GetInt("Naranja");
        PlayerPrefs.SetInt("Naranja", 0);

        //negro 5
        Negro_ = PlayerPrefs.GetInt("Negro");
        PlayerPrefs.SetInt("Negro", 0);

        //rosa 6
        Rosa_ = PlayerPrefs.GetInt("Rosa");
        PlayerPrefs.SetInt("Rosa", 0);


       


        

        
        
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


    public void DefaultSkin() {
        if (Default_ != 0) 
        {
           SkinActual = 1;
           PlayerPrefs.SetInt("SkinAct", 1);
        }
        else {
            
            Monedas -= 0;  //valor estimativo
            PlayerPrefs.SetInt("Monedas", Monedas);
            Monedas = PlayerPrefs.GetInt("Monedas");
            textoMoneda.text = Monedas.ToString();
            PlayerPrefs.SetInt("Default", 1);
            Default_ = PlayerPrefs.GetInt("Default");
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
            if (Monedas<2){
                panelAviso.SetActive(true);
            } else {
                Monedas -= 2;  //valor estimativo
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

    public void BlancaSkin() { 
        if (Blanca_!= 0) 
        {
           SkinActual = 3;   // le damos un valor de skin actual diferente a cada skin
           PlayerPrefs.SetInt("SkinAct", 3);
        }
        else {
            if (Monedas<8) {
                panelAviso.SetActive(true);
            } else {
                
                Monedas -= 8;  //valor estimativo q cuesta la skin
                PlayerPrefs.SetInt("Monedas", Monedas);
                Monedas = PlayerPrefs.GetInt("Monedas");
                textoMoneda.text = Monedas.ToString();
                PlayerPrefs.SetInt("White", 1);
                Blanca_ = PlayerPrefs.GetInt("White");
                SkinActual = 3;
                PlayerPrefs.SetInt("SkinAct", 3);

                precio2.gameObject.SetActive(false);

            }
            

        }

    }

    public void NaranjaSkin() {
        if (Naranja_ != 0) {
            SkinActual = 4;
            PlayerPrefs.SetInt("SkinAct", 4);
        }
        else {
            if (Monedas<9){
                panelAviso.SetActive(true);
            } else {
                Monedas -= 9;  //valor estimativo
                PlayerPrefs.SetInt("Monedas", Monedas);
                Monedas = PlayerPrefs.GetInt("Monedas");
                textoMoneda.text = Monedas.ToString();
                PlayerPrefs.SetInt("Naranja", 1);
                GreenSkin_ = PlayerPrefs.GetInt("Naranja");
                SkinActual = 4;
                PlayerPrefs.SetInt("SkinAct", 4);

                precio3.gameObject.SetActive(false);

            }
            

        }

    }

    public void NegroSkin() {
        if (Negro_ != 0) {
            SkinActual = 5;
            PlayerPrefs.SetInt("SkinAct", 5);
        }
        else {
            if (Monedas<11){
                panelAviso.SetActive(true);
            } else {
                Monedas -= 11;  //valor estimativo
                PlayerPrefs.SetInt("Monedas", Monedas);
                Monedas = PlayerPrefs.GetInt("Monedas");
                textoMoneda.text = Monedas.ToString();
                PlayerPrefs.SetInt("Negro", 1);
                GreenSkin_ = PlayerPrefs.GetInt("Negro");
                SkinActual = 5;
                PlayerPrefs.SetInt("SkinAct", 5);

                precio4.gameObject.SetActive(false);

            }
            

        }

    }

    public void RosaSkin() {
        if (Rosa_ != 0) {
            SkinActual = 6;
            PlayerPrefs.SetInt("SkinAct", 6);
        }
        else {
            if (Monedas<15){
                panelAviso.SetActive(true);
            } else {
                Monedas -= 15;  //valor estimativo
                PlayerPrefs.SetInt("Monedas", Monedas);
                Monedas = PlayerPrefs.GetInt("Monedas");
                textoMoneda.text = Monedas.ToString();
                PlayerPrefs.SetInt("Rosa", 1);
                GreenSkin_ = PlayerPrefs.GetInt("Rosa");
                SkinActual = 6;
                PlayerPrefs.SetInt("SkinAct", 6);

                precio5.gameObject.SetActive(false);

            }
            

        }

    }

    

    void Flecha() {
        
        if (SkinActual == 1) {
            
            flecha1.SetActive(true);
            flecha2.SetActive(false);
            flecha3.SetActive(false);
            flecha4.SetActive(false);
            flecha5.SetActive(false);
            flecha6.SetActive(false);

        }
            

        if (SkinActual == 2) {
            flecha1.SetActive(false);
            flecha2.SetActive(true);
            flecha3.SetActive(false);
            flecha4.SetActive(false);
            flecha5.SetActive(false);
            flecha6.SetActive(false);

        }

        if (SkinActual == 3) {
            flecha1.SetActive(false);
            flecha2.SetActive(false);
            flecha3.SetActive(true);
            flecha4.SetActive(false);
            flecha5.SetActive(false);
            flecha6.SetActive(false);

        }

        if (SkinActual == 4) {
            flecha1.SetActive(false);
            flecha2.SetActive(false);
            flecha3.SetActive(false);
            flecha4.SetActive(true);
            flecha5.SetActive(false);
            flecha6.SetActive(false);

        }

        if (SkinActual == 5) {
            flecha1.SetActive(false);
            flecha2.SetActive(false);
            flecha3.SetActive(false);
            flecha4.SetActive(false);
            flecha5.SetActive(true);
            flecha6.SetActive(false);

        }

        if (SkinActual == 6) {
            flecha1.SetActive(false);
            flecha2.SetActive(false);
            flecha3.SetActive(false);
            flecha4.SetActive(false);
            flecha5.SetActive(false);
            flecha6.SetActive(true);

        }
    }
}

