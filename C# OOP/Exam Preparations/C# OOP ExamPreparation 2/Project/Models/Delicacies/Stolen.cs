﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public class Stolen : Delicacy
    {
        private const double stolenPrice = 3.50;

        public Stolen(string delicacyName) :base(delicacyName,stolenPrice)
        {
            
        }


    }
}
