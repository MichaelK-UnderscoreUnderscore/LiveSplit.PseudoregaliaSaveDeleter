using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.UI.Components
{
    public partial class PseudoregaliaSaveDeleterSettings : UserControl
    {
        public LayoutMode Mode { get; set; }
        public bool Save1 { get; set; } = false;
        public bool Save2 { get; set; } = false;
        public bool Save3 { get; set; } = false;
        public bool Save4 { get; set; } = false;
        public bool Save5 { get; set; } = false;
        public bool Save6 { get; set; } = false;
        public bool Save7 { get; set; } = false;
        public bool Save8 { get; set; } = false;
        public bool AutoDetect { get; set; } = true;
        public bool validateGame { get; set; } = true;

        public PseudoregaliaSaveDeleterSettings()
        {
            InitializeComponent();
        }

        private void PseudoregaliaSaveDeleterSettings_Load(object sender, EventArgs e)
        {
            checkSave1.Enabled = true;
            checkSave2.Enabled = true;
            checkSave3.Enabled = true;
            checkSave4.Enabled = true;
            checkSave5.Enabled = true;
            checkSave6.Enabled = true;
            checkSave7.Enabled = true;
            checkSave8.Enabled = true;
            checkAutoDetect.Enabled = true;
            checkValidateGame.Enabled = true;

            checkSave1.DataBindings.Clear();
            checkSave2.DataBindings.Clear();
            checkSave3.DataBindings.Clear();
            checkSave4.DataBindings.Clear();
            checkSave5.DataBindings.Clear();
            checkSave6.DataBindings.Clear();
            checkSave7.DataBindings.Clear();
            checkSave8.DataBindings.Clear();
            checkAutoDetect.DataBindings.Clear();
            checkValidateGame.DataBindings.Clear();

            checkSave1.DataBindings.Add("Checked", this, "Save1", false, DataSourceUpdateMode.OnPropertyChanged);
            checkSave2.DataBindings.Add("Checked", this, "Save2", false, DataSourceUpdateMode.OnPropertyChanged);
            checkSave3.DataBindings.Add("Checked", this, "Save3", false, DataSourceUpdateMode.OnPropertyChanged);
            checkSave4.DataBindings.Add("Checked", this, "Save4", false, DataSourceUpdateMode.OnPropertyChanged);
            checkSave5.DataBindings.Add("Checked", this, "Save5", false, DataSourceUpdateMode.OnPropertyChanged);
            checkSave6.DataBindings.Add("Checked", this, "Save6", false, DataSourceUpdateMode.OnPropertyChanged);
            checkSave7.DataBindings.Add("Checked", this, "Save7", false, DataSourceUpdateMode.OnPropertyChanged);
            checkSave8.DataBindings.Add("Checked", this, "Save8", false, DataSourceUpdateMode.OnPropertyChanged);
            checkAutoDetect.DataBindings.Add("Checked", this, "AutoDetect", false, DataSourceUpdateMode.OnPropertyChanged);
            checkValidateGame.DataBindings.Add("Checked", this, "validateGame", false, DataSourceUpdateMode.OnPropertyChanged);
        }

        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "Version", "1.0") ^
                SettingsHelper.CreateSetting(document, parent, "AutoDetect", AutoDetect) ^
                SettingsHelper.CreateSetting(document, parent, "Save1", Save1) ^
                SettingsHelper.CreateSetting(document, parent, "Save2", Save2) ^
                SettingsHelper.CreateSetting(document, parent, "Save3", Save3) ^
                SettingsHelper.CreateSetting(document, parent, "Save4", Save4) ^
                SettingsHelper.CreateSetting(document, parent, "Save5", Save5) ^
                SettingsHelper.CreateSetting(document, parent, "Save6", Save6) ^
                SettingsHelper.CreateSetting(document, parent, "Save7", Save7) ^
                SettingsHelper.CreateSetting(document, parent, "Save8", Save8) ^
                SettingsHelper.CreateSetting(document, parent, "ValidateGame", validateGame);
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        public int GetSettingsHashCode()
        {
            return CreateSettingsNode(null, null);
        }

        public void SetSettings(XmlNode node)
        {
            var element = (XmlElement)node;
            AutoDetect = SettingsHelper.ParseBool(element["AutoDetect"], true);
            Save1 = SettingsHelper.ParseBool(element["Save1"], false);
            Save2 = SettingsHelper.ParseBool(element["Save2"], false);
            Save3 = SettingsHelper.ParseBool(element["Save3"], false);
            Save4 = SettingsHelper.ParseBool(element["Save4"], false);
            Save5 = SettingsHelper.ParseBool(element["Save5"], false);
            Save6 = SettingsHelper.ParseBool(element["Save6"], false);
            Save7 = SettingsHelper.ParseBool(element["Save7"], false);
            Save8 = SettingsHelper.ParseBool(element["Save8"], false);
            validateGame = SettingsHelper.ParseBool(element["ValidateGame"], true);
        }
    }
}
