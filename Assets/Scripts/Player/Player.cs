using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 5f;

    Touch touch;
    Rigidbody2D rb;
    public bool CanFly { get; set; } //anh thấy biến này =!isJumping thì phải, đang dư thừa dữ liệu, em xem tối ưu được k nhé
    public bool IsTheFirstTimeTouch { get; set; }
    private bool isDie;
    private bool isJumping;

    Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; //chinh trong prefab duoc,cho constrain ay,anh chinh cho roi day
        CanFly = true;
        IsTheFirstTimeTouch = true;
        isJumping = false;
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

            //Panel logic
            PanelManager.Instance.CloseAll();
            PanelManager.Instance.OpenPanel("GameOverPanel");
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
