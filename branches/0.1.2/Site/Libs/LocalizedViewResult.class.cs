using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site.Libs
{
    public class LocalizedViewResult : ViewResult
    {
        
        public LocalizedViewResult(string viewName)
        {
            base.ViewName = viewName;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            base.ViewName = this.GetLocalizedViewName(context);
            base.ExecuteResult(context);
        }

        private string GetLocalizedViewName(ControllerContext context)
        {
            
            string culture = context.HttpContext.Request.UserLanguages[0] ?? "ru";
            
            string output = base.ViewName;

            if (culture == "ru")
                return output;

            // check for other languages using lang-CULTURE, then just lang:
            string localizedView =  string.Format("{0}.{1}", base.ViewName, culture);

            ViewEngineResult result = ViewEngines.Engines.FindView(context, localizedView, base.MasterName);
            if (result.View == null)
            {
                localizedView = string.Format("{0}.{1}", base.ViewName, culture.Substring(0, 2));
                result = ViewEngines.Engines.FindView(context, localizedView, base.MasterName);

                if (result.View != null)
                    return localizedView;
            }

            else
                return localizedView;
            return base.ViewName;
        }
    }
}