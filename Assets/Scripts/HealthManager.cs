using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    // 체력
    [SerializeField]
    float maxHp = 40f;  //풀피
    float currentHp;  //현재체력

    float damagePerUpdate = 15f;  
    float damageByEnemy = 5f;

    public Slider HealthBar;

    bool heal = false;

    private void Start()
    {

        currentHp = maxHp;
        HealthBar.value = currentHp;

    }
    public void IncreaseHP(float amount)
    {

        //print(currentHp);

        currentHp += amount;
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }

        //print(currentHp);
        hpCheckUp();
    }

    public void Update()
    {
        if (!heal)
        {
            if (currentHp > 0)
            {
                currentHp -= damagePerUpdate * Time.deltaTime / 10;
            }

            if (currentHp <= 0)
            {
                currentHp = 0;
                //Debug.Log("게임오버");
                SceneManager.LoadScene("GameEndScene");
            }
            hpCheckUp();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            currentHp -= damageByEnemy;
            hpCheckUp();
        }
        if (collision.gameObject.CompareTag("EndFloor"))
        {

            //currentHp = maxHp;
            heal = true;
            
        }
    }

    private void hpCheckUp() //체력UI에 체력 표시 
    {
        HealthBar.value = currentHp / maxHp;
    }
}


