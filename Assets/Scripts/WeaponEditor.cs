using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(LevelWeapon))]
public class WeaponEditor : Editor
{
    LevelWeapon weapon;

    bool[] sprayPatternFolds;
    bool[] levelStats;

    private void OnEnable()
    {
        weapon = (LevelWeapon)target;
        sprayPatternFolds = new bool[weapon.maxShotCount];
        levelStats = new bool[(int)weapon.maxLevel];
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUILayout.Space(10);

        
        if (GUILayout.Button("Initialize Weapon Arrays"))
        {
            weapon.InitArrays();
            sprayPatternFolds = new bool[weapon.maxShotCount];
            levelStats = new bool[(int)weapon.maxLevel];
        }

        GUILayout.Space(10);

        GUILayout.Label("Weapon Level Stats");

        GUILayout.Space(10);

        for (int i = 0; i < weapon.maxLevel; i++)
        {

            levelStats[i] = EditorGUILayout.Foldout(levelStats[i], "Weapon level " + i);

            EditorGUI.indentLevel++;

            if (levelStats[i])
            {
                GUILayout.Space(10);

                weapon.shooterCounts[i] = EditorGUILayout.IntField("Shooter Count", weapon.shooterCounts[i]);
                weapon.shootCooldowns[i] = EditorGUILayout.FloatField("Shoot Cooldown", weapon.shootCooldowns[i]);
                weapon.projectileSpeeds[i] = EditorGUILayout.FloatField("Projectile Speed", weapon.projectileSpeeds[i]);
                weapon.blooms[i] = EditorGUILayout.FloatField("Bloom", weapon.blooms[i]);
                weapon.pulseCounts[i] = EditorGUILayout.IntField("Pulse Count", weapon.pulseCounts[i]);
                weapon.pulseIntervals[i] = EditorGUILayout.FloatField("Pulse Interval", weapon.pulseIntervals[i]);

                GUILayout.Space(10);
            }

            EditorGUI.indentLevel--;
        }

        GUILayout.Space(10);

        GUILayout.Label("Weapon Spray Pattern");

        GUILayout.Space(10);

        for (int i = 0; i < weapon.maxShotCount; i++)
        {
            sprayPatternFolds[i] = EditorGUILayout.Foldout(sprayPatternFolds[i], "Weapon x " + (i + 1));

            if (sprayPatternFolds[i])
            {
                GUILayout.Space(10);

                EditorGUI.indentLevel++;

                for (int j = 0; j < i + 1; j++)
                {
                    GUILayout.Label("Gun " + j);

                    GUILayout.Space(3);

                    weapon.offAngles[i][j] = EditorGUILayout.FloatField("Angle Offset", weapon.offAngles[i][j]);
                    weapon.offPositions[i][j] = EditorGUILayout.FloatField("Position Offset", weapon.offPositions[i][j]);
                    weapon.offIntervals[i][j] = EditorGUILayout.FloatField("Interval Offset", weapon.offIntervals[i][j]);

                    GUILayout.Space(10);
                }

                EditorGUI.indentLevel--;

                GUILayout.Space(10);
            }
        }
             
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}

