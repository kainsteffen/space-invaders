using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelWeapon : WeaponController
{
    public float maxLevel;
    public float level;

    public int maxShotCount;
    public int shooterCount;

    [HideInInspector]
    public int[] shooterCounts;

    [HideInInspector]
    public float[] shootCooldowns;

    [HideInInspector]
    public float[] projectileSpeeds;

    [HideInInspector]
    public float[] blooms;

    [HideInInspector]
    public int[] pulseCounts;

    [HideInInspector]
    public float[] pulseIntervals;

    [HideInInspector]
    public MultiFloat[] offAngles;

    [HideInInspector]
    public MultiFloat[] offPositions;

    [HideInInspector]
    public MultiFloat[] offIntervals;

    public GameObject equippedWeapon;
    private GameObject lvlUpMsg;

    private Object[] weapons;

    public void InitArrays()
    {
        shooterCounts = new int[(int)maxLevel];

        shootCooldowns = new float[(int)maxLevel];

        projectileSpeeds = new float[(int)maxLevel];

        blooms = new float[(int)maxLevel];

        pulseCounts = new int[(int)maxLevel];

        pulseIntervals = new float[(int)maxLevel];

        offAngles = new MultiFloat[maxShotCount + 1];
        offPositions = new MultiFloat[maxShotCount + 1];
        offIntervals = new MultiFloat[maxShotCount + 1];

        for (int i = 0; i < maxShotCount; i++)
        {
            offAngles[i] = new MultiFloat(maxShotCount + 1);
            offPositions[i] = new MultiFloat(maxShotCount + 1);
            offIntervals[i] = new MultiFloat(maxShotCount + 1);
        }
    }

    public override void Start()
    {
        base.Start();

        lvlUpMsg = (GameObject)Resources.Load("UI/LvlUpMsg");

        if (shooterCount <= 0)
        {
            shooterCount = 1;
        }

        shooterCount = shooterCounts[(int)level];
    }

    void Update()
    {
        shooterCount = shooterCounts[(int)level];

        if (shooterCount != transform.childCount)
        {
            UpdateShooterCount();
        }
    }

    private void UpdateShooterCount()
    {
        foreach (Transform child in transform)
        {
            shooters.Remove(child.gameObject);
            Destroy(child.gameObject);
        }

        for (int i = 0; i < shooterCount; i++)
        {
            ProjectileWeapon newShooter = Instantiate(equippedWeapon, transform).GetComponent<ProjectileWeapon>();
            AdjustStatsToLevel(newShooter);

            shooters.Add(newShooter.gameObject);
        }

        SetShooterPattern();
    }

    private void SetShooterPattern()
    {
        for (int i = 0; i < shooters.Count; i++)
        {
            GameObject current = shooters[i];

            current.transform.localPosition = new Vector3(offPositions[shooterCount - 1][i], 0, 0);

            current.transform.rotation = transform.rotation;
            current.transform.Rotate(0, offAngles[shooterCount - 1][i], 0);
        }

        SetShooterInterval();
    }

    public override void SetShooterInterval()
    {
        for (int i = 0; i < shooters.Count; i++)
        {
            ProjectileWeapon current = shooters[i].GetComponent<ProjectileWeapon>();

            current.pulseCounter = current.pulseCount;
            current.pulseTimer = 0;
            current.shootTimer = offIntervals[shooterCount - 1][i];
        }
    }

    public void IncreaseLevel(float expAmount)
    {
        float currentLvl = level;

        level = Mathf.Clamp(level + expAmount, 0, maxLevel);

        if ((int)currentLvl < (int)level)
        {
            LevelUp();
        }
    }

    private void AdjustStatsToLevel(ProjectileWeapon shooter)
    {
        shooter.shootCooldown = shootCooldowns[(int)level];
        shooter.projectileSpeed = projectileSpeeds[(int)level];
        shooter.bloom = blooms[(int)level];
        shooter.pulseCount = pulseCounts[(int)level];
        shooter.pulseInterval = pulseIntervals[(int)level];
    }

    private void LevelUp()
    {
        foreach (GameObject shooter in shooters)
        {
            AdjustStatsToLevel(shooter.GetComponent<ProjectileWeapon>());
        }

        //Instantiate(lvlUpMsg, transform.position, lvlUpMsg.transform.rotation).GetComponent<StickToTarget>().target = transform;
    }
}
