using System;
using Assets.Scripts.Structs;
using UnityEngine;

namespace Assets.Scripts
{
    public class Inventory : MonoBehaviour
    {

        [Range(1, 10)]
        public int NumberOfElement;

        public delegate void InventoryChangeHandler();
        public event InventoryChangeHandler InventoryChange;

        private readonly UnitStruct[] _unitStructs;

        public Inventory()
        {
            _unitStructs = new UnitStruct[NumberOfElement];
            FillWithRandom();
        }

        public UnitStruct Get(int i)
        {
            if (i < 0 || i >= NumberOfElement)
                return _unitStructs[0];
            return _unitStructs[i];
        }

        private void FillWithRandom()
        {
            for (var i = 0; i < NumberOfElement; i++)
            {
                _unitStructs[i] = GetRandom();
            }
        }

        private UnitStruct GetRandom()
        {
            var values = Enum.GetValues(typeof(UnitStruct));
            var random = new System.Random();
            return (UnitStruct)values.GetValue(random.Next(values.Length));
        }

        public void AddElement(UnitStruct unitStruct)
        {
            for (var i = NumberOfElement - 2; i > 0; i--)
            {
                _unitStructs[i] = _unitStructs[i - 1];
            }
            _unitStructs[0] = unitStruct;
            OnInventoryChange();
        }

        protected void OnInventoryChange()
        {
            if (InventoryChange != null)
                InventoryChange();
        }

    }
}
