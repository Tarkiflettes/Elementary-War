using System.Collections;
using Assets.Scripts.Abstract;
using Assets.Scripts.Enums;
using UnityEngine;
using Element = Assets.Scripts.Enums.Element;

namespace Assets.Scripts.Units
{
    [RequireComponent(typeof(Health))]
    public class Unit : MonoBehaviour
    {

        [Range(1, 10)]
        public int Range;
        public float Attack;
        public float MagicAttack;
        public float AttackDelay;
        public float Defense;
        public float MagicDefense;
        public Health Health;
        public Element Element;
        public UnitType UnitType;

        private readonly Team _team;
        private bool _canAttack = true;
        private Collider2D _collision;

        public Unit(Team team)
        {
            _team = team;
        }

        private void Start()
        {
            Health = GetComponent<Health>();
            Health.Death += Die;
            Health.OnTakeDamage += OnTakeDamage;
        }

        private void Update()
        {
            if (_collision == null)
                gameObject.transform.Translate(new Vector3((float) _team, 0, 0) * Time.deltaTime);
            else
                TryToAttack();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _collision = collision;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _collision = null;
        }

        private void TryToAttack()
        {
            if (!_canAttack)
                return;
            _canAttack = false;
            var health = _collision.GetComponent<Health>();
            if (health == null)
                return;
            var unit = health.GetComponent<Unit>();
            if (unit == null || !unit.SameTeam(_team))
                health.TakeDamage(Attack + MagicAttack);
            StartCoroutine(ReloadAttack());
        }

        private IEnumerator ReloadAttack()
        {
            yield return new WaitForSeconds(AttackDelay);
            _canAttack = true;
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

        public bool SameTeam(Team team)
        {
            return team == _team;
        }

    }
}
