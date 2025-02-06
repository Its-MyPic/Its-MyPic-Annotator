using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace MyPic_Annotator
{
    public partial class Form1 : Form
    {
        JsonSerializerOptions jsonSerializerOptions = new()
        {
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        private readonly List<Data> data = [];
        private readonly List<string> character = ["高松燈", "千早愛音", "要樂奈", "長崎爽世", "椎名立希", "三角初華", "豐川祥子", "八幡海鈴", "祐天寺若麥", "若葉睦"];
        private readonly List<CheckBox> characterBox;
        int currnetIndex = 0;
        bool unsaved = false;
        private readonly List<Keys> keys = [Keys.Q, Keys.W, Keys.E, Keys.R, Keys.T, Keys.A, Keys.S, Keys.D, Keys.F, Keys.G];
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("data.json"))
                data = JsonSerializer.Deserialize<List<Data>>(File.ReadAllText($"data.json")) ?? [];
            else
            {
                MessageBox.Show("data.json not found. Please load the data file.");
                OpenFileDialog openFileDialog = new()
                {
                    Filter = "JSON files (*.json)|*.json",
                    Title = "Open an JSON File"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    data = JsonSerializer.Deserialize<List<Data>>(File.ReadAllText(openFileDialog.FileName)) ?? [];
                }
            }
            characterBox = [];
            for (int i = 0; i < character.Count; i++)
            {
                int x = i < 5 ? 20 : 140;
                int y = 401 + (i % 5) * 20;
                CheckBox checkBox = new()
                {
                    Text = $"{character[i]} ({keys[i].ToString()})",
                    Location = new Point(x, y),
                    AutoSize = true,
                    TabStop = false
                };
                Controls.Add(checkBox);
                characterBox.Add(checkBox);
            }
        }

        private void LoadImage(string session, int frame)
        {
            picture.Load($"https://mygodata.0m0.uk/images/{session}_{frame}.jpg");
        }

        private void LoadCurrentData()
        {
            LoadImage(data[currnetIndex].episode, data[currnetIndex].frame_start);
            if (data[currnetIndex].character != 0)
            {
                for (int i = 0; i < characterBox.Count; i++)
                {
                    characterBox[i].Checked = (data[currnetIndex].character & (1 << i)) != 0;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            foreach (Control ctrl in Controls)
            {
                ctrl.TabStop = false; // 全部控制項關閉 Tab 選取
            }
            LoadCurrentData();
        }

        private void save_Click(object sender, EventArgs e)
        {
            int val = 0;
            for (int i = 0; i < characterBox.Count; i++)
            {
                if (characterBox[i].Checked)
                {
                    val += 1 << i;
                }
            }
            data[currnetIndex].character = val;
            unsaved = true;
            Debug.WriteLine(val);
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (currnetIndex < data.Count - 1)
            {
                currnetIndex++;
                LoadCurrentData();
            }
        }

        private void nextUnannotate_Click(object sender, EventArgs e)
        {
            while (currnetIndex < data.Count - 1)
            {
                currnetIndex++;
                if (data[currnetIndex].character == 0)
                {
                    LoadCurrentData();
                    return;
                }
            }
            DialogResult result = MessageBox.Show("All images are annotated. Do you want to save the data?", "Info", MessageBoxButtons.OK);

        }

        private void prev_Click(object sender, EventArgs e)
        {
            if (currnetIndex > 0)
            {
                currnetIndex--;
                LoadCurrentData();
            }
        }

        private void prevUnannotate_Click(object sender, EventArgs e)
        {
            while (currnetIndex > 0)
            {
                currnetIndex--;
                if (data[currnetIndex].character == 0)
                {
                    LoadCurrentData();
                    return;
                }
            }
            DialogResult result = MessageBox.Show("All images are annotated. Do you want to save the data?", "Info", MessageBoxButtons.OK);

        }

        private void export_Click(object sender, EventArgs e)
        {
            // promote user to select save location
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Save an JSON File",
                FileName = "new_data.json"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, JsonSerializer.Serialize(data, jsonSerializerOptions));
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (unsaved)
            {
                DialogResult result = MessageBox.Show("Do you want to save the data?", "Info", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    export_Click(sender, e);
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < keys.Count(); i++)
            {
                if (e.KeyCode == keys[i])
                {
                    characterBox[i].Checked = !characterBox[i].Checked;
                }
            }
            switch (e.KeyCode)
            {
                case Keys.L:
                    next.PerformClick(); break;
                case Keys.J:
                    prev.PerformClick(); break;
                case Keys.O:
                    nextUnannotate.PerformClick(); break;
                case Keys.U:
                    prevUnannotate.PerformClick(); break;
            }
        }
    }

    class Data
    {
        public required string text { get; set; }
        public required string episode { get; set; }
        public int frame_start { get; set; }
        public int frame_end { get; set; }
        public int segment_id { get; set; }
        public int character { get; set; }
    }
}
