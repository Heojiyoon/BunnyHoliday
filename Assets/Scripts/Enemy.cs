using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   float speed = 10f; // 적의 이동 속도

    public GameObject explosionFactory;

 
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;


        if (collision.gameObject.CompareTag("Player"))       // 충돌한 객체가 플레이어
        {
            Destroy(gameObject);
            
        }
        if (collision.gameObject.CompareTag("Bomb"))    // 충돌한 객체가 총알 또는 다른 것
        {
            //PlaySound(attackAudio);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            //아무것도 안함 
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
           
            Destroy(gameObject);
        }

    }


}
