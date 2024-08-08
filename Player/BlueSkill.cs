using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class BlueSkill : MonoBehaviour
{
    [SerializeField] private Slider skillCooldownSlider;
    private float skillCooldown = 3f;
    private bool startTimer = false;
    public bool canDo = true;
    
    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canDo)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            playerController.moveSpeed = 5;
            canDo = false;
            StartCoroutine(skill());
        }
        if (startTimer)
        {
            skillCooldown -= Time.deltaTime;
            if (skillCooldown <= 0)
            {
                skillCooldown = 3;
                canDo = true;
                startTimer = false;
            }
            skillCooldownSlider.value = skillCooldown;
        }
    }
    private IEnumerator skill()
    {
        yield return new WaitForSeconds(1);
        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        playerController.moveSpeed = 3;
        startTimer = true;
    }
}
