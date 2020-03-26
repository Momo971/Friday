﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FridayController
{
	public class Singleton<T>
	{
		private static T instance;
		private static object lockHelper = new object();

		public static T GetInstance()
		{
			if(instance == null)
			{
				lock(lockHelper)
				{
					instance = (T)Activator.CreateInstance(typeof(T));
				}
			}
			return instance;
		}
	}
}
