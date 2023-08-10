using LiveSplit.Model;
using System;

namespace LiveSplit.UI.Components
{
    internal class PseudoregaliaSaveDeleterFactory : IComponentFactory
    {
        public string ComponentName => "Pseudoregalia Save Deleter";
        public string Description => "Deletes the chosen save files for Pseudoregalia on reset.";
        public ComponentCategory Category => ComponentCategory.Other;
        public IComponent Create(LiveSplitState state) => new PseudoregaliaSaveDeleterComponent(state);
        public string UpdateName => ComponentName;
        public string UpdateURL => "https://raw.githubusercontent.com/MichaelK-UnderscoreUnderscore/LiveSplit.PseudoregaliaSaveDeleter/master/";
        public string XMLURL => UpdateURL + "Components/update.LiveSplit.PseudoregaliaSaveDeleter.xml";

        public Version Version => Version.Parse("1.0.0");
    }
}