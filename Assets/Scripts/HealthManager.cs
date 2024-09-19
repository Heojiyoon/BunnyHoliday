using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    // ü��
    [SerializeField]
    float maxHp = 40f;  //Ǯ��
    float currentHp;  //����ü��

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
                //Debug.Log("���ӿ���");
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

    private void hpCheckUp() //ü��UI�� ü�� ǥ�� 
    {
        HealthBar.value = currentHp / maxHp;
    }
}


