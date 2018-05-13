using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float damageAmount;
    public string source;

    public GameObject bulletSpark;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetSource(string sourceName)
    {
        source = sourceName;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collider = collision.gameObject;

        if (collider.tag == "Enemy")
        {
            collider.GetComponent<Enemy>().TakeDamage(damageAmount);
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        Instantiate(bulletSpark, transform.position, bulletSpark.transform.rotation);
    }
}
