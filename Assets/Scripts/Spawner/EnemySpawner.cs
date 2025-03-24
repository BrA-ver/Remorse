using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<EnemyHolder> holders;
    int currentEnemies;

    Hitbox hitbox;
    EnemyHealth health;
    [SerializeField] Slider healthSlider;

    public UnityEvent onDefeated, onBegin;

    private void Start()
    {
        health = GetComponent<EnemyHealth>();
        hitbox = GetComponentInChildren<Hitbox>();
        hitbox.gameObject.SetActive(false);

        healthSlider.gameObject.SetActive(false);

        foreach (Transform child in transform)
        {
            EnemyHolder holder = child.GetComponent<EnemyHolder>();
            if (holder)
            {
                holders.Add(holder);
                holder.enemiesDestroyed.AddListener(OnEnemiesDestroyed);
            }
        }
    }

    private void Update()
    {
        if (healthSlider.gameObject.activeInHierarchy)
        {
            healthSlider.value = health.HealthRatio;
        }
    }

    void OnEnemiesDestroyed()
    {
        currentEnemies++;
        if (currentEnemies >= holders.Count)
        {
            hitbox.gameObject.SetActive(true);
            healthSlider.gameObject.SetActive(true);
            return;
        }

        ActivateEnemies();
    }

    public void ActivateEnemies()
    {
        holders[currentEnemies].ActivateEnemies();
        onBegin.Invoke();
    }

    private void OnDestroy()
    {
        onDefeated.Invoke();
    }
}
