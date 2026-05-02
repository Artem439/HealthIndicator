using Base;
using UnityEngine;
using UnityEngine.UI;

namespace Control
{
    [RequireComponent(typeof(Button))]
    public class HealButton : MonoBehaviour
    {
        [SerializeField] private HealthBase _health;
        [SerializeField] private float _healAmount;
    
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(AddHealth);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(AddHealth);
        }
    
        private void AddHealth()
        {
            _health.Healing(_healAmount);
        }
    }
}