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

        private void Awake()
        {
            _image = GetComponent<Image>();
        }
        
        private void OnEnable()
        {
            _playerHealth.HealthChanged += OnHealthValueChanger;
        }

        private void OnDisable()
        {
            _playerHealth.HealthChanged -= OnHealthValueChanger;
        }
        
        private void OnHealthValueChanger(float currentHealth, float maxHealth)
        {
            _image.fillAmount = currentHealth / maxHealth;
        }
    }
}