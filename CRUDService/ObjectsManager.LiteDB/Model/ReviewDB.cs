﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsManager.LiteDB.Model
{
    class ReviewDB
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public PersonDB Author { get; set; }
        public int MovieId { get; set; }
    }
}
