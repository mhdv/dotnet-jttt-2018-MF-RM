﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class JTTTdb
    {
        public int ID { get; set; }
        //public JTTT task { get; set; }

        public string URL { get; set; }
        public string text { get; set; }
        public string mail { get; set; }

        public override string ToString()
        {
            return URL + " " + text + " " + mail;
        }
    }
}
