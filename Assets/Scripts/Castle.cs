using Assets.Scripts.Abstract;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Health))]
    public class Castle : MonoBehaviour
    {

        public Health Health;

        private void Start()
        {
            Health = GetComponent<Health>();
            Health.Death += Die;
        }

        private void Update()
        {
            
        }

        private void Die()
        {
            // todo: end game
        }

    }
}
