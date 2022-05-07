using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float currentTime = 0f;

    [SerializeField] [Header("Timer Settings")]
    public float startingTime = 10f;
    // can be changed in inspector 

    [SerializeField] private TextMeshProUGUI countdownText = default; 
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime; 
        // sets starting time to 0
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 *Time.deltaTime;
        // decreases by 1 each second
        countdownText.text = currentTime.ToString("Time Till Sunrise: 0");

        if (currentTime >= 3.5f)
        {
            countdownText.color = Color.black;
        }
        else 
        {
             countdownText.color = Color.red;
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
        TimesOut();
    }

    public void TimesOut ()
    {
        if (currentTime <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}

