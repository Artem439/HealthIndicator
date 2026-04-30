using Base;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Image))]
    public class PercentBarChanger : MonoBehaviour
    {
        [SerializeField] private HealthBase _playerHealth;
        
        private Image _image;
        
        private float _healthDivider = 100f;
        private float _minHealth = 0f;

        private void Awake()
        {
            _image = GetComponent<Image>();
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
                _image.fillAmount = _minHealth;
                
                return;
            }
            
            _image.fillAmount = currentHealth / _healthDivider;
        }
    }
}