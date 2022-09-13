using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicKeep : MonoBehaviour
{
    public static GameObject m_bgMusic; //Static variable for the music object

    private void Start()
    {
        //If the bg music already exists
        if (m_bgMusic != null)
        {
            //Destroy the new instance of the bg music so only 1 is ever playing
            Destroy(gameObject);
        }
        else
        {
            //Set the bg music object to be the variable so it can be checked later
            m_bgMusic = gameObject;

            //Keeps background music playing between scenes
            DontDestroyOnLoad(gameObject);
        }
    }

}
