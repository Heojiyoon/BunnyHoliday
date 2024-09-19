using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceGround : MonoBehaviour
{
    public float bounceForce = 40f; // ƨ��� ����

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) // �÷��̾�� �浹 üũ�ϴ� �κ�
        {
            // �÷��̾�� �浹�ϸ� ���� ƨ�� �ö󰡰� �ϴ� �ڵ�
            Rigidbody playerRigidbody = collision.collider.GetComponent<Rigidbody>();
            playerRigidbody.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }
}
