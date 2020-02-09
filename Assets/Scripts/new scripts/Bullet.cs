using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidBody2D;
    BoxCollider2D coll2D;

    private void Start() {
        rigidBody2D = GetComponent<Rigidbody2D>();
        coll2D = GetComponent<BoxCollider2D>();
        rigidBody2D.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.layer == 12) //enemy layer
        {
            Debug.Log("hit enemy");
            GameManager.instance.AddScore(1);
            Destroy(other.gameObject);  //TODO: create funct to deal damage and handel player/enemy health later
            Destroy(gameObject);
        }
        else if (other.gameObject.layer == 8) // ground layer
        {
            Destroy(gameObject);
        }
    }
}
