using UnityEngine;
using UnityEngine.UI;

namespace Kitchen.UI
{
	public class Unit_Timer : Tomo.UI.Unit
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
            _image_Fill.fillAmount = Mathf.Clamp01(_progressValue / _maxValue);
        }

        // Serialized properties
        [SerializeField] private Image _image_Fill;

        // Variable
        private float _progressValue;
        private float _maxValue;
    }
}