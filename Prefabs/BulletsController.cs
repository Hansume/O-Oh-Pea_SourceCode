using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsController : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera cam;
    protected Rigidbody2D rb;
    [SerializeField] protected float force;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    protected virtual void Start()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    protected virtual void Update()
    {
        if (transform.position.x > 10f || transform.position.x < -10f
            || transform.position.y > 6f || transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}
