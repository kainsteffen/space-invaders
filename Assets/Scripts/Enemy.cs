using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool active = true;
    public float maxHealth;
    public float currentHealth;
    public float attackDamage;
    public int scoreValue;

    public Renderer rend;

	// Use this for initialization
	public virtual void Start ()
    {
        currentHealth = maxHealth;

        rend = transform.GetComponentInChildren<Renderer>();
    }
	
	// Update is called once per frame
	public virtual void FixedUpdate ()
    {
        if (currentHealth <= 0 && active)
        {
            Die();
        }

        if (!active)
        {
            float dissolveFactor = Mathf.Lerp(rend.material.GetFloat("_Dissolve"), 1, 0.05f);
            rend.material.SetFloat("_Dissolve", dissolveFactor);

            if (rend.material.GetFloat("_Dissolve") > 0.99)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
    }

    public void Die()
    {
        GameController.Instance.IncreaseGameScore(scoreValue);
        active = false;
        GetComponent<BoxCollider>().enabled = false;
    }
}
