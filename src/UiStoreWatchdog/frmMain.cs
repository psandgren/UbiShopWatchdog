namespace UiStoreWatchdog
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            timer1.Interval = 30000;

            Resize += FrmMain_Resize;
        }

        private void FrmMain_Resize(object? sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                ShowInTaskbar = true;
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void rbOffline_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void rbOnline_CheckedChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                timer1.Start();
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                bool inStock = await FetchStatus();
                if (inStock)
                {
                    notifyIcon1.BalloonTipTitle = "In stock!";
                    notifyIcon1.BalloonTipText = "Your item is now in stock!";
                    notifyIcon1.ShowBalloonTip(3000);
                }
                timer1.Start();
            }
            catch (Exception ex)
            {
                timer1.Stop();
            }
        }

        private async Task<bool> FetchStatus()
        {
            using HttpClient httpClient = new HttpClient();
            //string html = await httpClient.GetStringAsync(txtUrl.Text);
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 12_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.67 Safari/537.36");
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(txtUrl.Text);

            string responsetext = await httpResponseMessage.Content.ReadAsStringAsync();

            bool inStock = responsetext.Contains("comProductTile__inStock");
            return inStock;
        }
    }
}