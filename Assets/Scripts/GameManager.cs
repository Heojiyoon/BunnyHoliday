using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject StartImage;
    //public GameObject GameOverImage;



    public enum GameState
    {
        Ready,
        Run,
        Pause,
        //GameOver
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickRestartButton()
    {

   
            SceneManager.LoadScene("MainScene");

        //SceneManager.LoadScene("MainScene");
    }

    public void OnclickGoToBackButton()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
