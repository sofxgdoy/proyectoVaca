using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class StackMgr : MonoBehaviour
{
   public string sceneName;
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Vaca"))
      {
        other.transform.parent = null;
        other.gameObject.AddComponent<Rigidbody>().isKinematic = true;
        other.gameObject.AddComponent<StackMgr>();
        other.gameObject.GetComponent<Collider>().isTrigger = true;
        other.tag = gameObject.tag;
        
        GameManager.GameManagerInstance.Recoger.Add(other.transform);

      }

      if (other.CompareTag("obs"))
      {
         
         var NoSub = 1;

         if (GameManager.GameManagerInstance.Recoger.Count > NoSub)
         {
           for (int i = 0; i < NoSub; i++)
           {
            GameManager.GameManagerInstance.Recoger.ElementAt( GameManager.GameManagerInstance.Recoger.Count - 1).gameObject.SetActive(false);
            GameManager.GameManagerInstance.Recoger.RemoveAt( GameManager.GameManagerInstance.Recoger.Count - 1 );
           }
         }

         if (GameManager.GameManagerInstance.Recoger.Count <= 0)
         {
            GameManager.GameManagerInstance.StartTheGame = false;
            GameManager.GameManagerInstance.bgameOver = true;

            GameManager.GameManagerInstance.GameOver();
         }

         //other.GetComponent<Collider>().enabled = false;


      }

      if (other.CompareTag("final")) {
         SceneManager.LoadScene(3);
      }
   }

  

}
