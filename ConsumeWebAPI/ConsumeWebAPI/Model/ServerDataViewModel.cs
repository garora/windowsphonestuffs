using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsumeWebAPI.Model
{
    public class ServerDataViewModel
    {
        public String Title { get; set; }
        public String Description { get; set; }

        public IEnumerable DisplayData(List<ServerData> getServerData)
        {
            var serverDataViewModels = new List<ServerDataViewModel>();

            if (!getServerData.Any()) return serverDataViewModels;

            IEnumerable<ServerData> serverDatas = getServerData.Take(3);

            serverDataViewModels.AddRange(serverDatas.Select(serverData => new ServerDataViewModel
            {
                Title = string.Format("Data History of ID:{0}", serverData.Id),
                Description =
                    string.Format("Start Date:{0}, End Date:{1}, Order Number:{2}, IP:{3}, Record Type:{4}",
                        serverData.InitialDate, serverData.EndDate, serverData.OrderNumber, serverData.IP,
                        serverData.Type)
            }));

            return serverDataViewModels;
        }
    }
}