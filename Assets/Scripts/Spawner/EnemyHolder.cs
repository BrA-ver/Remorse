using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHolder : MonoBehaviour
{
    [SerializeField] List<Enemy> enemies;
    public UnityEvent enemiesDestroyed;

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            Enemy enemy = child.GetComponent<Enemy>();
            if (enemy)
            {
                enemies.Add(enemy);
                enemy.onEnemyDestroy.AddListener(OnEnemyDestroy);
            }
        }
    }

    private void OnDisable()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.onEnemyDestroy.RemoveListener(OnEnemyDestroy);
        }
    }

    void OnEnemyDestroy(Enemy enemy)
    {
        enemies.Remove(enemy);
        bool enemiesActive = enemies.Count > 0f;
        
        if (!enemiesActive)
        {
            enemiesDestroyed.Invoke();
        }
    }



    public void ActivateEnemies()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.gameObject.SetActive(true);
        }
    }
}
