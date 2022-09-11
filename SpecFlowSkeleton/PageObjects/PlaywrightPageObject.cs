using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSkeleton.PageObjects
{
    public class PlaywrightPageObject
    {
        public static readonly string DotnetDocOption = "nav >> text=.NET";
        public static readonly string GetStartedButton = "text=Get started";
        public static readonly string InstallationText = "h1:has-text('Installation')";
    }
}
