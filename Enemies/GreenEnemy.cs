using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : Enemy
{
    
    protected override void Start()
    {
        base.Start();
        InvokeRepeating("shooting", 0, 1);
    }
    public override IEnumerator specialSkill()
    {
        while (!isDead)
        {
            canMove = true;
            yield return new WaitForSeconds(skillCooldown);
            canMove = false;
            int i = 0;
            while (i < 3)
            {
                currentHealth++;
                if (currentHealth > maxHealth)
                {
                    currentHealth = maxHealth;
                }
                yield return new WaitForSeconds(1);
                i++;
            }
        }
    }
    private void shooting()
    {
        Instantiate(bullets, transform.position, Quaternion.identity);
    }
}
