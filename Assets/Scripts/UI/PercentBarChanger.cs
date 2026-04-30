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
            if (currentHealth <= 0)
            {
                _image.fillAmount = 0;
                
                return;
            }
            
            _image.fillAmount = currentHealth / _healthDivider;
        }
    }
}