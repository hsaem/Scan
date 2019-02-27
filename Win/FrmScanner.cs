using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using asprise_imaging_api;

namespace Win
{
    public partial class FrmScanner : Form
    {
        public FrmScanner()
        {
            InitializeComponent();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            Result result = new AspriseImaging().Scan(new Request()
                    .SetTwainCap(TwainConstants.ICAP_PIXELTYPE, TwainConstants.TWPT_RGB)
                    .SetPromptScanMore(true) // prompt to scan more pages
                    .AddOutputItem(new RequestOutputItem(AspriseImaging.OUTPUT_SAVE, AspriseImaging.FORMAT_JPG)
                      .SetSavePath(".\\${TMS}${EXT}")), // Environment variables in path will be expanded
                  "select", true, true); // "select" prompts device selection dialog.

            List<string> files = result == null ? null : result.GetImageFiles();
            MessageBox.Show("Scanned: " + string.Join(", ", files == null ? new string[0] : files.ToArray()));

        }
    }
}
