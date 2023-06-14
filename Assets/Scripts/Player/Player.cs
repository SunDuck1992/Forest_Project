using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private const string SaveKey = "SavedInteger";

    private int _currentHealth;

    public int CurrentHealth => _currentHealth;

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction Died;

    private void OnEnable()
    {
        _currentHealth = _health;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if(_currentHealth <= 0)
        {
            OnDied();
        }
    }

    public void GetHeal(int heal)
    {
        _currentHealth += heal;

        if(_currentHealth > _health)
        {
            _currentHealth = _health;
        }

        HealthChanged?.Invoke(_currentHealth, _health);
    }

    public void SaveHealth()
    {
        PlayerPrefs.SetInt(SaveKey, CurrentHealth);
        PlayerPrefs.Save();
    }

    public void LoadHealth()
    {
        if (PlayerPrefs.HasKey(SaveKey))
        {
            _currentHealth = PlayerPrefs.GetInt(SaveKey);
            HealthChanged?.Invoke(_currentHealth, _health);
        }
    }

    private void OnDied()
    {
        Died?.Invoke();
    }
}
