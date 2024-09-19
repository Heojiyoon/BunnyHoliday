using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceGround : MonoBehaviour
{
    public float bounceForce = 40f; // 튕기는 정도

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) // 플레이어와 충돌 체크하는 부분
        {
            // 플레이어와 충돌하면 위로 튕겨 올라가게 하는 코드
            Rigidbody playerRigidbody = collision.collider.GetComponent<Rigidbody>();
            playerRigidbody.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }
}
