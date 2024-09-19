using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Yakgya : MonoBehaviour
{
     float healAmount = 30f; // 증가할 체력 양
    private void Update()
    {
        //transform.Rotate(Vector3.right * 10 * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HealthManager healthManager = collision.gameObject.GetComponent<HealthManager>();
            healthManager.IncreaseHP(healAmount);

            //print("get item");

            //아이템 획득 후 삭제
            Destroy(gameObject);
        }
    }

}

