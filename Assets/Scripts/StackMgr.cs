using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
   }

}
