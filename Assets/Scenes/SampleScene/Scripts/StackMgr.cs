using System;
using System.Linq;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StackMgr : MonoBehaviour
{
    private scoretext scoreCode;
    private SceneManagement sceneManagement;
    private SoundManager soundManager;
    Scene escenaActual;
    string nombreEscena;

    public GameObject texto_floatPrefab;

    public static bool Nivel1 = false;
    public static bool Nivel2 = false;
    public static bool Nivel3 = false;
    public static bool Nivel4 = false;
    public static bool Nivel5 = false;
    

    void Start() {
        sceneManagement = FindObjectOfType<SceneManagement>();
        soundManager = FindObjectOfType<SoundManager>();
        escenaActual = SceneManager.GetActiveScene();
        nombreEscena = escenaActual.name;
        scoreCode = FindObjectOfType<scoretext>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vaca"))
        {
             other.transform.parent = null;
             other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
             other.gameObject.AddComponent<StackMgr>();
             other.gameObject.GetComponent<Collider>().isTrigger = true;
             other.tag = gameObject.tag;
             
             other.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            GameManager.GameManagerInstance.Balls.Add(other.transform);
            //trigger texto
            
            other.transform.localScale = new Vector3 (450, 450, 450f);
            StartCoroutine(VolverTamaño());

            IEnumerator VolverTamaño() 
           {
             yield return new WaitForSeconds(0.15f);
             other.transform.localScale = new Vector3 (300, 300, 300f);
    
            }
            
             
     
            
           
            
            soundManager.SeleccionAudio(2, 0.1f);
        }
        
        /*if (other.CompareTag("add"))
        {
            var NoAdd = Int16.Parse(other.transform.GetChild(0).name);

            for (int i = 0; i < NoAdd; i++)
            {
                GameObject Ball =  Instantiate(GameManager.GameManagerInstance.Newball, GameManager.GameManagerInstance.Balls
                        .ElementAt(GameManager.GameManagerInstance.Balls.Count - 1).position + new Vector3(0f, 0f, 0.5f),
                    Quaternion.identity);
              
                GameManager.GameManagerInstance.Balls.Add(Ball.transform);
              
            }

            other.GetComponent<Collider>().enabled = false;
        }*/


        if (other.CompareTag("obs") && GameManager.GameManagerInstance.Balls.Count > 0)
        {
            GameManager.GameManagerInstance.Balls.ElementAt(GameManager.GameManagerInstance.Balls.Count - 1).gameObject.SetActive(false);
            GameManager.GameManagerInstance.Balls.RemoveAt(GameManager.GameManagerInstance.Balls.Count - 1);
            soundManager.SeleccionAudio(1, 0.05f);


            
            if (GameManager.GameManagerInstance.Balls.Count == 0)
            {
                GameManager.GameManagerInstance.StartTheGame = false;
                sceneManagement.GameOver();

            }
            //other.GetComponent<Collider>().enabled = false;
        }

        if (other.CompareTag("final")) 
        {

            if (nombreEscena == "Nivel1") {
               Nivel1 = true;
               scoreCode.SumarMonedas();

            }
            if (nombreEscena == "Nivel2") {
               Nivel2 = true;
               scoreCode.SumarMonedas();

            }
            if (nombreEscena == "Nivel3") {
               Nivel3 = true;
               scoreCode.SumarMonedas();

            }
            if (nombreEscena == "Nivel4") {
               Nivel4 = true;
               scoreCode.SumarMonedas();

            }
            if (nombreEscena == "Nivel5") {
               Nivel5 = true;
               SceneManager.LoadScene("JuegoSuperado");

            }
         //soundManager.SeleccionAudio(3, 0.05f);
         StartCoroutine(FinalNivel());

         //SceneManager.LoadScene(3);
         
         IEnumerator FinalNivel() 
          {
           yield return new WaitForSeconds(0.1f);
    
           SceneManager.LoadScene(3);
          }
         
        }
    }

    
}
