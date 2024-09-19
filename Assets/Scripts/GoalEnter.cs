using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalEnter : MonoBehaviour
{
    public string nextSceneName = "GameEndScene";
    //public GameObject GameOverImage;

    private void OnCollisionEnter(Collision collision)
    {
        {
            //if (collision.gameObject.tag == "Player")
            //{
            //    //Debug.Log("¾î¶ó¶ó");
            //    SceneManager.LoadScene(nextSceneName);
            //}
        }
    }
}
