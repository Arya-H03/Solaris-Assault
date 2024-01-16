using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour
{
    public Image abilityIcon;
    public float cooldownDuration;
    private float remainingCooldown;
    [SerializeField] TMP_Text CoolDownIconNumber;
    void Start()
    {
        remainingCooldown = 0f;
        abilityIcon.fillAmount = 0f;

    }

    void Update()
    {
        if (remainingCooldown > 0)
        {
            remainingCooldown -= Time.deltaTime;
            abilityIcon.fillAmount = remainingCooldown / cooldownDuration;
        }

        CoolDownIconNumber.text = Math.Round(remainingCooldown).ToString();
        if (CoolDownIconNumber.text == "0")
        {
            CoolDownIconNumber.text = "";
        }

        if(remainingCooldown == 0)
        {
            abilityIcon.fillAmount = 0f;
        }
    }

    //call this function in another script when an ability is used
    public void StartAbilityIcon()
    {
        if (remainingCooldown <= 0)
        {
            remainingCooldown = cooldownDuration;
        }
    }
}
