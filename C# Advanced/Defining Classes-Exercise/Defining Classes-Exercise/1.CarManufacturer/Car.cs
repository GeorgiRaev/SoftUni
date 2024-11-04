using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Car
    {
		private string make;

		public string Make
		{
			get { return make; }
			set { make = value; }
		}

		public string model;

		public string Model
		{
			get { return model; }
			set { model = value; }
		}

		public int year;

		public int Year
		{
			get { return year; }
			set { year = value; }
		}

	}
}
