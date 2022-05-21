using System.ComponentModel;

namespace UiStoreWatchdog
{
    public partial class frmMain : Form
    {
        public BindingList<ItemWithStatus> Items { get; set; } = new();
        public BindingSource bindingSource { get; set; }

        public frmMain()
        {
            InitializeComponent();
            timer1.Interval = Convert.ToInt32(numericUpDown1.Value * 1000);

            Resize += FrmMain_Resize;

            LoadList();

            bindingSource = new BindingSource(Items, null);
            dataGridView1.DataSource = bindingSource;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].HeaderText = "Notify me";

            bindingSource.ListChanged += BindingSource_ListChanged;
        }

        private void BindingSource_ListChanged(object? sender, ListChangedEventArgs e)
        {
            SaveList();
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
            Icon = Properties.Resources.m_red;
            notifyIcon1.Icon = Properties.Resources.m_red;
        }

        private void rbOnline_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Start();
            Icon = Properties.Resources.m_green;
            notifyIcon1.Icon = Properties.Resources.m_green;
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();

                foreach (ItemWithStatus item in Items)
                {
                    if (item.Url == null || !IsValidURI(item.Url))
                    {
                        continue;
                    }

                    if (await FetchStatus(item.Url))
                    {
                        item.Status = "In stock!";

                        string itemName = string.IsNullOrWhiteSpace(item.Name) ? "Something" : item.Name;
                        notifyIcon1.BalloonTipTitle = $"{itemName} is in stock!";
                        notifyIcon1.BalloonTipText = $"Your item is now in stock!";
                        notifyIcon1.ShowBalloonTip(3000);
                    }
                    else
                    {
                        item.Status = "Sold out!";
                    }

                }

                dataGridView1.Refresh();
                timer1.Start();
            }
            catch (Exception ex)
            {
                timer1.Stop();
            }
        }

        private async Task<bool> FetchStatus(string url)
        {
            using HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 12_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.4951.67 Safari/537.36");
            HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

            string responsetext = await httpResponseMessage.Content.ReadAsStringAsync();

            bool inStock = responsetext.Contains("comProductTile__inStock");
            return inStock;
        }

        private bool IsValidURI(string uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            {
                return false;
            }

            if (!Uri.TryCreate(uri, UriKind.Absolute, out Uri? tmp))
            {
                return false;
            }

            return tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps;
        }

        private void SaveList()
        {
            // Save list
            string json = System.Text.Json.JsonSerializer.Serialize(Items.Select(x => x as Item));
            File.WriteAllText(Application.UserAppDataPath + "\\watchlist.json", json);
        }

        private void LoadList()
        {
            string path = Application.UserAppDataPath + "\\watchlist.json";
            string json = File.ReadAllText(path);

            List<Item>? data = System.Text.Json.JsonSerializer.Deserialize<List<Item>>(json);
            if (data == null)
            {
                MessageBox.Show($"Could not load list from {path}", "Error", MessageBoxButtons.OK);
                data = new();
            }

            Items = new BindingList<ItemWithStatus>(data.Select(x => new ItemWithStatus(x)).ToList());
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(numericUpDown1.Value * 1000);
        }
    }
}