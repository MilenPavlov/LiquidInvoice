using System;
using System.Collections.Generic;
using ClassLibrary;

namespace DataAcess
{
	
		public class ResourceComparer<TEntity> : IEqualityComparer<TEntity> where TEntity : Resource, new()
		{
			#region IEqualityComparer implementation
			public bool Equals (TEntity x, TEntity y)
			{

				if (x.Id == y.Id)
					return true;

				return false;
			}
			public int GetHashCode (TEntity obj)
			{
				return obj.Id;
			}
			#endregion
		}

}

