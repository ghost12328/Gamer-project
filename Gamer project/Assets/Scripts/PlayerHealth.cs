using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 100f;
    [SerializeField] public TMP_Text healthText;
   // int health = 200;


    private void Start()
    {
        UpdateHealth();
    }
    public void UpdateHealth()
    {
       healthText.text = playerHealth.ToString("0");
       
    }

    private void OnDamageTaken(float onDamageTaken)
    {
         playerHealth -= onDamageTaken;

        if (playerHealth <= 0)
        {
           PlayerDead();
        }
         healthText.text = playerHealth.ToString();
    }
    public void PlayerDead()
    {
       
        
            Debug.Log("Game Over!");
            //SceneManager.LoadScene("gameover");
        
       // Animation.Play("");
        // play dealth animation 
       // Destroy(gameObject);
        // destroys player
    }
    
}
