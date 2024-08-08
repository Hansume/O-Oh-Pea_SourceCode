using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenSkill : MonoBehaviour
{
    [SerializeField] private Slider skillCooldownSlider;
    private float skillCooldown = 10f;
    private bool startTimer = false;
    private bool canDo = true;

    private PlayerController playerController;
    private RedSkill redSkill;
    private BlueSkill blueSkill;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        redSkill = GetComponent<RedSkill>();
        blueSkill = GetComponent<BlueSkill>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C) && canDo)
        {
            canDo = false;
            redSkill.canDo = false;
            blueSkill.canDo = false;
            playerController.moveSpeed = 0;
            StartCoroutine(skill());
        }
        if (startTimer)
        {
            skillCooldown -= Time.deltaTime;
            if (skillCooldown <= 0)
            {
                skillCooldown = 10;
                canDo = true;
                startTimer = false;
            }
            skillCooldownSlider.value = skillCooldown;
        }
    }
    private IEnumerator skill()
    {
        int i = 0;
        while (i < 3)
        {
            playerController.currentHealth += 1;
            if (playerController.currentHealth > playerController.maxHealth)
            {
                playerController.currentHealth = playerController.maxHealth;
            }
            yield return new WaitForSeconds(1);
            i++;
        }
        redSkill.canDo = true;
        blueSkill.canDo = true;
        playerController.moveSpeed = 3;
        startTimer = true;
        yield return null;
        
    }
}
