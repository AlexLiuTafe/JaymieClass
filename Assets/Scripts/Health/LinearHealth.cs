using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LinearHealthBar
{
   

    [AddComponentMenu("Intro PRG/PRG/Player/Health - Linear")]
	public class LinearHealth : MonoBehaviour
    {
        [Header("Player Bars")]

        public float maxHealth;
        public float maxMana, maxStam;
        public float curHealth, curMana, curStam;

		[Header("UI References")]

		public Slider healthBar;
        public Slider manaBar,stamBar;
        public Image healthFill, manaFill, staminaFill;

		void Update () 
		{
            // Clamp01 is maximum and minimum value (ex.between 0 and 1)
            healthBar.value = Mathf.Clamp01(curHealth / maxHealth);
            manaBar.value = Mathf.Clamp01(curMana / maxMana);
            stamBar.value = Mathf.Clamp01(curStam / maxStam);

            HealthManager();
		}
		
		void HealthManager()
		{
            //if health less than 0 and slider still enable = Dead and slider is disable
			if(curHealth <= 0 && healthFill.enabled)
			{
				Debug.Log("Dead");
				healthFill.enabled = false;
			}
            //else if is dead and health more than 0 = revive and enable slider
			else if(!healthFill.enabled && curHealth > 0) // ! = NOT
			{
				Debug.Log("Revived");
				healthFill.enabled = true;
			}
		}
	}

}
