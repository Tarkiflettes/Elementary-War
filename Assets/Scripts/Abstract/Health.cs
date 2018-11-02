using UnityEngine;

namespace Assets.Scripts.Abstract
{
    public class Health : MonoBehaviour
    {

        public float StartingHealth = 100f;
        public float CurrentHealth
        {
            get { return _currentHealth; }
            set
            {
                _currentHealth = value;
                OnHealthChange();
            }
        }

        public delegate void TakeDamageChangeHandler(ref float amount);
        public event TakeDamageChangeHandler OnTakeDamage;
        public delegate void HealthChangeHandler();
        public event HealthChangeHandler HealthChange;
        public delegate void DeathHandler();
        public event DeathHandler Death;

        private float _currentHealth;

        private void Start()
        {
            CurrentHealth = StartingHealth;
        }

        /// <summary>
        /// calculates the actual damage with the protection and reduces CurrentHealth
        /// </summary>
        /// <param name="amount">Amount of damages</param>
        public void AddHealth(float amount)
        {
            CurrentHealth += amount;
            if (CurrentHealth > StartingHealth)
                CurrentHealth = StartingHealth;
        }

        /// <summary>
        /// calculates the actual damage with the protection and reduces CurrentHealth
        /// </summary>
        /// <param name="amount">Amount of damages</param>
        public virtual void TakeDamage(float amount)
        {
            if (CurrentHealth <= 0)
                return;

            if (OnTakeDamage != null)
                OnTakeDamage(ref amount);

            Debug.Log(gameObject.name + " TakeDamage (" + amount + ")");

            if (amount < 0)
                amount = 0;
            CurrentHealth -= amount;

            if (CurrentHealth > 0)
                return;

            Debug.Log(gameObject.name + " has died");
            if (Death != null)
                Death();
        }

        protected void OnHealthChange()
        {
            if (HealthChange != null)
                HealthChange();
        }

    }
}
