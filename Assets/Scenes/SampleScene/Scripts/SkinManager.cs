using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
    public int SkinActual;
    Scene escenaActual;
    string nombreEscena;

    public GameObject Skin1;
    public GameObject Skin2;
    public GameObject Skin3;
    public GameObject Skin4;
    public GameObject Skin5;
    public GameObject Skin6;

    

    // Start is called before the first frame update
    void Start()
    {
        SkinActual = PlayerPrefs.GetInt("SkinAct");
        //PlayerPrefs.SetInt("Green", 0);   esta linea es para setear el valor inicial de la skin!1! ver si se tiene q agregar aca o en tienda controller

        escenaActual = SceneManager.GetActiveScene();
        nombreEscena = escenaActual.name;
        
    }

    // Update is called once per frame
    void Update()
    {
        SeteoSkin();
        
        
        
    }

    void SeteoSkin() {
        if (SkinActual == 1) {
            Skin1.SetActive(true);

        } 

        if (SkinActual == 2) {
            Skin2.SetActive(true);

        }

        if (SkinActual == 3) {
            Skin3.SetActive(true);

        }

        if (SkinActual == 4) {
            Skin4.SetActive(true);

        }

        if (SkinActual == 5) {
            Skin5.SetActive(true);

        }

        if (SkinActual == 6) {
            Skin6.SetActive(true);

        }
    }

    
}
