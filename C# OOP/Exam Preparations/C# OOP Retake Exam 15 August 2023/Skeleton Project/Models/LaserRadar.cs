using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class LaserRadar : Supplement
    {
        private const int SLaserRadarArmInterfaceStandard = 20_082;
        private const int LaserRadarArmBatteryUsage = 5_000;
        public LaserRadar()
            : base(SLaserRadarArmInterfaceStandard, LaserRadarArmBatteryUsage)
        {
        }
    }
}
