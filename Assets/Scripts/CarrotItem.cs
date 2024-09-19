using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//아이템으로서 당근을 관리하는 아이템매니저에 연결되는 스크립트 

public class CarrotItem : MonoBehaviour
{

    public GameObject itemImage1;
    public GameObject itemImage2;
    public GameObject itemImage3;

    public int maxItemCount = 3; //당근 최대개수
    public int currentItemCount; //당근 현재개수
    // Start is called before the first frame update
    void Start()
    {
        UpdateItemUI(); // 초기 UI 설정

        currentItemCount = maxItemCount;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateItemUI(); 
    }

    public void UseItem() //아이템 사용 
    {
        if (currentItemCount > 0)
        {
            currentItemCount--;
            UpdateItemUI(); // UI 갱신
        }
        else
        {
            //Debug.Log("아이템 부족");
            currentItemCount = 0;
            UpdateItemUI(); // UI 갱신
        }
    }

    public void AcquireItem() //아이템 획득 
    {
        //Debug.Log(currentItemCount);
        if (currentItemCount < 3)
        {
            currentItemCount++;
            //Debug.Log(currentItemCount);
            UpdateItemUI(); // UI 갱신
        }
        else
        {
            
            //Debug.Log("이미 최대 개수");
            
            currentItemCount = maxItemCount;
            UpdateItemUI(); // UI 갱신



        }

       
    }

    private void UpdateItemUI()
    {
        // 각 아이템 이미지의 활성/비활성을 설정

        itemImage1.SetActive(currentItemCount >= 1);
        itemImage2.SetActive(currentItemCount >= 2);
        itemImage3.SetActive(currentItemCount >= 3);
    }


}
