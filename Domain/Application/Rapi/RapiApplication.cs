using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.DomainModel.Rapi;

namespace TourInfo.Domain.Application.Rapi
{
    public class RapiApplication : IRapiApplication
    {
        IRapiGraspeService rapiGraspeService;
        public RapiApplication(IRapiGraspeService rapiGraspeService)
        {
            this.rapiGraspeService = rapiGraspeService;
        }
        public void Graspe(string _dateVersion)
        {

            string dataVersion = DateTime.Now.ToString("yyyyMMddhhmmss");
            rapiGraspeService.Graspe(_dateVersion);

        }

    }
}
