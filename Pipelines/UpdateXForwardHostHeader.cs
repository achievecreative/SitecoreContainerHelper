using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Configuration;
using Sitecore.Pipelines.PreprocessRequest;

namespace SitecoreContainerHelper.Pipelines
{
    public class UpdateXForwardHostHeader : PreprocessRequestProcessor
    {
        public override void Process(PreprocessRequestArgs args)
        {
            var context = HttpContext.Current;
            string str = context?.Request?.Headers?[Settings.LoadBalancingHost];
            if (!string.IsNullOrEmpty(str) && str.Contains(":"))
            {
                str = str.Substring(0, str.IndexOf(":", StringComparison.OrdinalIgnoreCase));
                context.Request.Headers[Settings.LoadBalancingHost] = str;
            }
        }
    }
}