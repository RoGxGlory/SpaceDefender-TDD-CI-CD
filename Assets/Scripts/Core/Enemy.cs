using UnityEngine;

namespace Core
{
    public class Enemy
    {
        public int Health { get; set; } = 50;
        public bool IsAlive => Health > 0;
        public int BasePoints { get; set; } = 10;
        
        public bool Looted = false; // This would be set to true when the player loots the enemy
        public Player Player { get; set; }

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
                    Health = 0;
                    GetReward();
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
        
        public int GetReward()
        {
            if (Looted == false)
            {
                if (!IsAlive)
                {

                    Looted = true; // Mark as looted to prevent multiple rewards
                    Player.AddScore(BasePoints);
                    return BasePoints;
                }
            }
            return 0;
        }
    }
}
