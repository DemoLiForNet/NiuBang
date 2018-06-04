using System.Collections.Generic;

namespace NiuBang.Service.Feature
{
    public interface IFeatureService
    {
        IEnumerable<Model.Feature> GetFeatures();
    }
}
