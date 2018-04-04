using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComeFlyWithMe.Model
{
	static class IdGen
	{
		//Variable for ID
		static uint id = 0;
		//Creates a idKey Object
		static object idKey = new object();

		public static uint Id { get => id; set => id = value; }

		//Method that gives the next available ID
		public static uint NewId()
		{
			lock (idKey)
			{
				return Id++;
			}
		}
	}
}
