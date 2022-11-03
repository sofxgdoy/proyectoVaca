using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarPanel : MonoBehaviour
{
    public GameObject PanelInsuf;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DesactivarPanel() {
        PanelInsuf.SetActive(false);

    }
}
