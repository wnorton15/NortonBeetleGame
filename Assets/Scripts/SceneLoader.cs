using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace beetle.SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        //function to load the next scene
        public void LoadNextScene()
        {
            //creates the scene index as an int
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            //calls the next active scene
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

        public void LoadFirstScene()
        {
            SceneManager.LoadScene(0);
        }

        //function to quit the game
        public void quitGame()
        {
            Application.Quit();
        }
    }
}