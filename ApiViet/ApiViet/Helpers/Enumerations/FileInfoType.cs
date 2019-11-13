using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiViet.Helpers.Enumerations
{
    internal enum FileInfoType
    {
        Contents,
        BasicFileInfo,
        RevitPreview,
        TransmissionData,
        ProjectInformation,
        Invalid = -1
    }
}
