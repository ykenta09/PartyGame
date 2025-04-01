using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Health playerHealth; // �v���C���[��Health�X�N���v�g
    public Text hpText; // HP�\���p��Text

    void Update()
    {
        if (playerHealth != null && hpText != null)
        {
            hpText.text = "HP: " + playerHealth.GetCurrentHealth();
        }
    }
}
