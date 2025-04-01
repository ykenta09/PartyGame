using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Transform respawnPoint; // ���X�|�[���n�_
    public float invincibilityDuration = 3f; // ���G����
    private bool isInvincible = false; // ���G�t���O

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (isInvincible)
        {
            Debug.Log($"{gameObject.name} �͖��G��ԂŃ_���[�W�����I");
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        Debug.Log($"{gameObject.name} �����X�|�[�����܂�");

        // �̗͂���
        currentHealth = maxHealth;

        // ���X�|�[���n�_�Ɉړ�
        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
        }
        else
        {
            Debug.LogWarning("���X�|�[���n�_���ݒ肳��Ă��܂���I");
        }

        // ���G��Ԃɂ���
        StartCoroutine(Invincibility());
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;
        Debug.Log("���G��ԊJ�n�I");

        // ��莞�ԑ҂�
        yield return new WaitForSeconds(invincibilityDuration);

        // ���G����
        isInvincible = false;
        Debug.Log("���G��ԏI��");
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
