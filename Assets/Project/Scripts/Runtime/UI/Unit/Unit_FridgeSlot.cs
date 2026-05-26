using Cysharp.Threading.Tasks;
using Kitchen.Runtime;
using Tomo.Asset;
using UnityEngine;
using UnityEngine.UI;

namespace Kitchen.UI
{
	public class Unit_FridgeSlot : Tomo.UI.Unit
	{
		// Public
		public void Setup(FridgeSlot fridgeSlot)
		{
			_fridgeSlot = fridgeSlot;
		}

		// Protected
		protected override void OnRefresh()
		{
			RefreshAsync().Forget();
		}
		protected override void OnTick()
		{
			if (_fridgeSlot == null) { return; }

			float progress = _fridgeSlot.FixedProduceTime - _fridgeSlot.RemainingTime;
			_unit_Bar.SetValue(progress, _fridgeSlot.FixedProduceTime);
			_unit_Bar.Tick();
			_unit_Timer.SetValue(progress, _fridgeSlot.FixedProduceTime);
			_unit_Timer.Tick();
		}

		// Private
		private async UniTask RefreshAsync()
		{
			if (_fridgeSlot == null || _fridgeSlot.Ingredient == null)
			{
				_image_Ingredient.enabled = false;
				return;
			}

			string iconName = _fridgeSlot.Ingredient.FridgeSlotIconName;
			if (iconName == _loadedIconName)
			{
				_image_Ingredient.enabled = true;
				return;
			}

			Sprite sprite = await AssetManager.Instance.LoadAsset<Sprite>(iconName, this.GetCancellationTokenOnDestroy());
			if (sprite == null) { return; }

			_loadedIconName = iconName;
			_image_Ingredient.sprite = sprite;
			_image_Ingredient.enabled = true;
		}

		// Serialized properties
		[SerializeField] private Unit_Bar _unit_Bar;
		[SerializeField] private Unit_Timer _unit_Timer;
		[SerializeField] private Image _image_Ingredient;

		// Variable
		private FridgeSlot _fridgeSlot;
		private string _loadedIconName;
	}
}