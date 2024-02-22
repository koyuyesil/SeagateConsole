using System.Globalization;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace SeagateConsole
{
    [Flags]
    public enum FormatOptions
    {
        //KULLANILMADI AMA G�ZEL B�R �RNEK HANG�S� SE��L�RSE O B�T� VER�R
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
        SerialPortManager portManager = new SerialPortManager("COM10", 115200);
        SerialTestConsole serialTestConsole;
        public Form1()
        {
            InitializeComponent();
            InitializeTrackBars();

            portManager._serialPort.DataReceived += _serialPort_DataReceived;

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

#if DEBUG
            serialTestConsole = new SerialTestConsole();
            serialTestConsole.Show(); // Debug modunda yeni form a�
            serialTestConsole.Location = new Point(this.Location.X + this.Width, this.Location.Y); // Formu a��lan formun tam sa��nda konumland�r
#endif
        }

        private void InitializeTrackBars()
        {
            // TrackBar'lar� ba�lat
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

            // Event'leri ba�la
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
            if (sender != null) // sender nas�l null oluyor hayrola?
            {
                // Ortak TrackBar kayd�rma event'i
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
                    // Hex de�erlerinin bitlerini checkbox'lara ata
                    AssignBitsToCheckBoxes(formatOpts, defectListOpts, hexValues);

                    // Ba�ar�l� durumu i�in bir label g�ncelle
                    lblCmdStringStatus.Text = "Hex de�erleri ba�ar�yla okundu.";
                }
                else
                {
                    // Hata durumu i�in bir label g�ncelle
                    lblCmdStringStatus.Text = "Ge�ersiz hex string format�.";
                }
            }
            else
            {
                // Hata durumu i�in bir label g�ncelle
                lblCmdStringStatus.Text = "Ge�ersiz hex string format�.";
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
                // Hata durumu i�in bir i�lem yapabilirsiniz
                // �rne�in: trackBarMaxRdRetryCnt.Value = varsay�lanDe�er;
            }
        }

        private void FormatAndDefectlistOptions_CheckedChanged(object? sender, EventArgs e)
        {
            UpdateDefectListOptions();
        }





























        // RichTextBox kontrol�ne renkli log ekleme
        private void AddLog(string message, Color color)
        {
            richTextBox1.SelectionColor = color;
            richTextBox1.AppendText(message + Environment.NewLine);
            richTextBox1.SelectionColor = richTextBox1.ForeColor; // Varsay�lan rengi geri ayarla
        }

        // Kullan�m �rne�i
        private void LogInfo(string message)
        {
            AddLog("[INFO] " + message, Color.Green);
        }

        private void LogWarning(string message)
        {
            AddLog("[WARNING] " + message, Color.Orange);
        }

        private void LogError(string message)
        {
            AddLog("[ERROR] " + message, Color.Red);
        }


        private void btnConnect_ClickAsync(object sender, EventArgs e)
        {


            LogInfo("Port bekleniyor...");
            if (portManager.WaitForPort(5)) // 30 saniye boyunca port a��lmay� bekler
            {
                LogInfo("Port ba�ar�yla a��ld�!");
                portManager._serialPort.Write(new byte[] { 26 }, 0, 1);
                portManager._serialPort.WriteLine("\x1A");
            }
            else
            {
                LogError("Port a��lamad�.");
            }

            //portManager.ClosePort(); // ��lem tamamland�ktan sonra portu kapat //TODO HACK
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Veri al�nd���nda bu metod �al���r
            int bytesToRead = portManager._serialPort.BytesToRead; // Al�nan bayt say�s�n� kontrol et

            if (bytesToRead > 0)
            {
                byte[] buffer = new byte[bytesToRead];

                // Seri porttan veriyi oku
                portManager._serialPort.Read(buffer, 0, bytesToRead);

                // Okunan baytlar� stringe �evir
                string receivedData = Encoding.ASCII.GetString(buffer);

                // TextBox'a gelen veriyi ekleyin (UI i�lemleri i�in Invoke kullan�n)
                Invoke(new Action(() =>
                {
                    richTextBox1.AppendText(receivedData);
                }));
            }
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
#if DEBUG
            if (serialTestConsole != null)
            {
                serialTestConsole.Location = new Point(this.Location.X + this.Width, this.Location.Y); // Formu a��lan formun tam sa��nda konumland�r
            }

#endif
        }
    }
}