﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sololearn.exception
{
    public class ServiceException : Exception
    {
        public ServiceException(string msg) : base(msg){
        }
    }
}
