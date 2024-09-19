using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundManager : MonoBehaviour
{


    public AudioSource damageAudio;
    public AudioSource attackAudio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlaySound(AudioSource audioSource)
    {
        if (audioSource != null)
        {

            
            audioSource.Play();

        }


    }
    private void OnCollisionEnter(Collision collision)
    {

        string tagtag = collision.gameObject.tag;
        switch (tagtag)
        {
            case "Player":
                
                //damageAudio.Play();
                PlaySound(damageAudio);
                break;
            case "Bomb":
              
                // attackAudio.Play();
                PlaySound(attackAudio);
                break;
            default:
                break;
        }
    }


}
