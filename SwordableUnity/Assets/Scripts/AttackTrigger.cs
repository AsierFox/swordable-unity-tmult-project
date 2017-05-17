using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public int damage = 1;
    public float health = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger && collision.CompareTag("Attackable"))
        {
            // Call to method Damage
            collision.SendMessageUpwards("Damaged", damage);
        }
    }
}
