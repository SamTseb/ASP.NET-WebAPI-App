using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Interfaces;

namespace BLayer.Implementations
{
    public abstract class BaseService
    {
        public int GetMaxID(List<I_Identifiable> entities)
        {
            if (entities == null || !entities.Any())
                return 0;
            return entities.Max(e => e.ID);
        }

        protected string GetStoragePath(string fileName)
        {
            return $@"{AppDomain.CurrentDomain.BaseDirectory}\{fileName}";
        }
    }
}
