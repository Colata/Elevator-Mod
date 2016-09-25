using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GTA;

namespace Elevator_Mod
{
    public partial class Elevator_Mod : Script
    {
        //Badger Centre
        GTA.Math.Vector3 badger_TOP = new GTA.Math.Vector3(469.7626f, -107.6571f, 117.6346f);
        GTA.Math.Vector3 badger_BOTTOM = new GTA.Math.Vector3(478.8547f, -107.6386f, 63.1579f);
        //FIB Centre
        GTA.Math.Vector3 fib_BOTTOM = new GTA.Math.Vector3(99.49534f, -743.5652f, 45.75476f);
        GTA.Math.Vector3 fib_TOP = new GTA.Math.Vector3(132.4646f, -726.3422f, 258.1525f);
        //HalfBuilt Building
        GTA.Math.Vector3 halfBuilt_BOTTOM = new GTA.Math.Vector3(-184.1684f, -1016.074f, 30.07096f);
        GTA.Math.Vector3 halfBuilt_TOP = new GTA.Math.Vector3(-159.6062f, -944.0149f, 269.218f);
        //Hospital 1
        GTA.Math.Vector3 hospital1_BOTTOM = new GTA.Math.Vector3(360.2171f, -584.9374f, 28.8215f);
        GTA.Math.Vector3 hospital1_TOP = new GTA.Math.Vector3(340.2888f, -584.173f, 74.1657f);
    }
}
