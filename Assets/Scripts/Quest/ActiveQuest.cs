using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]

public class ActiveQuestUI
{
    public PlayerQuest player;
    public GameObject activeQuestWindow;

    public Text nameText;
    public Text descriptionText;
    public Text expText;
    public Text goldText;
}
public class ActiveQuest : MonoBehaviour
{
    public Quest quest;
    public GameObject questWindow;
    public ActiveQuestUI actUi;
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
        
        actUi.nameText.text = quest.name;
        actUi.descriptionText.text = quest.description;
        actUi.expText.text = quest.expReward.ToString();
        actUi.goldText.text = quest.goldReward.ToString();
    }
        public void ActiveQuestWindow()
    {
        questWindow.SetActive(true);
    }
    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
    }

}