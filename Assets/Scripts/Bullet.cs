using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5; //총알 발사 속도  
    public float force = 10;
    
    
    public GameObject bombEffect;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", 30);//특정 시간 지난 후 파괴 함수 호출
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-Vector3.right * speed * Time.deltaTime);

    }

    void DestroyBullet()
    {
        Destroy(gameObject); 
     }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject); //충돌 시 자기 자신이 파괴됨 


        GameObject eff = Instantiate(bombEffect);
        eff.transform.position = transform.position;
    }
}
