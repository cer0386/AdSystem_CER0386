﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLayer
{
    public class InAudience
    {
        public int inAIDOF { get; set; }
        public Audience audience { get; set; }
        public Visitor visitor { get; set; }
    }
}
