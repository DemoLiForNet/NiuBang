using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NiuBang.Model;

namespace NiuBang.Service.Feature
{
    public class FeatureService : IFeatureService
    {
        public IEnumerable<Model.Feature> GetFeatures()
        {
            return new List<Model.Feature>();
        }
    }
}
