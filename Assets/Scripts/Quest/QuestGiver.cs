using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]


public class QuestUI
{
    
    public PlayerQuest player;
    public GameObject questWindow;
    public GameObject questAccepted;
    public GameObject questCompleted;
    public GameObject dialog1;
    public GameObject dialog2;
    public GameObject dialog3;
    public Text nameText;
    public Text descriptionText;
    public Text expText;
    public Text goldText;

}

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public QuestUI uI;

    private int expReward = 100;
    private int goldReward = 50;


    public void OpenQuestWindow()
    {
        uI.questWindow.SetActive(true);
        uI.nameText.text = quest.name;
        uI.descriptionText.text = quest.description;
        uI.expText.text = "Exp Reward : "+quest.expReward.ToString()+"exp";
        uI.goldText.text = "Gold Reward : "+quest.goldReward.ToString()+"gold";
        //checking if Quest already accepted
        if (quest.state == QuestState.Accepted)
        {

            uI.questWindow.SetActive(false);
            uI.questAccepted.SetActive(true);
            uI.dialog3.SetActive(false);
        }

    }
    public void AcceptQuest()
    {
        uI.questWindow.SetActive(false);
        if(quest.state== QuestState.New)
        {
            quest.state = QuestState.Accepted;
            uI.player.quests.Add(quest);
    
            //activeQuest.actUi.player.quests.Add(quest);       
        }
        

    }
    
    public void ActiveQuest()
    {
        if (quest.state == QuestState.Accepted)
        {
            uI.questWindow.SetActive(false);

        }
    }
    public void CompleteQuest()
    {
        uI.dialog1.SetActive(false);
        
        if(quest.state == QuestState.Completed)
        {
            uI.dialog2.SetActive(false);
            uI.questCompleted.SetActive(true);
        }
    }    
    public void ClaimReward()
    {
        PlayerManager.gold += goldReward;
        PlayerManager.exp += expReward;
    }
}
