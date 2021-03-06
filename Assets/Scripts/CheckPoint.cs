﻿using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Intro RPG/Player/Check Point
[AddComponentMenu("intro PRG/RPG/Player/Check Point")]
public class CheckPoint : MonoBehaviour 
{
    #region Variables
    
    [Header("Check Point Elements")]
    //position for our currentCheck
    public Vector3 curCheckPoint;
    private Transform checkPoint;
    private Vector3 revivePoint;
    [Header("Character Health")]
    public PlayerManager player;//character Health script that holds the players health

    #endregion
    #region Start
    private void Start()
    {

        //Reference to the character health script component attached to our player
        player = GetComponent<PlayerManager>();
        checkPoint = GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<Transform>();
        revivePoint = new Vector3(checkPoint.position.x, checkPoint.position.y, checkPoint.position.z);
        player.curHealth = player.maxHealth;

        #region Check if we have Key
        //if we have a save key called SpawnPoint
        //then our checkpoint is equal to the game object that is named in out save file or the float x,y,z
        //our transform.position is equal to that of the checkpoint or to the float x,y,z

        #endregion
    }
    #endregion
    #region Update
    //private void Update()
    //{
    //    //if our characters health is less than or equal to 0
    //    if (player.curHealth <= 0)
    //    {
    //        //our transform.position is equal to that of the checkpoint or float x,y,z
    //        transform.position = curCheckPoint;

    //        //character is alive
    //        if (player.curHealth >= 0)
    //        {
    //            //characters controller is active	
    //            CharacterController charC = GetComponent<CharacterController>();
    //            charC.enabled = true;

    //        }
         
            
    //    }
        
    //}
    #endregion
    #region OnTriggerEnter
    
    private void OnTriggerEnter(Collider other)
    {
        //if our other objects tag when compared is CheckPoint
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            //our checkpoint is equal to the other objects transform
            curCheckPoint = other.transform.position;
            //save our SpawnPoint as the name of the check point or float x, y, z
            PlayerManager player = GetComponent<PlayerManager>();
            player.SavePlayer();
        }
    }





    
    
    #endregion
}





