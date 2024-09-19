using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
   

    // 발사 위치
    public GameObject firePosition;

 
    public GameObject carrotFactory;    // 투척 무기 공장
    public int carrotNum;                            // 무기 개수
    public GameObject ItemManager;      //CarrotItem.cs와 연결

    private bool carrotFired = false;

    // 투척 파워
    //public float throwPower = 15;


    private Animator an;


  

    // Start is called before the first frame update
    void Start()
    {
        an = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float playerRotationY = transform.eulerAngles.y;
        

        if (playerRotationY != 270f) //플레이어가 사용자 기준 앞을 보고있을 땐 탄막 발사 x
        {
            
            if (Input.GetKey(KeyCode.Z)&& !carrotFired) //좌클릭
            {
                carrotNum = ItemManager.GetComponent<CarrotItem>().currentItemCount;

                if (carrotNum > 0)
                {
                    carrotFired = true;
                    GameObject carrot = Instantiate(carrotFactory);
                    Invoke("carrotFinishFired", 0.5f);

                    carrot.transform.position = firePosition.transform.position;
                    carrot.transform.rotation = firePosition.transform.rotation;

                    an.SetTrigger("doShot");
                   

                }
                ItemManager.GetComponent<CarrotItem>().UseItem();




            }
        }
    }

  void carrotFinishFired()
    {
        carrotFired = false;
    }
}