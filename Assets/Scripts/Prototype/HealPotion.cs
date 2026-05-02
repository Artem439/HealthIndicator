using Base;
using UnityEngine;

namespace Prototype
{
    public class HealPotion : MonoBehaviour
    {
        [SerializeField] private HealthBase _health;
        [SerializeField] private float _healAmount;
    
        public void Collect()
        {
            _health.Healing(_healAmount);
        }
    }
}