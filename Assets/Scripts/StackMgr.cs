using System;
using System.Linq;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StackMgr : MonoBehaviour
{
    private SceneManagement sceneManagement;
    private SoundManager soundManager;
    

    void Start() {
        sceneManagement = FindObjectOfType<SceneManagement>();
        soundManager = FindObjectOfType<SoundManager>();
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
