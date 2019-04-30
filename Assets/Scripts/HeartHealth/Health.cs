using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Allow us to interact with UI elements
using UnityEngine.UI;

namespace QuarterHeart  
{
    //this script can be found in the Component section under the option Intro PRG/Player/Health
    [AddComponentMenu("Intro PRG/RPG/Player/Health - Heart")]

    public class Health : MonoBehaviour
    {
        [Header("Player Stats")]
        //public maxHealth
        public float maxHealth;
        //public curHealth
        public float curHealth;
        [Header("Heart Slots")]// HOMEWORK: Set up image slots to auto set up according to amount of slots needed aka spawning the fuckers (them) in. 
        //Canvas Image heartSlots array
        public Image[] heartSlots = new Image[3]; // Arrays are static.
        //Sprite hearts array
        public Sprite[] heart = new Sprite[5];
        //private percent healthPerSection
        private float healthPerSection;

        #region Start
        void Start() 
        {
            // Run UpdateHearts
            UpdateHearts(); 
        }
        #endregion
        #region Update 
        void update()
        {
            //index variable starting at 0 for slot checks
            int i = 0;
            //foreach Image slot in heartSlots
            foreach (Image slot in heartSlots)
            {
                
                //if curHealth is greater or equal to full for this slot amount
                if(curHealth >= (healthPerSection * 4) + (healthPerSection * 4) * i)
                {
                    //Set heart to 4/4
                    heartSlots[i].sprite = heart[0];
                }    
                //else if curHealth is greater or equal to 3/4 for this slot amount
                else if(curHealth >= (healthPerSection * 3) + (healthPerSection * 4) * i)
                {
                    //Set Heart to 3/4
                    heartSlots[i].sprite = heart[1];
                }
                //else if curHealth is greater or equal to 2/4 for this slot amount
                else if(curHealth >= (healthPerSection * 2) + (healthPerSection * 4) * i)
                {
                    //Set Heart to 2/4
                    heartSlots[i].sprite = heart[2];
                }
                //else if curHealth is greater or equal to 1/4 for this slot amount
                else if(curHealth >= (healthPerSection * 1) + (healthPerSection * 4) * i)
                {
                    //Set Heart to 1/4    
                    heartSlots[i].sprite = heart[3];
                }
                //else
                else
                {
                    //Set Heart to 1/4    
                    heartSlots[i].sprite = heart[4];
                }
                //we are empty
                //after checking this slot increase slot index
                i++;
            }
        }
            
        #endregion
        #region UpdateHearts
        void UpdateHearts()
        {
            //calculate the health points per heart section
            healthPerSection = maxHealth / (heartSlots.Length * 4);   
        }
        #endregion
    }

}
