using LiveSplit.Model;
using System;

namespace LiveSplit.UI.Components
{
    internal class PseudoregaliaSaveDeleterFactory : IComponentFactory
    {
        public string ComponentName => "Pseudoregalia Save Deleter";
        public string Description => "Deletes the chosen save file for Pseudoregalia on reset.";
        public ComponentCategory Category => ComponentCategory.Other;
        public IComponent Create(LiveSplitState state) => new PseudoregaliaSaveDeleterComponent(state);
        public string UpdateName => ComponentName;
        public string UpdateURL => "";
        public string XMLURL => "";

        public Version Version => Version.Parse("1.0.0");
    }
}
