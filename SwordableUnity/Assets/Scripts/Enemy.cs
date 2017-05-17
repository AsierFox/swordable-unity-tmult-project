using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = .3f;

    public AudioClip[] audioClips;

    private Rigidbody2D rigitBody2D;
    private AudioSource audioSource;

    void Start ()
    {
        rigitBody2D = gameObject.GetComponent<Rigidbody2D>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x - speed, transform.position.y, transform.position.z), 1000);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("PlayerCollider"))
        {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }
    }

    public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }

}
