using JKFrame;

public class GameManager:Singleton<GameManager>
{
    public int talentsPoints
    {
        get;
        private set;
    }
    public int currentLevel
    {
        get;
        private set;
    }
    public void Init()
    {
        talentsPoints = 1;
        currentLevel=1;
    }
    public void LevelUp()
    {
        currentLevel++;
    }
    public void AddTalentPoints(int value)
    {
        talentsPoints+=value;
    }
    public void UseTalentPotins(int value) 
    {
        talentsPoints -= value;
    }
}