using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : Enemy
{
    public GameObject target;
    public float speed;
    public float turnSpeed;

    private Rigidbody rb;

	// Use this for initialization
	public override void Start ()
    {
		base.Start();

        target = GameController.Instance.player;
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	public override void FixedUpdate ()
    {
		base.FixedUpdate();

        if (active)
        {
            rb.AddForce(transform.forward * speed);

            Vector3 targetVec = target.transform.position - transform.position;

            Quaternion targetRot = Quaternion.LookRotation(targetVec, new Vector3(0, 0, 1));

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, turnSpeed);
        }
	}
}
