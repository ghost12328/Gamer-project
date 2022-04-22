using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class gateScript : MonoBehaviour
{
    public GameObject gate1;
    public GameObject gate2;
    PlayableDirector g1Open;
    PlayableDirector g2Open;
    int levelOneEnemies;
    int levelTwoEnemies;
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
        GameObject[] l1Enemies = new GameObject[] { };
        l1Enemies = GameObject.FindGameObjectsWithTag("L1Enemy");
        levelOneEnemies = l1Enemies.Length;
        //level 2
        GameObject[] l2Enemies = new GameObject[] { };
        l2Enemies = GameObject.FindGameObjectsWithTag("L2Enemy");
        levelTwoEnemies = l2Enemies.Length;
    }
    public void OpenGate()
    {
        if(levelOneEnemies == 0)
        {
            g1Open.Play();
        }
        else if(levelTwoEnemies == 0)
        {
            g2Open.Play();
        }
    }
}
