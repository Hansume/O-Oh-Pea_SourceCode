using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void getHit(int damageTaken);
}

public interface ISpecialSkill
{
    IEnumerator specialSkill();
}
