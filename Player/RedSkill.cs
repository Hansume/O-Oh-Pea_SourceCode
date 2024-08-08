using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedSkill : MonoBehaviour
{
    [SerializeField] private Slider skillCooldownSlider;
    private float skillCooldown = 5f;
    private bool startTimer = false;
    public bool canDo = true;

    private Vector3 mousePos;
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.E) && canDo)
        {
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            canDo = false;
            startTimer = true;
        }
        if (startTimer)
        {
            skillCooldown -= Time.deltaTime;
            if (skillCooldown <= 0)
            {
                canDo = true;
                skillCooldown = 5;
                startTimer = false;
            }
            skillCooldownSlider.value = skillCooldown;
        }
    }
}
