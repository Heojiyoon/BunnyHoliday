using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//맵 상의 당근 오브젝트와 연결되는 스크립트 


public class CarrotRealItem : MonoBehaviour
{
    public GameObject CarrotManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CarrotManager.GetComponent<CarrotItem>().AcquireItem();
            //AcquireItem();

            print("get carrot");

            Destroy(gameObject);     //아이템 획득 후 삭제
            //gameObject.SetActive(false);
        }
    }
}
