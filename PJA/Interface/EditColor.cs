using System.Drawing;
using System.Windows.Forms;

public partial class EditColor: Form {
	private Label[] colors = new Label[27];
	private int valColor;
	public int ValColor { get { return valColor; } }
	public bool isValide;

	public EditColor(int numColor, int valColor, int rgbColor) {
		InitializeComponent();
		selColor.BackColor = Color.FromArgb(rgbColor);
		lblNumColor.Text = "Couleur " + numColor;
		lblValColor.Text = "=" + valColor;
		int i = 0;
		for (int y = 0; y < 3; y++)
			for (int x = 0; x < 9; x++) {
				colors[i] = new Label();
				colors[i].BorderStyle = BorderStyle.FixedSingle;
				colors[i].Location = new Point(4 + x * 48, 80 + y * 40);
				colors[i].Size = new Size(40, 32);
				colors[i].Tag = i;
				colors[i].BackColor = Color.FromArgb(ConvImgCpc.BitmapCPC.RgbCPC[i].GetColor);
				colors[i].Click += ClickColor;
				Controls.Add(colors[i]);
				i++;
			}
	}

	void ClickColor(object sender, System.EventArgs e) {
		Label colorClick = sender as Label;
		valColor = colorClick.Tag != null ? (int)colorClick.Tag : 0;
		lblValColor.Text = "=" + valColor;
		selColor.BackColor = colorClick.BackColor;
	}

	private void bpValide_Click(object sender, System.EventArgs e) {
		isValide = true;
		Close();
	}

	private void bpAnnule_Click(object sender, System.EventArgs e) {
		Close();
	}
}

