using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public string escena;
    public GameObject gameOver;
    public GameObject canvas1;
    Scene escenaActual;
    string nombreEscena;

    public static bool Nivel1;
    public static bool Nivel2;
    public static bool Nivel3;
    public static bool Nivel4;
    public static bool Nivel5;
    
     
 
    public void CambioDeEscena(string sceneName){
        //SceneManager.LoadScene(sceneName);//
        StartCoroutine(CambioEscenaDelay());
        
       IEnumerator CambioEscenaDelay() {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneName);
        }
    }

    public void ReloadScene() {
		CambioDeEscena(SceneManager.GetActiveScene().name);
	}

    public void ExitGame() {
		
		Application.Quit();  //salir
		Debug.Log("Quit!");
		
	}

    public void GameOver() {

        gameOver.SetActive(true);
        canvas1.SetActive(false);
        

    }

    public void CambioXNivel(string sceneName) {

       
        if (Nivel1== true && Nivel2 == false) {
            SceneManager.LoadScene("Nivel2");
        }

        if(Nivel2 == true && Nivel3 == false) {
            SceneManager.LoadScene("Nivel3");
        }

        if(Nivel3 == true && Nivel4 == false) {
            SceneManager.LoadScene("Nivel4");
        }

        if(Nivel4 == true && Nivel5 == false) {
            SceneManager.LoadScene("Nivel5");
        }
    }

    void Start()
    {
        escenaActual = SceneManager.GetActiveScene();
        nombreEscena = escenaActual.name;

       
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Nivel1 = StackMgr.Nivel1;
        Nivel2 = StackMgr.Nivel2;
        Nivel3 = StackMgr.Nivel3;
        Nivel4 = StackMgr.Nivel4;
        Nivel5 = StackMgr.Nivel5;

        if (nombreEscena == "JuegoSuperado") {
            StackMgr.Nivel1 = false;
            StackMgr.Nivel2 = false;
            StackMgr.Nivel3 = false;
            StackMgr.Nivel4 = false;
            StackMgr.Nivel5 = false;
        }
    }
}
