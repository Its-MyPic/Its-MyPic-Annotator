using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;

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
		readonly HttpClient client = new();
		public Form1()
		{
			TopMost = true;
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
					Text = $"{character[i]} ({keys[i]})",
					Location = new Point(x, y),
					AutoSize = true,
					TabStop = false
				};
				Controls.Add(checkBox);
				characterBox.Add(checkBox);
			}
		}

		private void LoadImage()
		{
			Debug.WriteLine($"https://qwer.0m0.uk/images/{data[currnetIndex].season}/{data[currnetIndex].episode}/{data[currnetIndex].frame_prefer}.webp");
			HttpResponseMessage result;
			using (var task = Task.Run(() => client.GetAsync($"https://qwer.0m0.uk/images/{data[currnetIndex].season}/{data[currnetIndex].episode}/{data[currnetIndex].frame_prefer}.webp")))
			{
				task.Wait();
				result = task.Result;
			}
			result.EnsureSuccessStatusCode();
			Imazen.WebP.SimpleDecoder decoder = new();
			using (var task = Task.Run(() => result.Content.ReadAsByteArrayAsync()))
			{
				task.Wait();
				var bytes = task.Result;
				Debug.WriteLine(bytes.Length);
				var bitmap = decoder.DecodeFromBytes(bytes, bytes.Length);
				picture.Image = bitmap;
			}

			//picture.Load(stream);

		}

		private void LoadCurrentData()
		{
			if (data[currnetIndex].frame_prefer == 0)
			{
				data[currnetIndex].frame_prefer = (data[currnetIndex].frame_start + data[currnetIndex].frame_end) / 2;
			}
			LoadImage();
			numericUpDown1.Value = currnetIndex;
			subtitleLabel.Text = data[currnetIndex].text;
			trackBar1.Minimum = data[currnetIndex].frame_start;
			trackBar1.Maximum = data[currnetIndex].frame_end;
			trackBar1.Value = data[currnetIndex].frame_prefer;
			if (data[currnetIndex].character != -1)
			{
				for (int i = 0; i < characterBox.Count; i++)
				{
					characterBox[i].Checked = (data[currnetIndex].character & (1 << i)) != 0;
				}
				anotateStatus.Text = "Annotated";
				anotateStatus.ForeColor = Color.Green;
			}
			else
			{
				anotateStatus.Text = "Unannotated";
				anotateStatus.ForeColor = Color.Red;
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
			TopMost = false;
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
			if (val == -1)
			{
				anotateStatus.Text = "Unannotated";
				anotateStatus.ForeColor = Color.Red;
			}
			else
			{
				anotateStatus.Text = "Annotated";
				anotateStatus.ForeColor = Color.Green;
			}
			unsaved = false;
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
				if (data[currnetIndex].character == -1)
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
				if (data[currnetIndex].character == -1)
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
				case Keys.OemPeriod:
					if (trackBar1.Value < trackBar1.Maximum)
						trackBar1.Value += 1;
					break;
				case Keys.Oemcomma:
					if (trackBar1.Value > trackBar1.Minimum)
						trackBar1.Value -= 1;
					break;
				case Keys.K:
					save.PerformClick(); break;
				default:
					var idx = keys.IndexOf(e.KeyCode);
					if (idx != -1)
						characterBox[idx].Checked = !characterBox[idx].Checked;
					break;
			}
		}

		private void trackBar1_ValueChanged(object sender, EventArgs e)
		{
			unsaved = true;
			data[currnetIndex].frame_prefer = Convert.ToInt32(trackBar1.Value);
			Debug.WriteLine(trackBar1.Value);
			LoadCurrentData();
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			currnetIndex = Convert.ToInt32(numericUpDown1.Value);
			Debug.WriteLine(trackBar1.Value);
			LoadCurrentData();
		}
	}

	class Data
	{
		public required string text { get; set; }
		public required int season { get; set; }
		public required int episode { get; set; }
		public int frame_start { get; set; }
		public int frame_prefer { get; set; }
		public int frame_end { get; set; }
		public int segment_id { get; set; }
		public int character { get; set; }
	}
}
