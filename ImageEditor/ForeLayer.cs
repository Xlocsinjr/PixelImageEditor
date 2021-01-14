using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ImageEditor
{
    public class ForeLayer : LayerImage
    {
        public static ColorDialog PlainColourDialog;
        public static List<Image> PresetImgs;
        public static ImageList PresetImgList;

        protected GroupBox GroupBox;
        protected ComboBox ComboBox;
        protected TableLayoutPanel TablePlainColour;
        protected ListView ListViewPresets;
        protected PictureBox PlainColourPreview;
        protected Button PlainColourButton;

        public ForeLayer(int layerHeight, string groupBoxText, SplitterPanel parentPanel, 
            CombinedLayers targetCombinedLayers, ColorDialog colorDialog) : 
            base(layerHeight, targetCombinedLayers)
        {

            PlainColourDialog = colorDialog;

            // Initialisations
            this.InitialiseLayerControls(groupBoxText, parentPanel);
            this.InitialiseListView();
            this.ComboBox.SelectedIndex = 2;
            this.ComboBoxIndexCheck();
        }


        private void InitialiseLayerControls(string groupBoxText, SplitterPanel parentPanel)
        {
            // Creates all controls in a groupbox within the chosen parent panel
            this.GroupBox = new GroupBox();
            this.GroupBox.Text = groupBoxText;
            this.GroupBox.Dock = DockStyle.Top;
            this.GroupBox.AutoSize = true;

            this.ComboBox = new ComboBox();
            this.ComboBox.Dock = DockStyle.Top;
            this.ComboBox.Items.Add("Plain colour");
            this.ComboBox.Items.Add("Presets");
            this.ComboBox.Items.Add("Clear");
            this.ComboBox.SelectedIndexChanged += new EventHandler(this.ComboBox_SelectedIndexChanged);

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
            this.ListViewPresets.SelectedIndexChanged += new EventHandler(this.ListViewPresets_SelectedIndexChanged);

            // Adds the groupgbox to the parentpanel and all the created controls to that groupbox
            parentPanel.Controls.Add(GroupBox);

            this.GroupBox.Controls.Add(this.TablePlainColour);
            this.TablePlainColour.Controls.Add(this.PlainColourButton);
            this.TablePlainColour.Controls.Add(this.PlainColourPreview);

            this.GroupBox.Controls.Add(this.ListViewPresets);

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
            else
            {
                base.ClearLayer();
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

                this.TargetCombinedLayers.ShowCombinedLayers();
            }
        }

        // ================================== LIST VIEW ===================================
        public static void InitialisePresets()
        {
            // Adds all the premade images to the list of preset images PresetImgs

            PresetImgList = new ImageList(); // for the listview thumbnails
            PresetImgs = new List<Image>(); // for the preset images
            AddPresetsToLists(PresetImgList, PresetImgs, Properties.Resources.BgPresetSky);
            AddPresetsToLists(PresetImgList, PresetImgs, Properties.Resources.testImage);

            // NOTE: somehow retrieving images from the ImageList only returns a thumbnail sized image so a second
            // list of images is needed to contain the true sized presets.
        }

        private static void AddPresetsToLists(ImageList imgList, List<Image> list, Image img)
        {
            // To be used by InitialisePresets
            // Adds an image to an ImageList and to a list of Images
            imgList.Images.Add(img);
            list.Add(img);
        }

        private void InitialiseListView()
        {
            //set the small and large ImageList properties of listview
            this.ListViewPresets.LargeImageList = PresetImgList;
            this.ListViewPresets.SmallImageList = PresetImgList;

            this.ListViewPresets.View = View.LargeIcon;
            this.ListViewPresets.Items.Add(new ListViewItem() { ImageIndex = 0, Text = "Sky" });
            this.ListViewPresets.Items.Add(new ListViewItem() { ImageIndex = 1, Text = "test" });
        }

        private void ListViewPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ListViewPresetsChoose();
        }

        private void ListViewPresetsChoose()
        {
            if (ListViewPresets.SelectedIndices.Count == 1)
            {
                // Updates background layer with chosen preset image by retrieving the chosen item index
                // and retrieving the corresponding preset image from the list of preset images of the same index
                var chosenPreset = this.ListViewPresets.SelectedIndices[0];
                Image img = PresetImgs[chosenPreset];
                Bitmap bm = new Bitmap(img, Form1.IMG_WIDTH, Form1.IMG_HEIGHT);

                this.LayerBitmap = bm;

                this.TargetCombinedLayers.ShowCombinedLayers();


            }
        }
    }
}
