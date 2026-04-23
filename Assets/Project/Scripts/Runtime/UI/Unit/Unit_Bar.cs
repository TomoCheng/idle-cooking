using UnityEngine;
using UnityEngine.UI;

namespace Kitchen.UI
{
	public class Unit_Bar : Tomo.UI.Unit
	{
        // Public
        public void SetValue(float value)
        {
            _value = value;
        }

        // Protected
        protected override void OnTick()
        {
            _image_Fill.fillAmount = Mathf.Clamp01(_value);
        }

        // Serialized properties
        [SerializeField] private Image _image_Fill;

        // Variable
        private float _value;
    }
}