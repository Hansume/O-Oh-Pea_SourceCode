using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] public int moveSpeed;
    public int maxHealth;
    public int currentHealth;
    private Rigidbody2D rb;
    private float horizontalMove, verticalMove;
    [SerializeField] private Slider playerHealthbar;

    [SerializeField] private GameObject red;
    [SerializeField] private GameObject blue;
    [SerializeField] private GameObject green;

    private RedEnemy redEnemy;
    private BlueEnemy blueEnemy;
    private GreenEnemy greenEnemy;

    private bool isRedReady = true;
    private bool isBlueReady = true;
    private bool isGreenReady = true;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        redEnemy = red.GetComponent<RedEnemy>();
        blueEnemy = blue.GetComponent<BlueEnemy>();
        greenEnemy = green.GetComponent<GreenEnemy>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        Movement();
        playerHealthbar.value = currentHealth;
    }

    private void Movement() 
    {
        //Move
        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(horizontalMove, verticalMove);

        //KeepInRange
        if (transform.position.x < -8.4f)
        {
            transform.position = new Vector3 (-8.4f, transform.position.y, 0);
        }else if (transform.position.x > 8.4f)
        {
            transform.position = new Vector3(8.4f, transform.position.y, 0);
        }else if (transform.position.y < -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
        }
        else if (transform.position.y > 4.5f)
        {
            transform.position = new Vector3(transform.position.x, 4.5f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Drop")
        {
            if (redEnemy.isDead && isRedReady)
            {
                GetComponent<RedSkill>().enabled = true;
                isRedReady = false;
            }
            if (blueEnemy.isDead && isBlueReady)
            {
                GetComponent<BlueSkill>().enabled = true;
                isBlueReady = false;
            }
            if (greenEnemy.isDead && isGreenReady)
            {
                GetComponent<GreenSkill>().enabled = true;
                isGreenReady = false;
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "EnemysBullets")
        {
            getHit(1);
            Destroy(collision.gameObject);
        }
    }
    public void getHit(int x)
    {
        currentHealth -= x;
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
