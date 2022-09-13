using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsManager : TimeConverter
{
    private Text[] m_timeDisplays; //List of texts that show the best time in the level select screen

    // Start is called before the first frame update
    private void Awake()
    {
        //Gets the texts
        GameObject[] texts = GameObject.FindGameObjectsWithTag("PB text");

        foreach (GameObject textObject in texts)
        {
            Text text = textObject.GetComponent<Text>();

            //Displays the best times for each level
            text.text = TimeToText(PlayerPrefs.GetFloat(text.name, 0f));
            
        }
    }

    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Deleted");
    }

}
