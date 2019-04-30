using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class QuestGoal
{
    //Goal Type
    public GoalType goalType;
    //Required Amount
    public int requiredAmount;
    //Current Amount
    public int currentAmount;
    //IsReached
    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }
    //Enemy Killer
    public void EnemyKilled()
    {
        if(goalType ==GoalType.Kill)
        {
            currentAmount++;
        }
    }
    //Object Collected
    public void ObjectCollected()
    {
        if (goalType == GoalType.Gather)
        {
            currentAmount++;
        }
    }
}
public enum GoalType
{
    Kill,
    Gather
}