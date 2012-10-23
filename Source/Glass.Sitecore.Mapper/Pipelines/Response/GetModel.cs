﻿#if !preMVC
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Mvc.Pipelines.Response.GetModel;
using Sitecore.Data.Items;
using Sitecore.Mvc.Extensions;
using Sitecore.Mvc.Presentation;

namespace Glass.Sitecore.Mapper.Pipelines.Response
{
    public class GetModel : GetModelProcessor
    {

        public override void Process(GetModelArgs args)
        {
            if (args.Result == null)
            {

                try
                {
                    Type type = GetFromField(args.Rendering, args);
                    if (Context.StaticContext.Classes.ContainsKey(type))
                    {
                        ISitecoreContext context = new SitecoreContext();
                        var result = context.GetCurrentItem(type);
                        args.Result = result;
                    }
                }
                catch (MapperException ex)
                {
                    //do nothing
                }
                catch (System.TypeLoadException ex)
                {
                    //do nothing
                }
            }
        }

        protected virtual Type GetFromField(Rendering rendering, GetModelArgs args)
        {
            Item obj = ObjectExtensions.ValueOrDefault<RenderingItem, Item>(rendering.RenderingItem, (Func<RenderingItem, Item>)(i => i.InnerItem));
            if (obj == null)
                throw new MapperException("No rendering item");
            else
                return Type.GetType(obj["Model"], true);
        }
    }
}
#endif