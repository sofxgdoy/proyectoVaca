using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public string escena;
    public GameObject gameOver;
    public GameObject canvas1;
    
 
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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
