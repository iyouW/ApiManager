﻿using ApiManager.Core.Entities.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiManager.Core.Entities
{
    public class Version : EntityBase<string>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
