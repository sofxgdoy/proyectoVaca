using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSound : MonoBehaviour
{
    private SoundManager soundManager;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.SeleccionAudio(3, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
