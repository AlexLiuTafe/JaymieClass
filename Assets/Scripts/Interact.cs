using UnityEngine;
using System.Collections;
//this script can be found in the Component section under the option Intro RPG/Player/Interact

[AddComponentMenu("Intro PRG/RPG/Player/Interact")]
public class Interact : MonoBehaviour
{
    #region Variables
    //We are setting up these variable and the tags in update for week 3,4 and 5
    //[Header("Player and Camera connection")]
    //create two gameobject variables one called player and the other mainCam
    public GameObject player;
    public GameObject playerDialogue;
    #endregion
    #region Start
    private void Start()
    {
        //CONNECT OUR PLAYER TO THE PLAYER VARIABLE VIA TAG
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //connect our Camera to the mainCam variable via tag
    #endregion

    #region Update
    private void Update()
    {
        //IF OUR INTERACT KEY IS PRESSED
        if (Input.GetButtonDown("Interact"))
        {
            //CREATE A RAY
            Ray interact;
            //THIS RAY IS SHOOTING OUT FROM THE MAIN CAMERAS SCREEN POINT CENTER OF SCREEN
            interact = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
                //CREATE HIT INFO
                RaycastHit hitInfo;
            //IF THIS PHYSICS RAYCAST HITS SOMETHING WITHIN 10 UNITS
            if (Physics.Raycast(interact, out hitInfo, 10))
            { 
                #region NPC tag
                //and that hits info is tagged NPC
                if (hitInfo.collider.CompareTag("NPC"))
                {
                    playerDialogue.SetActive(true);
                    
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                   // Dialogue dlg = hitInfo.transform.GetComponent<Dialogue>();
                   // if(dlg !=null)
                    //{
                       // dlg.showDlg = true;
                        //Movement.canMove = false;
                        //Cursor.lockState = CursorLockMode.None;
                        //Cursor.visible = true;
                        
                    //}
                    //DEBUG THAT WE HIT A NPC
                    Debug.Log("Talking to NPC");
                }

                #endregion
                #region Item
                //and that hits info is tagged Item
                if (hitInfo.collider.CompareTag("Item"))
                {
                    //Debug that we hit an Item
                    Debug.Log("Item");
                }
            }

        }
    }
    
    
    #endregion
    #endregion
}






