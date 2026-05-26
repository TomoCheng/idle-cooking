using TMPro;
using UnityEngine;

namespace Kitchen.UI
{
	public class Unit_Progress : Tomo.UI.Unit
	{
		// Public
		public void SetValue(float progressValue, float maxValue)
		{
			_progressValue = progressValue;
			_maxValue = maxValue;
		}

		// Protected
		protected override void OnTick()
		{
			int progressValue = Mathf.RoundToInt(_progressValue);
			int maxValue = Mathf.RoundToInt(_maxValue);

			if (progressValue != _lastProgressValue)
			{
				_lastProgressValue = progressValue;
				_text_ProgressValue.SetText("{0}", progressValue);
			}
			if (maxValue != _lastMaxValue)
			{
				_lastMaxValue = maxValue;
				_text_MaxValue.SetText("{0}", maxValue);
			}
		}

		// Serialized properties
		[SerializeField] private TextMeshProUGUI _text_ProgressValue;
		[SerializeField] private TextMeshProUGUI _text_MaxValue;

		// Variable
		private float _progressValue;
		private float _maxValue;
		private int _lastProgressValue = int.MinValue;
		private int _lastMaxValue = int.MinValue;
	}
}