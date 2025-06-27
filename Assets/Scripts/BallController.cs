using System;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController Instance;
    
    [SerializeField] private float speed;
    private bool firstTouched;
    [HideInInspector] public bool gameOver;

    private Rigidbody rb;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOver = false;
        firstTouched = false;
    }

    private void SwitchDirection()
    {
        if (rb.linearVelocity.z > 0)
        {
            rb.linearVelocity = new Vector3(speed, 0f, 0f);
        }
        else if (rb.linearVelocity.x > 0)
        {
            rb.linearVelocity = new Vector3(0f, 0f, speed);
        }
    }

    private void Update()
    {
        if (!firstTouched)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.linearVelocity = new Vector3(speed, 0f, 0f);
                firstTouched = true;
            }
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.linearVelocity = Vector3.down * 25f;
        }
        
        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
        }
    }
}
