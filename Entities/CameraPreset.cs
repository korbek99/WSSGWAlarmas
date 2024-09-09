using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
    public class CameraPreset
    {
        public int CameraID { get; set; }
        public int CameraPresetChannel { get; set; }
        public int CameraPresetPresNumber { get; set; }
        public string CameraPresetPresCabecera { get; set; }
        public string CameraPresetPresArgument { get; set; }
    }
}
