using UnityEngine;

namespace Core
{
    public class ScoreCalculator
    {
        public float ScoreMultiplier { get; set; } = 1f;
        int ComboCount { get; set; } = 0;
        
        
        public int CalculateScore(int basePoints)
        {
            if (basePoints > 0)
            {
                return Mathf.RoundToInt(basePoints * ScoreMultiplier);
            }
            return 0;
        }
        
        public void ApplyCombo()
        {
            ComboCount++;
            if (ComboCount >= 3)
            {
                ScoreMultiplier += 0.5f; // Increase multiplier after 3 kills
                ComboCount = 0; // Reset combo count
            }
        }
        
        public void ResetCombo()
        {
            ScoreMultiplier = 1f; // Reset multiplier to base value
            ComboCount = 0; // Reset combo count
        }
    }
}

