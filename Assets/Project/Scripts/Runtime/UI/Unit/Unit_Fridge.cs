using Kitchen.Runtime;
using Kitchen.Systems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Kitchen.UI
{
	public class Unit_Fridge : Tomo.UI.Unit
	{
		// Public
		public void Setup()
		{
			CreateSlot();
			Refresh();
		}

		// Protected
		protected override void OnRefresh()
		{
			foreach (Unit_FridgeSlot unit in _unit_fridgeSlotList)
			{
				unit.Refresh();
			}
		}
		protected override void OnTick()
		{
			foreach (Unit_FridgeSlot unit in _unit_fridgeSlotList)
			{
				unit.Tick();
			}
		}

		// Private
		private void Awake()
		{
			Setup();//TEMP: 之後改由 View_Kitchen 驅動
		}
		private void Update()
		{
			Tick();//TEMP: 之後改由 View_Kitchen 驅動
		}
		private void CreateSlot()
		{
			if (_unit_FridgeSlot_Prefab == null || _gridLayoutGroup_Slot == null)
			{
				Debug.LogError($"[Kitchen.UI] {name} is missing references", this);
				return;
			}

			foreach (Transform child in _gridLayoutGroup_Slot.transform)
			{
				Destroy(child.gameObject);
			}
			_unit_fridgeSlotList.Clear();

			foreach (FridgeSlot fridgeSlot in FridgeSlotManager.Instance.FridgeSlotList)
			{
				Unit_FridgeSlot unit = Instantiate(_unit_FridgeSlot_Prefab, _gridLayoutGroup_Slot.transform);
				unit.Setup(fridgeSlot);
				_unit_fridgeSlotList.Add(unit);
			}
		}

		// Serialized properties
		[SerializeField] private GridLayoutGroup _gridLayoutGroup_Slot;
		[SerializeField] private Unit_FridgeSlot _unit_FridgeSlot_Prefab;

		// Variable
		private List<Unit_FridgeSlot> _unit_fridgeSlotList = new List<Unit_FridgeSlot>();
	}
}