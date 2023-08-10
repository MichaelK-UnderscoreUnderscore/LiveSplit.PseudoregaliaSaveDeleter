using LiveSplit.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LiveSplit.UI.Components
{
    public class PseudoregaliaSaveDeleterComponent : IComponent
    {
        protected InfoTextComponent InternalComponent { get; set; }
        public PseudoregaliaSaveDeleterSettings Settings { get; set; }
        protected LiveSplitState CurrentState { get; set; }

        public string ComponentName => "Pseudoregalia Save Deleter";

        public float HorizontalWidth => 0;
        public float MinimumHeight => 0;
        public float VerticalHeight => 0;
        public float MinimumWidth => 0;

        public float PaddingTop => 0;
        public float PaddingBottom => 0;
        public float PaddingLeft => 0;
        public float PaddingRight => 0;

        public IDictionary<string, Action> ContextMenuControls => null;

        public PseudoregaliaSaveDeleterComponent(LiveSplitState state)
        {
            Settings = new PseudoregaliaSaveDeleterSettings();
            InternalComponent = new InfoTextComponent("Pseudoregalia Save Deleter", "0%");

            state.OnReset += state_OnReset;
            CurrentState = state;
        }

        void state_OnReset(object sender, TimerPhase e)
        {
            if (CurrentState.Run.GameName != "Pseudoregalia" && Settings.validateGame) return;

            DirectoryInfo baseDir = new DirectoryInfo(Environment.GetEnvironmentVariable("localappdata") + "\\pseudoregalia\\Saved\\SaveGames\\");
            if (Settings.AutoDetect)
            {
                FileInfo file = baseDir.GetFiles().OrderByDescending(f => f.LastWriteTime).Where(f => Regex.IsMatch(f.Name, "File [1-8][.]sav")).FirstOrDefault();
                if (file != null)
                {
                    file.Delete();
                }
            }
            bool[] saveSettings = { Settings.Save1, Settings.Save2, Settings.Save3, Settings.Save4, Settings.Save5, Settings.Save6, Settings.Save7, Settings.Save8 };
            for (int i = 0; i <= 7; i++)
            {
                if (saveSettings[i])
                {
                    FileInfo file = new FileInfo(baseDir.FullName + "File " + (i+1) + ".sav");
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }
            }
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion) {}

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion) {}

        public Control GetSettingsControl(LayoutMode mode)
        {
            Settings.Mode = mode;
            return Settings;
        }

        public System.Xml.XmlNode GetSettings(System.Xml.XmlDocument document)
        {
            return Settings.GetSettings(document);
        }

        public void SetSettings(System.Xml.XmlNode settings)
        {
            Settings.SetSettings(settings);
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode) {}

        public void Dispose()
        {
            CurrentState.OnReset -= state_OnReset;
        }

        public int GetSettingsHashCode()
        {
            return Settings.GetSettingsHashCode();
        }
    }
}
