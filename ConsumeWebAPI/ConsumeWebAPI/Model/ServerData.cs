﻿using System;

namespace ConsumeWebAPI.Model
{
    public class ServerData
    {
        public int Id { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OrderNumber { get; set; }
        public bool IsDirty { get; set; }
        public string IP { get; set; }
        public int Type { get; set; }
        public int RecordIdentifier { get; set; }

        public String Title
        {
            get { return string.Format("Data History of ID:{0}", Id); }
        }

        public String Description
        {
            get
            {
                return string.Format("Start Date:{0}, End Date:{1}, Order Number:{2}, IP:{3}, Record Type:{4}",
                    InitialDate.ToString("F"), EndDate.ToString("F"), OrderNumber, IP, Type);
            }
        }
    }
}