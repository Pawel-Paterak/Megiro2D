using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megiro2D.Engine
{
    public static class Time
    {
        public static float DeltaTime
        {
            get => deltaTime;
            set
            {
                deltaTime = value;
                windowTime += value;
            }
        }
        public static float WindowTime { get => windowTime; }
        public static float TimeScale { get; set; } = 1;

        private static float windowTime;
        private static float deltaTime;
    }
}
