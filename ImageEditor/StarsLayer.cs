using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ImageEditor
{
    public class StarsLayer : LayerImage
    {
        int StarNoiseThreshold;

        FlowLayoutPanel FlowPanel;
        CheckBox StarsCheckbox;
        Button RegenerateButton;
        TrackBar StarDensityTrackbar;
        Label StarDensityLabel;

        public StarsLayer(int layerHeight, GroupBox parentGroupbox, CombinedLayers targetCombinedLayers) 
            : base(layerHeight, targetCombinedLayers)
        {
            // This class' controls have to be added to an other groupbox
            InitialiseStarControls(parentGroupbox);

        }


        // ======================================= INITIALISATIONS =================================================
        private void InitialiseStarControls(GroupBox parentGroupbox)
        {
            this.FlowPanel = new FlowLayoutPanel();
            this.FlowPanel.Dock = DockStyle.Top;
            this.FlowPanel.AutoSize = true;

            this.StarsCheckbox = new CheckBox();
            this.StarsCheckbox.Text = "Stars";
            this.StarsCheckbox.CheckedChanged += new EventHandler(StarsCheckBox_CheckedChanged);
            this.StarsCheckbox.AutoSize = true;

            this.RegenerateButton = new Button();
            this.RegenerateButton.Text = "Regenerate";
            this.RegenerateButton.Click += new EventHandler(StarsCheckBox_CheckedChanged);

            this.StarDensityTrackbar = new TrackBar();
            this.StarDensityTrackbar.Maximum = 20;
            this.StarDensityTrackbar.Minimum = 1;
            this.StarDensityTrackbar.Width = 177;
            this.StarDensityTrackbar.ValueChanged += new EventHandler(StarDensityTrackbar_ValueChanged);

            this.StarDensityLabel = new Label();

            parentGroupbox.Controls.Add(this.FlowPanel);
            this.FlowPanel.Controls.Add(this.StarsCheckbox);
            this.FlowPanel.Controls.Add(this.RegenerateButton);
            this.FlowPanel.Controls.Add(this.StarDensityTrackbar);
            this.FlowPanel.Controls.Add(this.StarDensityLabel);

        }

        // ======================================= BACKGROUND STAR GENERATION ======================================

        private void StarsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // generates white star pixels if checkbox is checked, else clears star layer
            if (this.StarsCheckbox.Checked)
            {
                GenerateStars();
            }
            else
            {
                base.ClearLayer();
            }
        }

        void GenerateStars()
        {
            // Determine star generation threshold based on trackbar value
            // 1pt is 0.10%. higher value -> lower threshold -> more stars
            this.StarNoiseThreshold = 1000 - this.StarDensityTrackbar.Value;

            // Loops through all pixels of new empty bitmap
            Random rnumber = new Random();
            Bitmap newStarBitmap = new Bitmap(Form1.IMG_WIDTH, Form1.IMG_HEIGHT);
            for (int y = 0; y < Form1.IMG_HEIGHT; y++)
            {
                for (int x = 0; x < Form1.IMG_WIDTH; x++)
                {
                    // Creates a star (white pixel) if randomly generated number exceeds or equals threshold
                    if (rnumber.Next(1000) >= StarNoiseThreshold)
                    {
                        newStarBitmap.SetPixel(x, y, Color.White);
                    }
                }
            }
            
            this.LayerBitmap = newStarBitmap;
            this.TargetCombinedLayers.ShowCombinedLayers();
        }

        private void UpdateStarDensityLabel()
        {
            // Update label for star density
            double starDensity = this.StarDensityTrackbar.Value * 0.10;
            this.StarDensityLabel.Text = "Star density: " + starDensity.ToString() + "%";
        }

        private void StarDensityTrackbar_ValueChanged(object sender, EventArgs e)
        {
            // updates label and regenerate stars
            UpdateStarDensityLabel();
            if (this.StarsCheckbox.Checked)
            {
                GenerateStars();
            }
        }

        // ======================================= CLEAR OPTIONS ======================================
        public override void ClearOptions()
        {
            this.StarsCheckbox.Checked = false;
        }
    }
}
