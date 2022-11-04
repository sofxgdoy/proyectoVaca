using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoretext : MonoBehaviour
{
    public int Monedas;
    public int Score;
    public Text scoreText;
    public bool yasumo = false;
    void Start()
    {
        Monedas = PlayerPrefs.GetInt("Monedas");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Score = GameManager.GameManagerInstance.Balls.Count - 1;
        scoreText.text = (Score).ToString();
        
    }

    public void SumarMonedas(){
        if(yasumo == false){
            yasumo = true;
            PlayerPrefs.SetInt("Monedas", Monedas + Score);
            Monedas = PlayerPrefs.GetInt("Monedas");

        }
        
    }
}
