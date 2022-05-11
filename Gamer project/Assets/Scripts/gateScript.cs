using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class gateScript : MonoBehaviour
{
    public GameObject gate1;
    public GameObject gate2;
    PlayableDirector g1Open;
    PlayableDirector g2Open;
    int enemiesLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        //both gates use the same director but the code below lets you call them based on the gate they are attatched to
        g1Open = gate1.GetComponent<PlayableDirector>();
        g2Open = gate2.GetComponent<PlayableDirector>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CountEnemies();
        OpenGate();
    }
    public void CountEnemies()
    {
        //tracks the number of enemies remaining in each level
        GameObject[] enemies = new GameObject[] { };
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesLeft = enemies.Length;
        
    }
    public void OpenGate()
    {
        if(enemiesLeft == 13)
        {
            g1Open.Play();
            Destroy(g1Open, 6);
        }
        else if(enemiesLeft == 5)
        {
            g2Open.Play();
            Destroy(g2Open, 6);
        }
    }
    public void WinGame()
    {
        if (enemiesLeft == 0)
        {
            {
                SceneManager.LoadScene("Victory");
            }
        }
    }
}
