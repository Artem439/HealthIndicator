using System;
using UnityEngine;

namespace Base
{
    public class HealthBase : MonoBehaviour
    {
        [SerializeField] [Min(1)] private float _maxHealth;
        
        private float _currentHealth;
        
        public event Action Death;
    
                            //New code
        public event Action<float, float> HealthChanged;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(float damage)
        {
            if (damage <= 0) 
                return;

            _currentHealth -= damage;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
                
                            //New code
            if (_currentHealth < 0)
            {
                Death?.Invoke();                
                _currentHealth = 0;
            }
            
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
                            //New code
        public void Healing(float heal)
        {
            _currentHealth += heal;
        
            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;
        
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }
}