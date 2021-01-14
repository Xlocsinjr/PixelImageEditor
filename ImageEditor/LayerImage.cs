using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    public class LayerImage
    {
        public Bitmap LayerBitmap;
        public int LayerHeight;
        CombinedLayers TargetCombinedLayers;

        protected GroupBox GroupBox;
        protected FlowLayoutPanel FlowPanel;
        protected ComboBox ComboBox;
        protected TableLayoutPanel TablePlainColour;
        protected ListView ListViewPresets;
        protected PictureBox PlainColourPreview;
        protected Button PlainColourButton;

        static ColorDialog PlainColourDialog;

        public LayerImage(int layerHeight, SplitterPanel parentPanel, CombinedLayers targetCombinedLayers, ColorDialog colorDialog)
        {
            PlainColourDialog = colorDialog;
            this.LayerHeight = layerHeight;
            this.TargetCombinedLayers = targetCombinedLayers;

            this.InitialiseLayerControls(parentPanel);
            


            this.ComboBox.SelectedIndex = 2;
            this.ComboBoxIndexCheck();

            // Initialise with empty bitmap
            this.LayerBitmap = new Bitmap(Form1.IMG_WIDTH, Form1.IMG_HEIGHT);
        }





        private void InitialiseLayerControls(SplitterPanel parentPanel)
        {
            // Creates all controls in a groupbox within the chosen parent panel
            this.GroupBox = new GroupBox();
            this.GroupBox.Text = "Foreground Layer";
            this.GroupBox.Dock = DockStyle.Top;
            this.GroupBox.AutoSize = true;

            this.ComboBox = new ComboBox();
            this.ComboBox.Dock = DockStyle.Top;
            this.ComboBox.Items.Add("Plain colour");
            this.ComboBox.Items.Add("Presets");
            this.ComboBox.Items.Add("Clear");
            this.ComboBox.SelectedIndexChanged += new EventHandler(this.ComboBox_SelectedIndexChanged);

            this.FlowPanel = new FlowLayoutPanel();
            this.FlowPanel.Dock = DockStyle.Top;
            this.FlowPanel.FlowDirection = FlowDirection.TopDown;

            this.TablePlainColour = new TableLayoutPanel();
            this.TablePlainColour.Dock = DockStyle.Top;
            this.TablePlainColour.ColumnCount = 2;
            this.TablePlainColour.RowCount = 1;
            this.TablePlainColour.AutoSize = true;
            this.TablePlainColour.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.50F));
            this.TablePlainColour.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.50F));
            

            this.PlainColourButton = new Button();
            this.PlainColourButton.Text = "Choose colour";
            this.PlainColourButton.Click += new EventHandler(this.PlainColourButtonClick);

            this.PlainColourPreview = new PictureBox();
            this.PlainColourPreview.Size = new Size(29, 29);
            this.PlainColourPreview.BorderStyle = BorderStyle.Fixed3D;

            this.ListViewPresets = new ListView();
            this.ListViewPresets.Dock = DockStyle.Top;
            this.ListViewPresets.AutoSize = true;


            parentPanel.Controls.Add(GroupBox);
            this.GroupBox.Controls.Add(this.FlowPanel);
            this.FlowPanel.Controls.Add(this.TablePlainColour);
            this.TablePlainColour.Controls.Add(this.PlainColourButton);
            this.TablePlainColour.Controls.Add(this.PlainColourPreview);
            this.FlowPanel.Controls.Add(this.ListViewPresets);

            this.GroupBox.Controls.Add(this.ComboBox);

        }


        
        // =========================== COMBO BOX ===================================
        protected void ComboBoxIndexCheck()
        {
            this.TablePlainColour.Visible = false;
            this.ListViewPresets.Visible = false;

            if (ComboBox.SelectedIndex == 0)
            {
                this.TablePlainColour.Visible = true;
            }
            else if (ComboBox.SelectedIndex == 1)
            {
                this.ListViewPresets.Visible = true;
            }
        }

        protected void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxIndexCheck();
        }




        // =========================== PLAIN COLOUR CHOOSE ===================================
        protected void PlainColourButtonClick(object sender, EventArgs e)
        {
            this.PlainColourChoose();
        }

        public void PlainColourChoose()
        {
            // Show the color dialog. If the user clicks OK, load the
            // colour that the user chose.
            if (PlainColourDialog.ShowDialog() == DialogResult.OK)
            {
                // create an image of the desired size
                var bm = new Bitmap(Form1.IMG_WIDTH, Form1.IMG_HEIGHT);

                using (var graphics = Graphics.FromImage(bm))
                {
                    // set background color
                    graphics.Clear(PlainColourDialog.Color);
                }

                // Updates the plain colour preview box
                this.PlainColourPreview.Image = bm;

                // Update background layer to new colour
                this.LayerBitmap = bm;

                TargetCombinedLayers.ShowCombinedLayers();
            }
        }
    }
}
