using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy: MonoBehaviour, IDamageable, ISpecialSkill
{
    [SerializeField] protected float moveSpeed;
    protected int currentHealth;
    [SerializeField] protected int maxHealth;
    [SerializeField] private Slider healthbarSlider;
    private Vector2 target;
    [SerializeField] protected GameObject bullets;
    [SerializeField] protected float skillCooldown;
    public bool isDead = false;
    protected bool canMove = true;
    [SerializeField] private GameObject drop;
    
    protected virtual void Start()
    {
        currentHealth = maxHealth;
        InvokeRepeating("randomPos", 0, .5f);
        StartCoroutine(specialSkill());
    }

    void Update()
    {
        Move();
        healthbarController();
    }
    private void randomPos()
    {
        target.x = Random.Range(-8, 8);
        target.y = Random.Range(-4, 4);
    }
    private void Move()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
        }
    }
    public virtual IEnumerator specialSkill()
    {
        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullets")
        {
            Destroy(collision.gameObject);
            getHit(1);
        }
    }
    public void getHit(int x)
    {
        currentHealth -= x;
        if (currentHealth == 0)
        {
            Instantiate(drop, transform.position, Quaternion.identity);
            isDead = true;
            gameObject.SetActive(false);
        }
    }
    private void healthbarController()
    {
        healthbarSlider.value = currentHealth;
    }
}
