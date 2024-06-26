﻿using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Controller_Hud : MonoBehaviour
{
    public static bool gameOver = false;
    public Text distanceText;
    public Text gameOverText;
    private float distance = 0;

    void Start()
    {
        gameOver = false;
        distance = 0;
        distanceText.text = distance.ToString();
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over \n Total Distance: " + String.Format("{0:00}", distance);
            
            gameOverText.gameObject.SetActive(true);
        }
        else
        {
            distance += Time.deltaTime;
            distanceText.text = String.Format("{0:00}",distance); 
            /*Convierte el valor del deltaTime a un formato que lo redondea. También aplica al texto del GameOver de
             la línea 26*/
        }
    }
}
