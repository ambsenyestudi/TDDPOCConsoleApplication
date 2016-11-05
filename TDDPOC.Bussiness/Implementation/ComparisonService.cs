using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TDDPOC.Bussiness.Contracts;

namespace TDDPOC.Bussiness.Implementation
{
    public class ComparisonService : IComparisonService
    {
        public int CompareNDifferentProperties(object sourceObj, object newObj)
        {
            int resultCount = -1;
            PropertyInfo[] oldProps = sourceObj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] newProps = newObj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < oldProps.Length; i++)
            {
                if(oldProps[i].Name== newProps[i].Name)
                {
                    
                    if(oldProps[i].GetValue(sourceObj)!=newProps[i].GetValue(newObj))
                    {
                        if(resultCount<0)
                        {
                            resultCount = 0;
                        }
                        resultCount++;
                    }
                }              
            }
            return resultCount;
        }
    }
}
