using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public bool shooting = true;
    public List<GameObject> shooters;

    // Use this for initialization
    public virtual void Start()
    {
        shooters = new List<GameObject>();

        foreach (Transform child in transform)
        {
            shooters.Add(child.gameObject);
        }

        if (transform.parent)
        {
            gameObject.tag = transform.parent.gameObject.tag;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void SetShooterInterval()
    {
        for (int i = 0; i < shooters.Count; i++)
        {
            ProjectileWeapon current = shooters[i].GetComponent<ProjectileWeapon>();

            current.pulseCounter = current.pulseCount;
            current.pulseTimer = 0;
            current.shootTimer = current.shootCooldown;
        }
    }

    public void StartShooting()
    {
        if (!shooting)
        {
            shooting = true;
            SetShooterInterval();
        }
    }

    public void StopShooting()
    {
        if (shooting)
        {
            shooting = false;
        }
    }
}
