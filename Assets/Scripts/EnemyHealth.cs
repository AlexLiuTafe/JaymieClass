using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHealth : MonoBehaviour
{
    public float maxHp, curHp;
    public Canvas myCanvas;
    public Slider mySlider;
    private QuestGoal questGoal;
    public int enemyPoint;
    public PlayerQuest player;
    public bool isKilled = false;




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
       if(isKilled)
        {
            questGoal.EnemyKilled();
        }
       
    }
    
    public void TakeDamage(float damageValue)
    {
        curHp -= damageValue;
        mySlider.value = curHp / maxHp;
        if (curHp <= 0)
        {
            Die();

        }
    }
    public void Die()
    {
        Destroy(gameObject);
        enemyPoint++; //Not sure how to access QuestGoal.currentAmount as non static
        isKilled = true;

    }
    
}
