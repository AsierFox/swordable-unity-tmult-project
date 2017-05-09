using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float speed = 50f;
    public float maxSpeed = 3;
    
    public float health;
    public float maxHealth = 100;

    public float jumpPower = 450f;

    public bool grounded;

    public PlayerManager playerManager;

    private Rigidbody2D rigitBody2D;
    private Animator animator;
    private Animation animation;

    void Start ()
    {
        playerManager = new PlayerManager(this);

        rigitBody2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        animation = gameObject.GetComponent<Animation>();

        health = maxHealth;
    }
	
	void Update ()
    {

        // Update animator attributes
        animator.SetBool("Grounded", grounded);
        animator.SetFloat("Speed", Mathf.Abs(rigitBody2D.velocity.x));

        // Rotate
        if (Input.GetAxis("Horizontal") < -.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") > .1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // Jump
        if (grounded && Input.GetButtonDown("Jump"))
        {
            rigitBody2D.AddForce(Vector2.up * jumpPower);
        }
        
        // Move
        rigitBody2D.AddForce((Vector2.right * speed) * Input.GetAxis("Horizontal"));

        // Control maxSpeed
        if (rigitBody2D.velocity.x > maxSpeed)
        {
            rigitBody2D.velocity = new Vector2(maxSpeed, rigitBody2D.velocity.y);
        }
        if (rigitBody2D.velocity.x < -maxSpeed)
        {
            rigitBody2D.velocity = new Vector2(-maxSpeed, rigitBody2D.velocity.y);
        }
        
        CheckLife();

        // TODO Testing dead
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Damage(5);
        }
    }

    private void FixedUpdate()
    {
        // Fake friction / Easing X
        Vector3 easeVelocity = rigitBody2D.velocity;
        easeVelocity.x *= .75f; // Reduce x velocity
        easeVelocity.y = rigitBody2D.velocity.y;
        easeVelocity.z = .0f;

        if (grounded)
        {
            rigitBody2D.velocity = easeVelocity;
        }
    }

    void CheckLife()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            Die();
        }
    }

    void Damage(int damageAmount)
    {
        health -= damageAmount;
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //StartCoroutine(Die());
    }

    //IEnumerator die()
    //{
    //    yield return new waitforseconds();
    //}
}
