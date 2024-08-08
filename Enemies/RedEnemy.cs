using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : Enemy
{
    [SerializeField] GameObject smallBullets;
    protected override void Start()
    {
        base.Start();
        InvokeRepeating("shooting", 0, 1f);
    }
    public override IEnumerator specialSkill()
    {
        while (!isDead)
        {
            canMove = true;
            yield return new WaitForSeconds(skillCooldown);
            transform.position = new Vector2(Random.Range(-8, 8), Random.Range(-4, 4));
            canMove = false;
            yield return new WaitForSeconds(1);
            Instantiate(bullets, transform.position, Quaternion.identity);
        }
        yield return null;
    }
    private void shooting()
    {
        if (canMove)
        {
            Instantiate(smallBullets, transform.position, Quaternion.identity);
        }
    }
}