using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StackMgr : MonoBehaviour
{
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
         }

         //other.GetComponent<Collider>().enabled = false;


      }

   }

  

}
