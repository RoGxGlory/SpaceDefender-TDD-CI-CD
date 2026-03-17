using NUnit.Framework;
using Core;
 
[TestFixture]
public class EnemyTests
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
    public void TakeDamage_WhenKilled_SetsIsAliveToFalse()
    {
        int damage = 100;
        
        _enemy.TakeDamage(damage);
        
        Assert.IsFalse(_enemy.IsAlive);
    }
    [Test]
    public void GetReward_WhenAlreadyDead_ReturnsZero()
    {
        int damage = 100;
        
        _enemy.TakeDamage(damage);
        
        Assert.AreEqual(0, _enemy.GetReward());
    }
}