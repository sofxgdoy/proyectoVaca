using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics; 

public class ControlVaca : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Analytics.CustomEvent("vacaRecogida");
    }

    
    public void ReportSecretFound(int secretID){
        Analytics.CustomEvent("vacaRecogida", new Dictionary<string, object>
        {
        { "vacaRecogida", secretID },
        { "time_elapsed", Time.timeSinceLevelLoad }
        });
    }

}
