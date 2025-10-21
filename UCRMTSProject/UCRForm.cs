using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UCRMTS.dll;

namespace UCRMTSProject
{
    public partial class UCRForm : Form
    {
        public UCRForm()
        {
            InitializeComponent();
        }

       

        private async void button1_Click(object sender, EventArgs e)
        {
           var data = await MTSRequests.UCRVerification(txtUcr.Text, txtShipperID.Text);
            MessageBox.Show(JsonConvert.SerializeObject(data));
        }
    }
}
