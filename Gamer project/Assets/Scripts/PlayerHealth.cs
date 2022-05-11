using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    [SerializeField] private Text Health;
    int health = 200;


    private void Start()
    {
        UpdateHealth();
    }
    public void UpdateHealth()
    {
        Health.text = playerHealth.ToString("0");
        if (playerHealth < 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene("gameover");
        }
    }
}
