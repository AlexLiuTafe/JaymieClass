using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HardCode : MonoBehaviour
{
    public float maxHp = 100, curHp = 100;
    public Vector2 scr;
    public Vector2 size;
    void OnGUI()
    {
        //0,0 represent top left corner of the camera( attach to camera)
        // GUI.Box(new Rect(0, 0, 100, 100), "");

       if(scr.x != Screen.width / 16)
        {
            scr.x = Screen.width / 16;
            scr.y = Screen.height / 9;
        }
        
       for(int x = 0; x<17;x++)
        {
            for ( int y = 0; y < 10;y++)
            {
                //GUI     type/   Pos/ Start x,y/Size x,y/          Content
                GUI.Box(new Rect(scr.x*x,scr.y*y, scr.x * size.x, scr.y * size.y), "");
            }
        }
        //Background
        GUI.Box(new Rect(scr.x, scr.y * 0.25f, scr.x * 3, scr.y * 0.5f),"");
        //Moving HpBar
        GUI.Box(new Rect(scr.x, scr.y * 0.25f, curHp * (scr.x * 3) / maxHp, scr.y * 0.5f), "");
    }
    

}
