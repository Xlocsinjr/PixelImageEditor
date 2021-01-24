using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ImageEditor
{
    // This class defines the usual layer with options for plain colour and presets.
    public class ForeLayer : LayerImage
    {
        // static fields that all instances need to access
        public static ColorDialog PlainColourDialog;
        public static List<Image> PresetImgs;
        public static ImageList PresetImgList;

        public GroupBox GroupBox;           // public to allow other controls to be added to the groupbox
        public TableLayoutPanel LayoutTable;
        public TableLayoutPanel colourChooseTable;
        protected ComboBox ComboBox;
        protected TableLayoutPanel TablePlainColour;
        protected ListView ListViewPresets;
        protected PictureBox PlainColourPreview;
        protected Button PlainColourButton;

        // CONSTRUCTOR sets to which CombinedLayers this layer belongs to.
        public ForeLayer(int layerHeight, string groupBoxText) : 
            base(layerHeight)
        {
            // Initialisations
            this.InitialiseLayerControls(groupBoxText);
            this.InitialiseListView();
            this.ComboBox.SelectedIndex = 0;
            this.ComboBoxIndexCheck();
            this.ClearOptions();
        }

        // Creates all controls in a groupbox within the targetpanel of this
        // layer's CombinedLayers.
        private void InitialiseLayerControls(string groupBoxText)
        {
            this.GroupBox = new GroupBox();
            this.GroupBox.Text = groupBoxText;
            this.GroupBox.Dock = DockStyle.Fill;
            this.GroupBox.AutoSize = true;

            this.LayoutTable = new TableLayoutPanel();
            this.LayoutTable.Dock = DockStyle.Top;
            this.LayoutTable.AutoSize = true;
            this.LayoutTable.ColumnCount = 1;
            this.LayoutTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.00F));

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

            

        }

        // Adds the groupbox to the CombinedLayers' TargetControlsPanel and all the created controls to that groupbox
        public override void AddControls()
        {
            this.TargetCombinedLayers.TargetControlsPanel.Controls.Add(this.GroupBox);

            this.GroupBox.Controls.Add(this.LayoutTable);
            this.LayoutTable.Controls.Add(this.ComboBox);
            this.LayoutTable.Controls.Add(this.ListViewPresets);
            this.LayoutTable.Controls.Add(this.TablePlainColour);
            this.TablePlainColour.Controls.Add(this.PlainColourButton);
            this.TablePlainColour.Controls.Add(this.PlainColourPreview);

            

            

            //this.GroupBox.Controls.Add(this.TablePlainColour);
            //this.TablePlainColour.Controls.Add(this.PlainColourButton);
            //this.TablePlainColour.Controls.Add(this.PlainColourPreview);

            //this.GroupBox.Controls.Add(this.ListViewPresets);

            //this.GroupBox.Controls.Add(this.ComboBox);
        }


        // =========================== COMBO BOX ===================================
        // Sets which controls are visible by which element is chosen in the combobox
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

        // Handles the selectedIndexChanged event of the combobox
        protected void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxIndexCheck();
        }

        


        // =========================== PLAIN COLOUR CHOOSE ===================================
        // Handles the button click event of the Plain colour choose button
        protected void PlainColourButtonClick(object sender, EventArgs e)
        {
            this.PlainColourChoose();
        }

        // Opens the colordialog and changes the layers' image to that chosen colour
        public void PlainColourChoose()
        {
            // Show the color dialog. If the user clicks OK, load the
            // colour that the user chose.
            if (PlainColourDialog.ShowDialog() == DialogResult.OK)
            {
                var bm = new Bitmap(Form1.IMG_WIDTH, Form1.IMG_HEIGHT);

                using (var graphics = Graphics.FromImage(bm))
                {
                    graphics.Clear(PlainColourDialog.Color);
                }

                // Updates the plain colour preview box and layer bitmap
                this.PlainColourPreview.Image = bm;
                this.LayerBitmap = bm;

                this.TargetCombinedLayers.ShowCombinedLayers();
            }
        }

        // ================================== LIST VIEW ===================================
        // Adds all the premade images to the list of preset images PresetImgs
        public static void InitialisePresets()
        {
            PresetImgList = new ImageList(); // for the listview thumbnails
            PresetImgs = new List<Image>(); // for the preset images
            AddPresetsToLists(PresetImgList, PresetImgs, Properties.Resources.BgPresetSky);
            AddPresetsToLists(PresetImgList, PresetImgs, Properties.Resources.testImage);

            // NOTE: somehow retrieving images from the ImageList only returns a thumbnail sized image so a second
            // list of images is needed to contain the true sized presets.
        }

        // To be used by InitialisePresets. Adds an image to an ImageList and to a list of Images
        private static void AddPresetsToLists(ImageList imgList, List<Image> list, Image img)
        {
            imgList.Images.Add(img);
            list.Add(img);
        }

        // Initialises the ListView control to contain the preset images.
        private void InitialiseListView()
        {
            //set the small and large ImageList properties of listview
            this.ListViewPresets.LargeImageList = PresetImgList;
            this.ListViewPresets.SmallImageList = PresetImgList;

            this.ListViewPresets.View = View.LargeIcon;
            this.ListViewPresets.Items.Add(new ListViewItem() { ImageIndex = 0, Text = "Sky" });
            this.ListViewPresets.Items.Add(new ListViewItem() { ImageIndex = 1, Text = "test" });
        }

        // Handles the SelectedIndexChanged event of the ListView
        private void ListViewPresets_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ListViewPresetsChoose();
        }

        // Updates background layer with chosen preset image by retrieving the chosen item index
        // and retrieving the corresponding preset image from the list of preset images of the same index
        private void ListViewPresetsChoose()
        {
            if (ListViewPresets.SelectedIndices.Count == 1)
            {
                
                var chosenPreset = this.ListViewPresets.SelectedIndices[0];
                Image img = PresetImgs[chosenPreset];
                Bitmap bm = new Bitmap(img, Form1.IMG_WIDTH, Form1.IMG_HEIGHT);

                this.LayerBitmap = bm;

                this.TargetCombinedLayers.ShowCombinedLayers();


            }
        }

        // ======================================= CLEAR OPTIONS ======================================
        // Clears/resets all options to default
        public override void ClearOptions()
        {
            this.PlainColourPreview.Image = new Bitmap(1, 1);
        }
    }
}
