﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class Ad
    {
        public int adId { get; set; }
        public string targetUrl { get; set; }
        public string title { get; set; }
        public string longTitle { get; set; }
        public string description { get; set; }
        public string companyName { get; set; }
        public AdGroup adGroup { get; set; }
        public AdImage adImage { get; set; }


        public int priority { get; set; }
        public int showCounter { get; set; }

        public int views { get; set; }
        public int clicks { get; set; }
        public double ctr { get; set; }

    }
}
