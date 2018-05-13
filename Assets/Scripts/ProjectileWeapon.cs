using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    public WeaponController weapon;
    public GameObject projectile;

    public float shootCooldown;
    public float projectileSpeed;

    public float bloom;

    public int pulseCount;
    public float pulseInterval;

    public int pulseCounter;
    public float pulseTimer;
    public float shootTimer;

    public virtual void Start() //start is called later than the shooter spread is set in the controller
    {
        weapon = transform.parent.GetComponent<WeaponController>();
        gameObject.tag = transform.parent.tag;

        pulseCounter = pulseCount;
    }

    public virtual void FixedUpdate()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        else if(weapon.shooting)
        {
            if (pulseTimer < 0)
            {
                //SoundManager.Instance.Play("ShootBullet");

                GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
                bullet.GetComponent<ProjectileController>().SetSource(transform.parent.tag);

                if (transform.parent.tag == "Player")
                {
                    bullet.layer = LayerMask.NameToLayer("PlayerProjectile");
                }
                else if(transform.parent.tag == "Enemy")
                {
                    bullet.layer = LayerMask.NameToLayer("EnemyProjectile");
                }


                float randomBloom = Random.Range(0, bloom);

                if (Random.value < 0.5f)
                {
                    randomBloom *= -1;
                }

                bullet.transform.Rotate(0, randomBloom, 0);

                Vector3 force = bullet.transform.forward * projectileSpeed;

                bullet.GetComponent<Rigidbody>().AddForce(force);

                pulseCounter--;

                pulseTimer = pulseInterval;
            }
            else if (pulseCounter <= 0)
            {
                pulseCounter = pulseCount;
                shootTimer = shootCooldown;
            }
            else
            {
                pulseTimer -= Time.deltaTime;
            }
        }
    }
}
