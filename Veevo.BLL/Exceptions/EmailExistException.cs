﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veevo.BLL.Exceptions
{
    public class EmailExistException : Exception
    {
        public EmailExistException(string? message) : base(message)
        {
        }
    }
}
