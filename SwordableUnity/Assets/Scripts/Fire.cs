using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public int damage = 35;

    public int knobackPower = 80;

    private Player player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerCollider"))
        {
            player.Damage(damage);

            StartCoroutine(player.Knockback(0.02f, knobackPower, player.transform.position));
        }
    }

    public void Damaged(int damage)
    {
        Destroy(transform.parent.gameObject);
    }
}
