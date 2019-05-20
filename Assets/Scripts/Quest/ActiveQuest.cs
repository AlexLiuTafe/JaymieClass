using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]

public class ActiveQuestUI
{
 
    public GameObject activeQuestWindow;
    public Text nameText;
    public Text descriptionText;
    public Text expText;
    public Text goldText;
}
public class ActiveQuest : MonoBehaviour
{
    public GameObject questWindow;
    public ActiveQuestUI actUi;
    public PlayerQuest player;
    public void Update()
    {
        bool openQuestWIndow = Input.GetButtonDown("Quest");
        bool closeQuestWIndow = Input.GetButtonUp("Quest");
        if (openQuestWIndow)
        {
            ActiveQuestWindow();
        }
        if (closeQuestWIndow)
        {
            CloseQuestWindow();
        }
    }
    public void OpenQuestWindow()
    {
        PlayerQuest playerQuest = player.GetComponent<PlayerQuest>();

        actUi.nameText.text = playerQuest.quests[0].name;
        actUi.descriptionText.text = playerQuest.quests[0].description;
        actUi.expText.text = "Exp Reward : " + playerQuest.quests[0].expReward.ToString() +"exp";
        actUi.goldText.text = "Gold Reward : " + playerQuest.quests[0].goldReward.ToString()+"gold";
        
    }
        public void ActiveQuestWindow()
    {
        questWindow.SetActive(true);
        OpenQuestWindow();
    }
    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
    }

}