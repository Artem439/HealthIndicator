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
            if (currentHealth <= 0)
            {
                _text.text = 0 + "/" + maxHealth;
                
                return;
            }
            
            _text.text = currentHealth + "/" + maxHealth;
        }
    }
}