using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    public float maxHp, curHp;
    public Canvas myCanvas;
    public Slider mySlider;
    public int enemyPoint;
    public PlayerQuest player;
    




    void Start()
    {
       
        myCanvas = this.transform.Find("Canvas").GetComponent<Canvas>();
        mySlider = myCanvas.transform.Find("Slider").GetComponent<Slider>();
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
       // QuestGoal playerQuestGoal = player.GetComponent<QuestGoal>(); //Player doesnt carry QuestGoal..???
       // playerQuestGoal.currentAmount += enemyPoint;
    }
    void Update()
    {
        mySlider.value = Mathf.Clamp01(curHp / maxHp);
        myCanvas.transform.LookAt(Camera.main.transform);
       
       
    }
    
    public void TakeDamage(float damageValue)
    {
        //Get PlayerQuest component into playerQuest(PlayerQuest)
        PlayerQuest playerQuest = player.GetComponent<PlayerQuest>();
        curHp -= damageValue;
        mySlider.value = curHp / maxHp;
        if (curHp <= 0)
        {
            Die();
            
        }
        if(curHp <= 0 && playerQuest.quests[0].state == QuestState.Accepted)
        {
            playerQuest.quests[0].goal.EnemyKilled();
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    
}
