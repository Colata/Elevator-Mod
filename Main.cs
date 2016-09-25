using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTA;
using GTA.Native;

namespace Elevator_Mod
{
    public partial class Elevator_Mod : Script
    {
        public Elevator_Mod() //Constructor; Variables/Arrays/Binds.
        {
            Tick += OnTick; //bind

            Interval = 10; //variable

            KeyDown += OnKeyDown; //bind

            Blip badgerBlip = World.CreateBlip(badger_BOTTOM, 2);
            {
                badgerBlip.Sprite = BlipSprite.Helicopter;
                badgerBlip.Scale = 75f;
            }

            UI.Notify("ELEVATOR-MOD Active");
        }

        //Displays the player's status (e.g running, driving, swimming).
        public void current_action()
        {
            if (gamePlayer.IsAlive)
            {
                if (gamePlayer.IsInWater)
                {
                    UI.ShowSubtitle("SWIMMING");
                }
                else if (gamePlayer.IsOnFoot)
                {
                    UI.ShowSubtitle("RUNNING");
                }
                else if (gamePlayer.IsInVehicle())
                {
                    UI.ShowSubtitle("DRIVING");
                }
            }
        } 

        Ped gamePlayer = GTA.Game.Player.Character;

        public void elevatorZone_UP()
        {
            UI.ShowSubtitle("You're in an Elevator zone; Press 'F' to go UP.");
        }

        public void elevatorZone_DOWN()
        {
            UI.ShowSubtitle("You're in an Elevator zone; Press 'F' to go DOWN.");
        } 

        public void teleportSequence()
        {
            Game.FadeScreenIn(750);
            UI.Notify("Elevator Successful");
        }

        bool badger_travel_UP = false;
        bool badger_travel_DOWN = false;

        /* METHODS need an access type (Public/Private) and 
           a return type (void/static/ int).*/

        //This is a Tick METHOD.
        public void OnTick(object sender, EventArgs e)
        {
            current_action();

            if (gamePlayer.Position.DistanceTo(badger_BOTTOM) <= 100f)
            {
                //In-Game Markers
                Function.Call(Hash.DRAW_MARKER, 1, 478.8547f, -107.6386f, 63.1579f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 1.50f, 1.50f, 1.50f, 204, 204, 1, 100, false, true, 2, false, false, false, false);
                Function.Call(Hash.DRAW_MARKER, 1, 469.7626f, -107.6571f, 117.6346f, 0.0f, 0.0f, 0.0f, 180.0f, 0.0f, 0.0f, 1.50f, 1.50f, 1.50f, 204, 204, 1, 100, false, true, 2, false, false, false, false);

                if (gamePlayer.Position.DistanceTo(badger_BOTTOM) <= 2.5f)
                {
                    elevatorZone_UP();
                    badger_travel_UP = true;                 
                }

                if(gamePlayer.Position.DistanceTo(badger_TOP) <= 2.5f)
                {
                    elevatorZone_DOWN();
                    badger_travel_DOWN = true;
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
                    UI.Notify("Key press detected");
                }
            }

            if(Keys.F == e.KeyCode && badger_travel_UP)
            {
                Game.FadeScreenOut(750);
                Wait(750);
                gamePlayer.Position = badger_TOP;
                teleportSequence();             
            }

            if(Keys.F == e.KeyCode && badger_travel_DOWN)
            {
                Game.FadeScreenOut(750);
                Wait(750);
                gamePlayer.Position = badger_BOTTOM;
                teleportSequence();
            }
        }
    }
}
