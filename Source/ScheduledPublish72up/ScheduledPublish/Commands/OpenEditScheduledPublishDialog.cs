﻿using System.Collections.Specialized;
using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;

namespace ScheduledPublish.Commands
{
    public class OpenEditScheduledPublishDialog : Command
    {
        public override void Execute(CommandContext context)
        {
            Assert.ArgumentNotNull(context, "context");
            Context.ClientPage.Start(this, "Run", new NameValueCollection());
        }

        protected void Run(ClientPipelineArgs args)
        {
            if (!SheerResponse.CheckModified())
            {
                return;
            }
                
            if (args.IsPostBack)
            {
                return;
            }

            UrlString urlString = new UrlString(UIUtil.GetUri("control:EditScheduledPublish"));
            SheerResponse.ShowModalDialog(urlString.ToString(), "700", "600", string.Empty, true);
            args.WaitForPostBack();
        }
    }
}