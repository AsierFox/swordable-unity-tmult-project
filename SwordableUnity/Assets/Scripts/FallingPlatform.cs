using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

    public float fallDelay = 1f;

    private Rigidbody2D rigitBody2D;

    private void Start()
    {
        rigitBody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D﻿(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerCollider"))
        {
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);

        rigitBody2D.isKinematic = false;

        yield return 0;
    }
}
