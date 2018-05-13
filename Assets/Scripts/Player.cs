using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public float speed;
    public float projectileSpeed;

    public float fireCooldown;
    public float fireTimer;
    public bool fireReady;

    public GameObject projectile;
    public GameObject deathEffect;

    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHealth;

        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetKey("a"))
        {
            transform.Translate(new Vector3(-speed, 0, 0));
        }

        if (Input.GetKey("s"))
        {
            transform.Translate(new Vector3(0, -speed, 0));
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(new Vector3(speed, 0, 0));
        }

        if (Input.GetKey("w"))
        {
            transform.Translate(new Vector3(0, speed, 0));
        }

        if (fireTimer < 0)
        {
            fireReady = true;
        }
        else
        {
            fireTimer -= Time.deltaTime;
            fireReady = false;
        }

        if (Input.GetKey("space"))
        {
            if (fireReady)
            {
                GameObject newObj = Instantiate(projectile, transform.position, projectile.transform.rotation);
                newObj.GetComponent<Rigidbody>().AddForce(new Vector3(0, projectileSpeed, 0));

                fireTimer = fireCooldown;
            }
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
    }

    public void Revive()
    {
        gameObject.SetActive(true);
        currentHealth = maxHealth;
    }

    public void Die()
    {
        gameObject.SetActive(false);
        Instantiate(deathEffect, transform.position, deathEffect.transform.rotation);
    }
}
