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

    public AudioClip[] audioClips;
    private Rigidbody2D rigitBody2D;
    private Animator animator;
    //private Animation animation;
    private GameMaster gameMaster;
    private AudioSource audioSource;

    void Start ()
    {
        rigitBody2D = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        //animation = gameObject.GetComponent<Animation>();
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        audioSource = gameObject.GetComponent<AudioSource>();

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
            PlaySound(0);
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

    public void Damage(int damageAmount)
    {
        gameObject.GetComponent<Animation>().Play("PlayerDamaged");

        PlaySound(1);

        health -= damageAmount;
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //StartCoroutine(Die());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Scorable"))
        {
            PlaySound(3);
            Destroy(collision.gameObject);
            gameMaster.score++;
        }
    }

    public IEnumerator Knockback(float duration, float power, Vector3 direction)
    {
        float timer = 0;

        // To fix the inconsistency of knockback
        rigitBody2D.velocity = new Vector2(rigitBody2D.velocity.x, 0);

        while (duration > timer)
        {
            timer += Time.deltaTime;

            rigitBody2D.AddForce(new Vector3(
                direction.x * -1, // Opposite direction
                direction.y * power, // Increase Y
                transform.position.z)); // Don't change z coord
        }

        yield return 0;
    }

    public void PlaySound(int clip)
    {
        audioSource.clip = audioClips[clip];
        audioSource.Play();
    }
}
