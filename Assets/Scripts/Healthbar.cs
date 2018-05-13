using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {
    /*
	private EnemyController enemy;
	private RectTransform healthBar;
	private GameObject mainCamera;

	private float initSize;

	// Use this for initialization
	void Start ()
	{
		enemy = transform.parent.gameObject.GetComponent<EnemyController>();


		healthBar = transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();

		initSize = healthBar.localScale.x;

		GetComponent<Canvas>().enabled = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (enemy.currentHealth < enemy.maxHealth && GetComponent<Canvas>().enabled == false)
		{
			GetComponent<Canvas>().enabled = true;
		}
			

		float healthRatio = (float)enemy.currentHealth / (float)enemy.maxHealth;

		if (!float.IsNaN(healthRatio))
		{
			healthBar.localScale = new Vector3(initSize * healthRatio, healthBar.localScale.y, healthBar.localScale.z);
		}


	}
    */
}
