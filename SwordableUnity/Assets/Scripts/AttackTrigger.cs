using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.CompareTag("Enemy"))
        {
            // Call to method Damage
            collision.SendMessageUpwards("Damage", damage);
        }
    }
}
