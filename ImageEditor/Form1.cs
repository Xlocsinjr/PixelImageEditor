using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace ImageEditor
{
    public partial class Form1 : Form
    {
        public static int IMG_WIDTH = 200;
        public static int IMG_HEIGHT = 150;

        int StarNoiseThreshold;

        ImageList BgPresetImgList = new ImageList(); // for the listview thumbnails
        List<Image> BgPresetImgs = new List<Image> { }; // for the preset imgs

        Bitmap CombinedBitmap;

        // Declare layer images list
        public List<Bitmap> LayersList; 

        // Declare list of the enums so the indeces can later be retrieved
        List<Layers> LayersIndeces;

        // Declare enum of layers. 
        // To declare additional layers, simply add a new entry in the enum.
        public enum Layers
        {
            Background,
            Star,
        }


        // CONSTRUCTOR
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = Properties.Resources.BgPresetSky;
            
            // Open on Plain colour on the combobox for the background layers
            comboBoxBg.SelectedIndex = 0;

            LayersList = new List<Bitmap> { };
            LayersIndeces = new List<Layers> { };

            // Initialises the LayersIndeces to contain the enums so the indeces can later be retrieved
            // Also initialises the layerslist with empty transparent images
            foreach (Layers layer in (Layers[])Enum.GetValues(typeof(Layers)))
            {
                LayersIndeces.Add(layer);

                var newBitmap = new Bitmap(IMG_WIDTH, IMG_HEIGHT);
                newBitmap.MakeTransparent(Color.White);
                LayersList.Add(newBitmap);
            }

            ListviewBgChooseInit();
            UpdateStarDensityLabel();

            ForeLayer ForeGround = new ForeLayer(splitContainer1.Panel2);
            ForeLayer ForeGround2 = new ForeLayer(splitContainer1.Panel2);

            NewImage();

        }

        // ======================================= TOOLSTRIP ======================================

        private void toolStripFileOpen_Click(object sender, EventArgs e)
        {
            // Show the Open File dialog. If the user clicks OK, load the
            // picture that the user chose.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private void toolStripFileExit_Click(object sender, EventArgs e)
        {
            // closes the app
            this.Close();
        }

        private void toolStripFileNew_Click(object sender, EventArgs e)
        {
            NewImage();
        }

        private void NewImage()
        {
            // resets all layers to blank
            LayersList = new List<Bitmap> { };
            foreach (Layers l in LayersIndeces)
            {
                var newBitmap = new Bitmap(IMG_WIDTH, IMG_HEIGHT);
                LayersList.Add(newBitmap);
            }

            // Clears bgBitmap
            var bgBitmap = new Bitmap(IMG_WIDTH, IMG_HEIGHT);
            using (var graphics = Graphics.FromImage(bgBitmap))
            {
                // specify the desired quality of the render and text, if you wish
                //graphics.CompositingQuality = CompositingQuality.HighQuality;
                //graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                // From: https://stackoverflow.com/questions/61513832/how-to-edit-image-in-c-sharp;

                // set background color
                graphics.Clear(Color.Black);
            }

            // Updates the plain colour preview box and the background layer
            pictureBoxBgPlainColourPreview.Image = bgBitmap;
            UpdateLayer(Layers.Background, bgBitmap);

            // Turns off any additional options
            StarsCheckBox.Checked = false;
        }

        private void exportImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "PixelImage.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CombinedBitmap.Save(saveFileDialog1.FileName);
            }
        }



        // ======================================= BACKGROUND COMBOBOX ======================================

        private void comboBoxBg_SelectedIndexChanged(object sender, EventArgs e)
        {
            BgTablePlainColour.Visible = false;
            listViewBgChoose.Visible = false;

            if (comboBoxBg.SelectedIndex == 0)
            {
                BgTablePlainColour.Visible = true;
            }
            else if (comboBoxBg.SelectedIndex == 1) 
            {
                listViewBgChoose.Visible = true;
            }
        }

        // ======================================= BACKGROUND PLAINCOLOUR ======================================
        private void buttonBgPlainColourChoose_Click(object sender, EventArgs e)
        {
            // Show the color dialog. If the user clicks OK, load the
            // picture that the user chose.
            if (colorDialogBgPlainColour.ShowDialog() == DialogResult.OK)
            {
                // create an image of the desired size
                var bgBitmap = new Bitmap(IMG_WIDTH, IMG_HEIGHT);

                using (var graphics = Graphics.FromImage(bgBitmap))
                {
                    // set background color
                    graphics.Clear(colorDialogBgPlainColour.Color);
                }

                // Updates the plain colour preview box
                pictureBoxBgPlainColourPreview.Image = bgBitmap;

                // Update background layer to new colour
                UpdateLayer(Layers.Background, bgBitmap);
            }
        }

        // ======================================= BACKGROUND PRESETS ======================================
        private void ListviewBgChooseInit()
        {
            // Add the all the premade background images to the imagelist and list of images
            // NOTE: somehow retrieving images from the ImageList only returns a thumbnail sized image so a second
            // list of images is needed to contain the true sized presets.
            addPresetsToLists(BgPresetImgList, BgPresetImgs, Properties.Resources.BgPresetSky);
            addPresetsToLists(BgPresetImgList, BgPresetImgs, Properties.Resources.testImage);

            //set the small and large ImageList properties of listview
            listViewBgChoose.LargeImageList = BgPresetImgList;
            listViewBgChoose.SmallImageList = BgPresetImgList;

            listViewBgChoose.View = View.LargeIcon;
            listViewBgChoose.Items.Add(new ListViewItem() { ImageIndex = 0, Text = "Sky" });
            listViewBgChoose.Items.Add(new ListViewItem() { ImageIndex = 1, Text = "test" });


        }

        private void addPresetsToLists(ImageList imgList, List<Image> list, Image img)
        {
            // Adds an image to an ImageList and to a list of Images
            imgList.Images.Add(img);
            list.Add(img);
        }

        private void listViewBgChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewBgChoose.SelectedIndices.Count == 1)
            {
                // Updates background layer with chosen preset image by retrieving the chosen item index
                // and retrieving the corresponding preset image from the list of preset images of the same index
                var chosenPreset = listViewBgChoose.SelectedIndices[0];
                Image img = BgPresetImgs[chosenPreset];
                Bitmap bm = new Bitmap(img, IMG_WIDTH, IMG_HEIGHT);

                UpdateLayer(Layers.Background, bm);

            }

        }

        // ======================================= BACKGROUND STAR GENERATION ======================================

        private void StarsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // generates white star pixels if checkbox is checked, else clears star layer
            if (StarsCheckBox.Checked)
            {
                GenerateStars();
            }
            else
            {
                Bitmap newStarBitmap = new Bitmap(IMG_WIDTH, IMG_HEIGHT);
                UpdateLayer(Layers.Star, newStarBitmap);
            }
        }

        void GenerateStars()
        {
            // Determine star generation threshold based on trackbar value
            // 1pt is 0.10%. higher value -> lower threshold -> more stars
            StarNoiseThreshold = 1000 - TrackbarBgStars.Value;

            // Loops through all pixels of new empty bitmap
            Random rnumber = new Random();
            Bitmap newStarBitmap = new Bitmap(IMG_WIDTH, IMG_HEIGHT);
            for (int y = 0; y < IMG_HEIGHT; y++)
            {
                for (int x = 0; x < IMG_WIDTH; x++)
                {
                    // Creates a star (white pixel) if randomly generated number exceeds or equals threshold
                    if (rnumber.Next(1000) >= StarNoiseThreshold)
                    {
                        newStarBitmap.SetPixel(x, y, Color.White);
                    }
                }
            }
            UpdateLayer(Layers.Star, newStarBitmap);
        }

        private void UpdateStarDensityLabel()
        {
            // Update label for star density
            double starDensity = TrackbarBgStars.Value * 0.10;
            labelBgStars.Text = "Star density: " + starDensity.ToString() + "%";
        }

        private void TrackbarBgStars_ValueChanged(object sender, EventArgs e)
        {
            // updates label and regenerate stars
            UpdateStarDensityLabel();
            if (StarsCheckBox.Checked)
            {
                GenerateStars();
            }
        }











        private void ShowCombinedLayers()
        {
            // http://csharphelper.com/blog/2016/11/overlay-images-in-c/
            // Combines layers into a single image;
            CombinedBitmap = new Bitmap(IMG_WIDTH, IMG_HEIGHT);

            int zoomfactor = 3;

            // Overlays the images of each layer
            using (Graphics gr = Graphics.FromImage(CombinedBitmap))
            {
                var location = new Point(0, 0);
                foreach (Image layer in LayersList)
                {
                    gr.DrawImage(layer, location);
                }
            }

            // Creates a larger version of the combined bitmap for display
            int zoomedWidth = Convert.ToInt32(IMG_WIDTH * zoomfactor);
            int zoomedHeight = Convert.ToInt32(IMG_HEIGHT * zoomfactor);
            Bitmap zoomedCombinedBitmap = new Bitmap(zoomedWidth, zoomedHeight);

            using (Graphics gpu = Graphics.FromImage(zoomedCombinedBitmap))
            {
                gpu.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                gpu.DrawImage(
                   CombinedBitmap,
                    new Rectangle(0, 0, zoomedWidth, zoomedHeight),
                    // destination rectangle 
                    0,
                    0,           // upper-left corner of source rectangle
                    CombinedBitmap.Width,       // width of source rectangle
                    CombinedBitmap.Height,      // height of source rectangle
                    GraphicsUnit.Pixel);
                    
                // Display the zoomed result.
                pictureBox1.Image = zoomedCombinedBitmap;
            }
        }

        void UpdateLayer(Layers layer, Bitmap bitmap)
        {
            // retrieves the index of the Layers.Background enum in LayersIndeces
            int bgIndex = LayersIndeces.IndexOf(layer);

            // Replaces the image in the layersList to the new bitmap
            LayersList[bgIndex] = bitmap;

            // Updates the image shown in the picture box
            ShowCombinedLayers();
        }

        
    }
}
