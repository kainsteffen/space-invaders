using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWeapon : ProjectileWeapon
{
    // Use this for initialization
    public override void Start ()
    {
        base.Start();

        projectile = Resources.Load("WeaponAssets/Bullet") as GameObject;       
    }
	
	// Update is called once per frame
	public override void FixedUpdate()
    {
        base.FixedUpdate(); 

    }    
}
