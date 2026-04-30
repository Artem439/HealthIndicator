using Base;
using TMPro;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextBarChanger : MonoBehaviour
    {
        [SerializeField] private HealthBase _playerHealth;
        
        private TextMeshProUGUI _text;
        
        private float _minHealth = 0f;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            _playerHealth.HealthChanged += Changer;
        }

        private void OnDisable()
        {
            _playerHealth.HealthChanged -= Changer;
        }

        private void Changer(float currentHealth, float maxHealth)
        {
            if (currentHealth <= _minHealth)
            {
                _text.text = _minHealth + "/" + maxHealth;
                
                return;
            }
            
            _text.text = currentHealth + "/" + maxHealth;
        }
    }
}