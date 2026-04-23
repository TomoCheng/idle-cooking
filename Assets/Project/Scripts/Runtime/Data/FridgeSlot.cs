using Kitchen.Data;

namespace Kitchen.Runtime
{
    public class FridgeSlot
    {
        // Constructor
        public FridgeSlot(IngredientClient ingredientClient)
        {
            _ingredientClient = ingredientClient;
            _remainingTime = GetFixedProduceTime();
        }

        // Properties
        public IngredientClient IngredientClient => _ingredientClient;
        public Ingredient Ingredient => _ingredientClient.ingredient;
        public float RemainingTime => _remainingTime;
        public float Progress => Ingredient != null ? 1f - (_remainingTime / GetFixedProduceTime()) : 0f;
        public bool IsReady => _remainingTime <= 0 && Ingredient != null;

        // Public
        public void Tick(float deltaTime)
        {
            if (Ingredient == null || _remainingTime <= 0) return;
            _remainingTime -= deltaTime;

            if (IsReady)
            {
                Collect();
            }
        }
        public void Collect()
        {
            _remainingTime = GetFixedProduceTime();
        }

        // Private
        private float GetFixedProduceTime()
        {
            if (IngredientClient == null) return 0f;
            return Ingredient.BaseProduceTime / IngredientClient.SpeedMultiplier;
        }

        // Variable
        private IngredientClient _ingredientClient;
        private float _remainingTime;
    }
}