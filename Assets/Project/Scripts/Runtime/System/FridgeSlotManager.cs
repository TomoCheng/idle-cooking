using Cysharp.Threading.Tasks;
using Kitchen.Runtime;
using System.Collections.Generic;
using Tomo.Core;
using UnityEngine;

namespace Kitchen.Systems
{
	public class FridgeSlotManager : Singleton<FridgeSlotManager>
	{
		// Properties
		public List<FridgeSlot> FridgeSlotList => _fridgeSlotList;

		// Public
		public override UniTask Initialize()
		{
			Setup();
			return UniTask.CompletedTask;
		}
		public FridgeSlot GetSlot(int index)
		{
			return (index >= 0 && index < _fridgeSlotList.Count) ? _fridgeSlotList[index] : null;
		}

		// Private
		private void Setup()
		{
			_fridgeSlotList.Clear();
			foreach (var ingredient in IngredientManager.Instance.IngredientList)
			{
				_fridgeSlotList.Add(new FridgeSlot(new Data.IngredientClient(ingredient.Id)));
			}
		}
		private void Update()
		{
			// 驅動所有格子的計時
			foreach (var slot in _fridgeSlotList)
			{
				slot.Tick(Time.deltaTime);
			}
		}

		// Variable
		private List<FridgeSlot> _fridgeSlotList = new List<FridgeSlot>();
	}
}