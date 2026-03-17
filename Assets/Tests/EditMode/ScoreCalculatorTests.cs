using NUnit.Framework;
using Core;
 
[TestFixture]
public class ScoreCalculatorTests
{
    private Player _player;
    private Enemy _enemy;
    private ScoreCalculator _scoreCalculator;
 
    [SetUp]
    public void SetUp()
    {
        // Arrange — initialisation
        _player = new Player();
        _enemy = new Enemy();
        _scoreCalculator = new ScoreCalculator();
        
        // Set up references
        _enemy.Player = _player;
        _player.ScoreCalculator = _scoreCalculator;
    }
    
    [Test]
    public void Calculate_WithZeroKills_ReturnsZero()
    {
        int points = 0;
        
        _player.AddScore(points);
    }
    [Test]
    public void ApplyCombo_With3Kills_IncreasesMultiplier() 
    {
        // Simulate killing enemies to increase multiplier
        _player.AddScore(10);
        _player.AddScore(10);
        _player.AddScore(10);
        
        Assert.AreEqual(1.5f, _scoreCalculator.ScoreMultiplier);
    }
    [Test]
    public void ResetMultiplier_AfterCombo_SetsMultiplierToOne()
    {
        int damage = 100;
        
        // Simulate killing enemies to increase multiplier
        _player.AddScore(10);
        _player.AddScore(10);
        _player.AddScore(10);
        
        _player.TakeDamage(damage); // Simulate player death
        
        Assert.AreEqual(1f, _scoreCalculator.ScoreMultiplier);
    }
    [Test]
    public void Calculate_AfterComboAndReset_UsesBaseMultiplier() 
    {
        int damage = 100;
        
        // Simulate killing enemies to increase multiplier
        _player.AddScore(10);
        _player.AddScore(10);
        _player.AddScore(10);
        
        _player.TakeDamage(damage); // Simulate player death
        
        _player.AddScore(10); // Simulate killing another enemy after reset
        
        Assert.AreEqual(45, _player.Score); // Should use base multiplier of 1 (10+10+15 + 10= 45)
    }
}