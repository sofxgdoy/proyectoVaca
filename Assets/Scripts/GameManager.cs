using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GameManagerInstance;
    public List<Transform> Recoger = new List<Transform>();
    [SerializeField] private float Distance;

    /*[SerializeField] private Animator texto;
    [SerializeField] private string scoreanim = "scoreanim"; */
    private string currentScene;
    private AsyncOperation async;

    public bool StartTheGame;

    // Start is called before the first frame update
    void Start()
    {
        GameManagerInstance = this;
        Recoger.Add(gameObject.transform);
    
    }

    // Update is called once per frame
    public void CambioDeEscena(string sceneName){
        SceneManager.LoadScene(sceneName);
       
    }

    /*IEnumerator Load(string sceneName) {
		SceneManager.LoadSceneAsync(sceneName);
		async.allowSceneActivation = false;
		yield return async;
		
    }*/

    /*public void ActivateScene() {
		async.allowSceneActivation = true;
	}*/

    public void ExitGame() {
		
		Application.Quit();  //salir
		Debug.Log("Quit!");
		
	}
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //devuelve true cuando se toca la pantalla
        {     
            StartTheGame = true;
        }

        if (Recoger.Count > 1)
        {
            for (int i = 1; i < Recoger.Count; i++)
            {
                var PrimeraVaca = Recoger.ElementAt(i - 1);
                var SectVaca = Recoger.ElementAt(i);

                var DistanciaDeseada = Vector3.Distance(PrimeraVaca.position, SectVaca.position);

                if (DistanciaDeseada <= Distance)
                {
                    SectVaca.position = new Vector3(Mathf.Lerp(SectVaca.position.x, PrimeraVaca.position.x, 5f *Time.deltaTime), SectVaca.position.y, Mathf.Lerp(SectVaca.position.z, PrimeraVaca.position.z +24f, 5f * Time.deltaTime));
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
       if (other.CompareTag("Vaca")) 
       {
        /*texto.Play(scoreanim, 0, 0.0f);*/
        other.transform.parent = null;
        other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
        other.gameObject.AddComponent<StackMgr>();
        other.gameObject.GetComponent<Collider>().isTrigger = true;
        other.tag = gameObject.tag;
        other.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
        Recoger.Add(other.transform);
       }

    if (other.CompareTag("obs") && Recoger.Count > 0) 
       {
        Recoger.ElementAt(Recoger.Count -1).gameObject.SetActive(false);
        Recoger.RemoveAt(Recoger.Count -1);
       }

       if (Recoger.Count <= 0) {
        StartTheGame = false;
       }

    }
}
