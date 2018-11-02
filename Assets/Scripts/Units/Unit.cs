using Assets.Scripts.Abstract;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Units
{
    [RequireComponent(typeof(Health))]
    public class Unit : MonoBehaviour
    {

        [Range(1, 10)]
        public int Range;
        public float Attack;
        public float MagicAttack;
        public float Defense;
        public float MagicDefense;
        public Health Health;
        public Element Element;
        public UnitType UnitType;

        private void Start()
        {
            Health = GetComponent<Health>();
            Health.Death += Die;
            Health.OnTakeDamage += OnTakeDamage;
        }

        private void Update()
        {

        }

        private void Die()
        {
            Destroy(gameObject);
        }

        private void OnTakeDamage(ref float amount)
        {
            amount -= Defense;
            amount -= MagicDefense;
            if (amount <= 0)
                amount = 0;
        }

    }
}
