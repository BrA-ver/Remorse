using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    [SerializeField] Slider healthSlider;

    protected override void Start()
    {
        base.Start();
        UpdateUI();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        UpdateUI();
        if (currentHealth <= 0f)
        {
            UpdateUI();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Destroy(gameObject);
        }
    }

    void UpdateUI()
    {
        healthSlider.value = HealthRatio;
    }
}
