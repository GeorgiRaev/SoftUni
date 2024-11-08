﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndMonsters.Models
{
    public abstract class Hero
    {
        public string UserName { get; set; }
        public int Level { get; set; }
        protected Hero(string userName, int level)
        {
            UserName = userName;
            Level = level;
        }

        public override string ToString()=> $"Type: {this.GetType().Name} Username: {this.UserName} Level: {this.Level}";
    }
}
