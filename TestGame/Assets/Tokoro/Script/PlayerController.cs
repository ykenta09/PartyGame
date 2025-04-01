using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public GameObject bombPrefab;
    public Transform throwPoint;

    private Rigidbody rb;
    private int maxBombs = 1; // �ő�ݒu�\��
    private int currentBombs = 0; // �ݒu���̃{����

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        if (Input.GetButtonDown("Fire1"))
        {
            ThrowBomb();
        }
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(h, 0, v).normalized;

        if (moveDirection != Vector3.zero)
        {
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.MoveRotation(targetRotation);
        }
    }

    void ThrowBomb()
    {
        if (currentBombs < maxBombs) // �{���̐�����ǉ�
        {
            GameObject bomb = Instantiate(bombPrefab, throwPoint.position, throwPoint.rotation);
            Rigidbody bombRb = bomb.GetComponent<Rigidbody>();
            bombRb.AddForce(transform.forward * 10.0f, ForceMode.Impulse);

            currentBombs++;
            StartCoroutine(BombCooldown()); // �{��������������J�E���g�����炷
        }
    }

    IEnumerator BombCooldown()
    {
        yield return new WaitForSeconds(3f); // ���e�̔�������
        currentBombs--; // �{�����������琔�����炷
    }

    public void IncreaseBombCapacity()
    {
        maxBombs++;
        Debug.Log("�{���̍ő�ݒu��������: " + maxBombs);
    }

    public IEnumerator SpeedBoost(float duration)
    {
        moveSpeed *= 1.5f; // ���x��1.5�{��
        Debug.Log("�X�s�[�h�A�b�v�I");
        yield return new WaitForSeconds(duration);
        moveSpeed /= 1.5f; // ���ɖ߂�
        Debug.Log("�X�s�[�h�����ɖ߂���");
    }
}
