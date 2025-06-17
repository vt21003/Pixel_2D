using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4.5f;
    [SerializeField] private float jump = 15f;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Transform layerCheck;
    [SerializeField] private Transform hieuUng;
    private bool ground;
    private bool doubleJump;
    private Animator animator;
    private AudioManager am;

    private Rigidbody2D rb2;    
    private GameManager gm;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb2 = GetComponent<Rigidbody2D>();
        gm = FindAnyObjectByType<GameManager>();
        am = FindAnyObjectByType<AudioManager>();
    }

    void Start()
    {
      
    }
    // Update is called once per frame 
    void Update()
    {
        if (gm.IsGameOver() || gm.IsGameWin()) return;
        transform.rotation = Quaternion.identity;
        MovePlayer();
        JumpPlayer();
        UpdateAnimator();
    }
    public void ButtonFB()
    {
        Application.OpenURL("https://www.facebook.com/vt21003");
    }
    public void ButtonIG()
    {
        Application.OpenURL("https://www.instagram.com/vt21003/");

    }
    public void ButtonYTB()
    {
        Application.OpenURL("https://www.youtube.com/@vt21003");
    }
    private int huong = 1; // 1: phải, -1: trái

    private void MovePlayer()
    {
        float move = Input.GetAxis("Horizontal");
        rb2.velocity = new Vector2(move * moveSpeed, rb2.velocity.y);

        if (move > 0)
        {
            huong = 1;
        }
        else if (move < 0)
        {
            huong = -1;
        }

        transform.localScale = new Vector3(huong, 1, 1);
    }

    private void JumpPlayer()
    {
        if (Input.GetButtonDown("Jump") && ground)
        {
            am.PlayJump();
            Jump();
            doubleJump = true;  
        }
        else if(doubleJump && Input.GetButtonDown("Jump"))
        {
            am.PlayJump();
            Jump();
            doubleJump = false;
        }
            ground = Physics2D.OverlapCircle(layerCheck.position, 0.2f, layer);
    }
    void Jump()
    {
        rb2.velocity = new Vector2(rb2.velocity.x, jump);
    }
    private void UpdateAnimator() {
        bool isRunning = Mathf.Abs(rb2.velocity.x) > 0.1f;
        bool isJump = !ground;
        bool isDoubleJump = !ground && !doubleJump;
        animator.SetBool("isRunning", isRunning);   
        animator.SetBool("isJump", isJump);
        animator.SetBool("isDoubleJump", isDoubleJump);
    }


}
    