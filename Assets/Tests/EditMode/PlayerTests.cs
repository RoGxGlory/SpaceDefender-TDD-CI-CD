using NUnit.Framework;
using Core;
 
[TestFixture]
public class PlayerTests
{
    private Player _player;
 
    [SetUp]
    public void SetUp()
    {
        _player = new Player();   // Arrange — initialisation
    }
    
    [Test]
    public void TakeDamage_Normal_ReducesHealth()
    {
        int damage = 20;
 
        _player.TakeDamage(damage);
 
        Assert.AreEqual(30, _player.Health);
    }

    [Test]
    public void TakeDamage_WithFatalDamage_SetsHealthToZero()
    {
        int damage = 150;
        
        _player.TakeDamage(damage);
        
        Assert.AreEqual(2, _player.Lives);
    }
    [Test]
    public void TakeDamage_WithNegativeAmount_DoesNotChangeHealth() 
    {
        int damage = -10;
        
        _player.TakeDamage(damage);
        
        Assert.AreEqual(50, _player.Health);
    }

    [Test]
    public void Heal_WhenHealthBelow100_IncreasesHealth() 
    {
        int healAmount = 30;
        
        _player.Heal(healAmount);
        
        Assert.AreEqual(80, _player.Health);
    }
    [Test]
    public void Heal_WhenAlreadyFullHealth_DoesNotExceed100()
    {
        _player.Health = 100;
        
        int healAmount = 30;
        
        _player.Heal(healAmount);
        
        Assert.AreEqual(100, _player.Health);
    }
    [Test]
    public void IsAlive_WhenHealthIsZero_ReturnsFalse() 
    {
        _player.Health = 0;
        
        bool isAlive = _player.IsAlive;
        
        Assert.IsFalse(isAlive);
    }
    [Test]
    public void LoseLife_WhenLastLife_IsAliveReturnsFalse() 
    {
        int damage = 150;
        
        _player.TakeDamage(damage);
        _player.TakeDamage(damage);
        _player.TakeDamage(damage);
        
        bool isAlive = _player.IsAlive;
        
        Assert.IsFalse(isAlive);
    }
}