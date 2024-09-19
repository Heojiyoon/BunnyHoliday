using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // 따라갈 대상(플레이어 등)의 Transform을 저장할 변수
    public float smoothSpeed = 0.125f;  // 카메라 이동을 부드럽게 하기 위한 변수
    //public Vector3 offset = new Vector3(0f, 0f, 0f);  // 카메라의 원하는 위치를 조절하기 위한 오프셋 변수


    void LateUpdate()
    {
        if (target != null)
        {
   
            // 대상의 현재 위치를 가져옴
            Vector3 desiredPosition = new Vector3(-2.8f, Mathf.Max(target.position.y,-643), transform.position.z);

            // SmoothDamp 함수를 사용하여 현재 위치에서 대상의 위치로 부드럽게 이동
            // 카메라의 Z 축을 유지하여 움직임을 제한
            desiredPosition.z = transform.position.z;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;


        }
       
    }
}