using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoEx.Binder
{
    public class CustomModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext ccontex, ModelBindingContext mcontext)
        {
            var providerResult = mcontext.ValueProvider.GetValue(mcontext.ModelName);
            return new ObjectId(providerResult.AttemptedValue);
        }
    }
}