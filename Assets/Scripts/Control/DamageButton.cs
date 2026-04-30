using Base;
using UnityEngine;
using UnityEngine.UI;

namespace Control
{
    [RequireComponent(typeof(Button))]
    public class DamageButton : MonoBehaviour
    {
        [SerializeField] private HealthBase _health;
        [SerializeField] private float _damage;
    
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(DealDamage);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(DealDamage);
        }
    
        private void DealDamage()
        {
            _health.TakeDamage(_damage);
        }
    }
}
