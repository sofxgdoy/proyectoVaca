using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoretext : MonoBehaviour
{
    public Text scoreText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = (GameManager.GameManagerInstance.Balls.Count - 1).ToString();
    }
}
