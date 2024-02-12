using System.Globalization;

namespace SeagateConsole
{
    [Flags]
    public enum FormatOptions
    {
        //KULLANILMADI AMA GÜZEL BÝR ÖRNEK HANGÝSÝ SEÇÝLÝRSE O BÝTÝ VERÝR
        CorruptUserPartitionPrimaryDefects = 1 << 0,

        DisableUserPartitionFormat = 1 << 1,
        DisableUserPartitionCertify = 1 << 2,
        EnableEventBasedFormatLogging = 1 << 3,
        EnableZoneReformatSkipping = 1 << 4,
        EnableSeaCOSXFSpaceFormat = 1 << 5
    }

    public partial class Form1 : Form
    {
        private Dictionary<CheckBox, FormatOptions> checkBoxOptionsMap;
        private UInt16 MaxWrRetryCnt;
        private UInt16 MaxRdRetryCnt;
        private UInt16 MaxEccTLevel;
        private UInt16 MaxCertifyTrkRewrites;
        private UInt32 DataPattern;

        public Form1()
        {
            InitializeComponent();
            InitializeTrackBars();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "Format Options Generator";
            cmbPartition.Items.Add("User Partition (0)");
            cmbPartition.Items.Add("System Partition (1)");
            cmbPartition.SelectedIndex = 0;

            GrownDefectLists.Checked = true;
            PrimaryDefectLists.Checked = true;

            cmbValidKey.Items.Add("Valid Key For a User Partition (22)");
            cmbValidKey.Items.Add("Valid Key For a System Partition (DD)");
            cmbValidKey.SelectedIndex = 0;
            cmbDataPattern.Text = "00000000";
            cmbDataPattern.Items.Add("00000000");
            cmbDataPattern.Items.Add("FFFFFFFF");
            cmbDataPattern.Items.Add("AAAAAAAA");
            cmbDataPattern.Items.Add("55555555");
            cmbDataPattern.SelectedIndex = 0;
            tbxCommandString.Text = "m0,0,3,0,0,0,0,22,00000000";
        }

        private void InitializeTrackBars()
        {
            // TrackBar'larý baþlat
            trackBarMaxWrRetryCnt.Minimum = 0;
            trackBarMaxWrRetryCnt.Maximum = 0xFFFF;
            trackBarMaxWrRetryCnt.SmallChange = 32767;

            trackBarMaxRdRetryCnt.Minimum = 0;
            trackBarMaxRdRetryCnt.Maximum = 0xFFFF;
            trackBarMaxRdRetryCnt.SmallChange = 32767;

            trackBarMaxECCTLevel.Minimum = 0;
            trackBarMaxECCTLevel.Maximum = 0xFFFF;
            trackBarMaxECCTLevel.SmallChange = 32767;

            trackBarMaxCertifyTrkRewrites.Minimum = 0;
            trackBarMaxCertifyTrkRewrites.Maximum = 0xFFFF;
            trackBarMaxCertifyTrkRewrites.SmallChange = 32767;

            // Event'leri baðla
            trackBarMaxWrRetryCnt.Scroll += TrackBar_Scroll;
            trackBarMaxRdRetryCnt.Scroll += TrackBar_Scroll;
            trackBarMaxECCTLevel.Scroll += TrackBar_Scroll;
            trackBarMaxCertifyTrkRewrites.Scroll += TrackBar_Scroll;

            CorruptUserPartitionPrimaryDefects.CheckedChanged += FormatAndDefectlistOptions_CheckedChanged;
            DisableUserPartitionFormat.CheckedChanged += FormatAndDefectlistOptions_CheckedChanged;
            DisableUserPartitionCertify.CheckedChanged += FormatAndDefectlistOptions_CheckedChanged;
            EnableEventBasedFormatLogging.CheckedChanged += FormatAndDefectlistOptions_CheckedChanged;
            EnableZoneReformatSkipping.CheckedChanged += FormatAndDefectlistOptions_CheckedChanged;
            EnableSeaCOSXFSpaceFormat.CheckedChanged += FormatAndDefectlistOptions_CheckedChanged;

            GrownDefectLists.CheckedChanged += FormatAndDefectlistOptions_CheckedChanged;
            PrimaryDefectLists.CheckedChanged += FormatAndDefectlistOptions_CheckedChanged;
            ActiveErrorLog.CheckedChanged += FormatAndDefectlistOptions_CheckedChanged;
        }

        private void TrackBar_Scroll(object? sender, EventArgs e)
        {
            if (sender != null) // sender nasýl null oluyor hayrola?
            {
                // Ortak TrackBar kaydýrma event'i
                UInt16 value = (UInt16)((TrackBar)sender).Value;

                if (sender == trackBarMaxWrRetryCnt)
                {
                    MaxWrRetryCnt = value;
                    //lblMaxWrRetryCnt.Text= value.ToString("X");
                    lblMaxWrRetryCnt.Text = $"MaxWrRetryCnt : (Dec): {value} - (Hex): 0x{value:X}";
                }
                else if (sender == trackBarMaxRdRetryCnt)
                {
                    MaxRdRetryCnt = value;
                    lblMaxRdRetryCnt.Text = $"MaxRdRetryCnt : (Dec): {value} - (Hex): 0x{value:X}";
                }
                else if (sender == trackBarMaxECCTLevel)
                {
                    MaxEccTLevel = value;
                    lblMaxEccTLevel.Text = $"MaxEccTLevel : (Dec): {value} - (Hex): 0x{value:X}";
                }
                else if (sender == trackBarMaxCertifyTrkRewrites)
                {
                    MaxCertifyTrkRewrites = value;
                    lblMaxCertifyTrkRewrites.Text = $"MaxCertifyTrkRewrites : (Dec): {value} - (Hex): 0x{value:X}";
                }
                UpdateDefectListOptions();
            }
        }

        private void UpdateDefectListOptions()
        {
            var FormatOpts = 0;
            FormatOpts |= (CorruptUserPartitionPrimaryDefects.Checked ? 1 : 0) << 0;
            FormatOpts |= (DisableUserPartitionFormat.Checked ? 1 : 0) << 1;
            FormatOpts |= (DisableUserPartitionCertify.Checked ? 1 : 0) << 2;
            FormatOpts |= (EnableEventBasedFormatLogging.Checked ? 1 : 0) << 3;
            FormatOpts |= (EnableZoneReformatSkipping.Checked ? 1 : 0) << 4;
            FormatOpts |= (EnableSeaCOSXFSpaceFormat.Checked ? 1 : 0) << 5;
            lblFormatOptions.Text = $"Format Options : (Dec): {FormatOpts} - (Hex): 0x{FormatOpts:X}";

            var DefectListOpts = 0;
            DefectListOpts |= (GrownDefectLists.Checked ? 1 : 0) << 0;
            DefectListOpts |= (PrimaryDefectLists.Checked ? 1 : 0) << 1;
            DefectListOpts |= (ActiveErrorLog.Checked ? 1 : 0) << 2;
            lblDefectListOptions.Text = $"Defect List Options : (Dec): {DefectListOpts} - (Hex): 0x{DefectListOpts:X}";

            //"FormatPartition, m[Partition],[FormatOpts],[DefectListOpts],[MaxWrRetryCnt],[MaxRdRetryCnt],[MaxEccTLevel],[MaxCertifyTrkRewrites],[ValidKey],[DataPattern]";
            tbxCommandString.Text = $"m{cmbPartition.SelectedIndex},{FormatOpts:X},{DefectListOpts:X},{MaxWrRetryCnt:X},{MaxRdRetryCnt:X},{MaxEccTLevel:X},{MaxCertifyTrkRewrites:X},{(cmbValidKey.SelectedIndex == 0 ? "22" : "DD")},{cmbDataPattern.SelectedItem}".TrimEnd(',');
        }

        private void GenerateCommand_Click(object sender, EventArgs e)
        {
            UpdateDefectListOptions();
            //toolTip1.Show(Resource.FORMAT_PARTITION, tbxCommandString);
        }

        private void tbxCommandString_TextChanged(object sender, EventArgs e)
        {
            string[] hexValues = tbxCommandString.Text.Split(',');

            if (hexValues.Length >= 9)
            {
                if (int.TryParse(hexValues[1], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int formatOpts)
                    && int.TryParse(hexValues[2], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int defectListOpts))
                {
                    // Hex deðerlerinin bitlerini checkbox'lara ata
                    AssignBitsToCheckBoxes(formatOpts, defectListOpts, hexValues);

                    // Baþarýlý durumu için bir label güncelle
                    lblCmdStringStatus.Text = "Hex deðerleri baþarýyla okundu.";
                }
                else
                {
                    // Hata durumu için bir label güncelle
                    lblCmdStringStatus.Text = "Geçersiz hex string formatý.";
                }
            }
            else
            {
                // Hata durumu için bir label güncelle
                lblCmdStringStatus.Text = "Geçersiz hex string formatý.";
            }
        }

        private void AssignBitsToCheckBoxes(int formatOpts, int defectListOpts, string[] hexValues)
        {
            CorruptUserPartitionPrimaryDefects.Checked = (formatOpts & (1 << 0)) != 0;
            DisableUserPartitionFormat.Checked = (formatOpts & (1 << 1)) != 0;
            DisableUserPartitionCertify.Checked = (formatOpts & (1 << 2)) != 0;
            EnableEventBasedFormatLogging.Checked = (formatOpts & (1 << 3)) != 0;
            EnableZoneReformatSkipping.Checked = (formatOpts & (1 << 4)) != 0;
            EnableSeaCOSXFSpaceFormat.Checked = (formatOpts & (1 << 5)) != 0;

            GrownDefectLists.Checked = (defectListOpts & (1 << 0)) != 0;
            PrimaryDefectLists.Checked = (defectListOpts & (1 << 1)) != 0;
            ActiveErrorLog.Checked = (defectListOpts & (1 << 2)) != 0;
            try
            {
                trackBarMaxWrRetryCnt.Value = ushort.Parse(hexValues[3], NumberStyles.HexNumber);
                trackBarMaxRdRetryCnt.Value = ushort.Parse(hexValues[4], NumberStyles.HexNumber);
                trackBarMaxECCTLevel.Value = ushort.Parse(hexValues[5], NumberStyles.HexNumber);
                trackBarMaxCertifyTrkRewrites.Value = ushort.Parse(hexValues[6], NumberStyles.HexNumber);
                cmbDataPattern.Text = hexValues[8];
                cmbPartition.SelectedIndex = (hexValues[0] == "m0") ? 0 : 1;
            }
            catch (FormatException)
            {
                // Hata durumu için bir iþlem yapabilirsiniz
                // Örneðin: trackBarMaxRdRetryCnt.Value = varsayýlanDeðer;
            }
        }

        private void FormatAndDefectlistOptions_CheckedChanged(object? sender, EventArgs e)
        {
            UpdateDefectListOptions();
        }
    }
}