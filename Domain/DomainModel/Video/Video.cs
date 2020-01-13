﻿using System;
using System.Collections.Generic;
using System.Text;
using TourInfo.Domain.Base;
namespace TourInfo.Domain.DomainModel.Video
{
    public class Video:Base.VersionedEntity<int> 
    {
        public int orderno { get; set; }
        public string title { get; set; }
        public string subtitle { get; set; }
        public string author { get; set; }
        public string summary { get; set; }
        public string img { get; set; }
        public string attachment { get; set; }
        public bool istop { get; set; }
        public bool iscycle { get; set; }
        public string jumpurl { get; set; }
        public int pid { get; set; }
        public int mid { get; set; }
        public DateTime pubtime { get; set; }
        public string edituser { get; set; }
        public string editname { get; set; }
        public string checkuser { get; set; }
        public string checkname { get; set; }
        public int checkstate { get; set; }
        public DateTime? checktime { get; set; }
        public DateTime createtime { get; set; }
        public DateTime updatetime { get; set; }
        public bool deleteflag { get; set; }
       
    }

    public class Data
    {
        public int totalcount { get; set; }
        public int type { get; set; }
        public List<Video> results { get; set; }
    }

    public class RootObject
    {
        public Data data { get; set; }
        public int code { get; set; }
        public string message { get; set; }
    }
}