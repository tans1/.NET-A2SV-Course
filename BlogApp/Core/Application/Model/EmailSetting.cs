﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model
{
    public class EmailSetting
    {
        public string ApiKey { get; set; }
        public string FromAddress { get; set; }

        public string FromName { get; set; }
    }
}
