using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : Enemy
{
    private int firedBullets = 0;
    public override IEnumerator specialSkill()
    {
        while (!isDead)
        {
            StartCoroutine(shooting());
            yield return new WaitForSeconds(skillCooldown);
        }
        yield return null;
    }
    private IEnumerator shooting()
    {
        while (firedBullets < 3)
        {
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            moveSpeed = 5;
            Instantiate(bullets, transform.position, Quaternion.identity);
            firedBullets++;
            yield return new WaitForSeconds(0.2f);
        }
        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        moveSpeed = 2;
        firedBullets = 0;
        yield return null;
    }
}
