using UnityEngine;

namespace Core
{
    public class Player
    {
        public int Health { get; set; } = 50;
        public int Lives { get; private set; } = 3;
        public int Score { get; private set; } = 0;
        public bool IsAlive => Health > 0 && Lives > 0;
        
        public ScoreCalculator ScoreCalculator { get; set; } = new ScoreCalculator();

        public void TakeDamage(int amount)
        {
            if (amount > 0)
            {
                if (Health - amount >= 0)
                {
                    Health -= amount;
                }
                else
                {
                    LoseLife();
                }
            }
        }

        public void Heal(int amount)
        {
            if (amount > 0 && Health > 0)
            {
                if ( Health + amount > 100)
                {
                    Health = 100;
                }
                else
                {
                    Health += amount;
                }
            }
        }

        public void AddScore(int points)
        {
            if(points <= 0) return; // Prevent negative score addition
            ScoreCalculator.ApplyCombo();
            Score += ScoreCalculator.CalculateScore(points);
        }

        public void LoseLife()
        {
            if (Lives > 0)
            {
                Lives--;
                Health = 100;
                ScoreCalculator.ResetCombo();
            }
        }

    }
}
