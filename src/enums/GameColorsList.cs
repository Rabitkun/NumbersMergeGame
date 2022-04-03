using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace NumbersMergeGame
{
    public static class GameColors
    {
        public enum CellSteps 
        { 
            Step2 = 2,
            Step4 = 4,
            Step8 = 8,
            Step16 = 16,
            Step32 = 32,
            Step64 = 64,
            Step128 = 128,
            Step256 = 256,
            Step512 = 512,
            Step1024 = 1024,
            Step2048 = 2048
        };

        public static Color GetColorByValue(CellSteps value)
        {
            switch(value)
            {
                case CellSteps.Step2:
                    return Godot.Colors.Purple;
                case CellSteps.Step4:
                    return Godot.Colors.RosyBrown;
                case CellSteps.Step8:
                    return Godot.Colors.Yellow;
                case CellSteps.Step16:
                    return Godot.Colors.LightSeaGreen;
                case CellSteps.Step32:
                    return Godot.Colors.Azure;
                case CellSteps.Step64:
                    return Godot.Colors.Gray;
                case CellSteps.Step128:
                    return Godot.Colors.Orange;
                case CellSteps.Step256:
                    return Godot.Colors.NavyBlue;
                case CellSteps.Step512:
                    return Godot.Colors.Pink;
                case CellSteps.Step1024:
                    return Godot.Colors.Silver;
                case CellSteps.Step2048:
                    return Godot.Colors.DarkOrange;
                default:
                    return Godot.Colors.Black;
            }
        }
    }
}
