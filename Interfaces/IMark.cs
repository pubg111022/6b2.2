﻿using pdf6b2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pdf6b2.Interfaces
{
    interface IMark
    {
        List<Mark> GetMark();
        Mark FindById(int id);
        Boolean InsertMark(Mark m);
        Boolean UpdateMark(Mark m, int id);
        Boolean DeleteMark(int id);
    }
}
