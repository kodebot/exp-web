using Microsoft.AspNet.Mvc.ModelBinding;
using Microsoft.AspNet.Mvc.ViewFeatures;
using Moq;
using Ploeh.AutoFixture;

namespace WebVaanoli.Tests.TestHelpers
{
    public class MvcCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            //var mockModelMetadataProvider = fixture.Freeze<Mock<IModelMetadataProvider>>();
            var modelStateDictionary = fixture.Freeze<ModelStateDictionary>(new ModelStateDictionary());
            fixture.Register(() => new ViewDataDictionary(new EmptyModelMetadataProvider(), modelStateDictionary));
            //fixture.Customize<Controller>(c => c.With(x => x.ViewData, stubViewData));
        }
    }
}
