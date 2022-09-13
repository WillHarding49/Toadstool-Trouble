using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : TimeConverter
{
    public Text m_timer;
    private float m_startTime;
    private float m_currentTime;
    private float m_previousBest;

    // Start is called before the first frame update
    private void Start()
    {
        m_timer = GameObject.Find("Timer").GetComponent<Text>();

        //Get the time when the timer first exists
        m_startTime = Time.time;

        //Previos best time saved for later comparison. Is 99 if doesn't exist
        m_previousBest = PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "PB", 99f);
    }

    // Update is called once per frame
    private void Update()
    {
        //Time is the current time - when the timer first existsed to get a stopwatch counting up from the level start
        m_currentTime = Time.time - m_startTime;

        //Displays time
        m_timer.text = TimeToText(m_currentTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //When the player touches the exit
        if (collision.gameObject.CompareTag("Player"))
        {
            //If a new fastest time has been achieved
            if (m_currentTime < m_previousBest)
            {
                //Save the time
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "PB", m_currentTime);
                PlayerPrefs.Save();
            }
        }
    }
}
