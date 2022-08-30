using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GameManagerInstance;
    public List<Transform> Recoger = new List<Transform>();
    [SerializeField] private float Distance;
    // Start is called before the first frame update
    void Start()
    {
        GameManagerInstance = this;
        Recoger.Add(gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Recoger.Count > 1)
        {
            for (int i = 1; i < Recoger.Count; i++)
            {
                var PrimeraVaca = Recoger.ElementAt(i - 1);
                var SectVaca = Recoger.ElementAt(i);

                var DistanciaDeseada = Vector3.Distance(PrimeraVaca.position, SectVaca.position);

                if (DistanciaDeseada <= Distance)
                {
                    SectVaca.position = new Vector3(Mathf.Lerp(SectVaca.position.x, PrimeraVaca.position.x, 5f *Time.deltaTime), SectVaca.position.y, Mathf.Lerp(SectVaca.position.z, PrimeraVaca.position.z +14f, 5f * Time.deltaTime));
                }
            }
        }
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
        Recoger.Add(other.transform);
       }
    }
}
