using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 5f;

    Touch touch;
    Rigidbody2D rb;
    public bool CanFly { get; set; }
    public bool IsTheFirstTimeTouch { get; set; }
    private bool isDie = false;
    private bool isJumping = false;

    Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        CanFly = true;
        IsTheFirstTimeTouch = true;
        isJumping = false;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (isDie) return;
        Move();
        OnDie();
        ProcessAnimation();
    }

    public void SetIsFlying(bool value) { isJumping = value; }
    void Move()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && CanFly == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                CanFly = false;
                isJumping = true;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
            }
        }
    }

    void OnDie()
    {
        Vector3 screenPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (screenPosition.y < 0 || screenPosition.y > 1)
        {
            //Debug.Log("Die");
            isDie = true;
        }
    }

    void ProcessAnimation()
    {
        if (isJumping)
        {
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }
}
