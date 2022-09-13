using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneManagerClass : MonoBehaviour
{
    public void LoadLevel()
    {
        //Loads level based on which button you pressed. The button must have the same name as the scene to load    
        SceneManager.LoadScene(EventSystem.current.currentSelectedGameObject.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If player touches the exit to a level
        if (collision.gameObject.CompareTag("Player"))
        {
            //Load the main menu sceme
            SceneManager.LoadScene("Menu");
        }
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
