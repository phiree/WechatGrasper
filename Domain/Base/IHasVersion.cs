using System;
using System.Collections.Generic;
using System.Text;

namespace TourInfo.Domain.Base
{
    public interface IHasVersion
    {
        string Version { get;  set;}
        string Fingerprint { get; set; }
        void UpdateVersion(string newFingerprint, string newVersion);
    }
}
