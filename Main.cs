using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTA;

namespace Elevator_Mod
{
    public class Elevator_Mod : Script
    {
        public Elevator_Mod() //Constructor; Variables/Arrays/Binds.
        {
            /* BIND tick event, linking to "OnTick" 
               So if there is no "OnTick" it will 
               deliver a syntax error.*/

            Tick += OnTick;

            //Setting the Tick Interval (1000ms/1second)

            Interval = 1000;

            /* BIND key event, linking to "OnKeyUp" 
               So if there is no "OnKeyUp" it will 
               deliver a syntax error.*/

            KeyDown += OnKeyDown;

        }

        Ped gamePlayer = GTA.Game.Player.Character;

        bool scriptActive = false;

        /* METHODS need an access type (Public/Private) and 
           a return type (void/static/ int).*/

        //This is a Tick METHOD.
        public void OnTick(object sender, EventArgs e)
        {
            if(gamePlayer.IsAlive)
            {
                if (gamePlayer.IsInWater)
                {
                    UI.ShowSubtitle("SWIMMING");
                }
                else if (gamePlayer.IsOnFoot)
                {
                    UI.ShowSubtitle("RUNNING");
                }
                else if(gamePlayer.IsInVehicle())
                {
                    UI.ShowSubtitle("DRIVING");
                }
            }
        }

        //This is a Key METHOD.
        public void OnKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //Check if key "F4" key pressed using Keycode to retrieve.
            if (Keys.F4 == e.KeyCode)
            {
                {
                    UI.Notify("Key press detected; Script Active");
                    scriptActive = true;
                }           
            }
        }
    }
}
