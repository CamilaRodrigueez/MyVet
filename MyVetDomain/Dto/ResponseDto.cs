﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyVetDomain.Dto
{
    public class ResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
}
