using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Analytics;
using System.Collections;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool MoveByTouch, StartTheGame;
    private Vector3 _mouseStartPos, PlayerStartPos;
    [SerializeField] private float RoadSpeed, SwipeSpeed,Distance;
    [SerializeField] private GameObject Road;
    public static GameManager GameManagerInstance;
    
    private Camera mainCam;
    private SoundManager soundManager;

    private SceneManagement sceneManagement;
    
    public List<Transform> Balls = new List<Transform>();
    //public GameObject Newball;
    //public ParticleSystem Explosion;
 
    void Start()
    {
        
        GameManagerInstance = this;
        mainCam = Camera.main;
        Balls.Add(gameObject.transform);
        soundManager = FindObjectOfType<SoundManager>();
        sceneManagement = FindObjectOfType<SceneManagement>();
        
    }

    

    

    


    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartTheGame = MoveByTouch = true;
            
            /*Plane newPlan = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (newPlan.Raycast(ray,out var distance))
            {
                _mouseStartPos = ray.GetPoint(distance);
                //PlayerStartPos = ball.position;
            }*/
        }

        /*if (Input.GetMouseButtonUp(0))
        {
            MoveByTouch = false;
        }

        if (MoveByTouch)
        {
            var plane = new Plane(Vector3.up, 0f);

            float distance;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (plane.Raycast(ray, out distance))
            {
                Vector3 mousePos = ray.GetPoint(distance);
                Vector3 desirePso = mousePos - _mouseStartPos;
                Vector3 move = PlayerStartPos + desirePso;

                move.x = Mathf.Clamp(move.x, -30f, 30f);
                move.z = -2f;

                var player = transform.position;

                player = new Vector3(Mathf.Lerp(player.x, move.x, Time.fixedDeltaTime * (SwipeSpeed + 5f)), player.y, player.z);

                transform.position = player;
            }
        }*/

        if (StartTheGame) 
            
            Road.transform.Translate(Vector3.forward * (RoadSpeed * -1 * Time.fixedDeltaTime));

        if (Balls.Count > 1)
        {
            for (int i = 1; i < Balls.Count; i++)
            {
                var FirstBall = Balls.ElementAt(i - 1);
                var SectBall = Balls.ElementAt(i);

              //  var DesireDistance = Vector3.Distance(FirstBall.position,SectBall.position );

            //    if (DesireDistance <= Distance)
            //    {
                    SectBall.position = new Vector3(Mathf.Lerp(SectBall.position.x,FirstBall.position.x,SwipeSpeed * Time.deltaTime)
                    ,SectBall.position.y,Mathf.Lerp(SectBall.position.z,FirstBall.position.z + 8f, SwipeSpeed * Time.deltaTime));
              //  }
            }
        
        }
        
    }

    private void LateUpdate()
    {
        if (StartTheGame)
            mainCam.transform.position = new Vector3(Mathf.Lerp(mainCam.transform.position.x, transform.position.x, (SwipeSpeed - 5f) * Time.fixedDeltaTime),
                    mainCam.transform.position.y, mainCam.transform.position.z);
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
            //other.GetComponent<Renderer>().material = GetComponent<Renderer>().material;
            Balls.Add(other.transform);
            soundManager.SeleccionAudio(2, 0.1f);
        }

        /*if (other.CompareTag("add"))
        {
            var NoAdd = Int16.Parse(other.transform.GetChild(0).name);

            for (int i = 0; i < NoAdd; i++)
            {
              GameObject Ball =  Instantiate(Newball, Balls.ElementAt(Balls.Count - 1).position + new Vector3(0f, 0f, 0.5f),
                    Quaternion.identity);
              
              Balls.Add(Ball.transform);
              
            }
            
        }*/

        if (other.CompareTag("obs") && Balls.Count > 0)
        {
            
            Balls.ElementAt(Balls.Count - 1).gameObject.SetActive(false);
            Balls.RemoveAt(Balls.Count - 1);
            //soundManager.SeleccionAudio(1, 0.05f);
        }

        if (Balls.Count == 0)
        {
            StartTheGame = false;
            sceneManagement.GameOver();
        }

        if (other.CompareTag("final")) 
        {
         //AnalyticsEvent.LevelComplete();
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
