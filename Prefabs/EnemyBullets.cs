using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : BulletsController
{
    private Transform playerTransform;
    // Start is called before the first frame update
    protected override void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        Vector3 direction = playerTransform.position - transform.position;
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
