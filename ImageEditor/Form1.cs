﻿using System;
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

        ImageList BgPresetImgs = new ImageList(); // for the listview
        List<Image> BgPresets = new List<Image> { };

        Bitmap CombinedBitmap;

        // Declare layer images list
        private List<Bitmap> LayersList; 

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
            NewImage();
            //pictureBox1.Image = Image.FromFile(@"..\..\SourceImages\testImage.png");

        }

        

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
                // create an image of the desired size
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

            // Update background layer to black
            UpdateLayer(Layers.Background, bgBitmap);


            // Turns off any additional options
            StarsCheckBox.Checked = false;
        }

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

        // ======================================= BACKGROUND PRESETS ======================================
        private void ListviewBgChooseInit()
        {
            //Add images to Imagelist
            BgPresetImgs.Images.Add(Properties.Resources.BgPresetSky);
            BgPresetImgs.Images.Add(Properties.Resources.testImage);

            //set the small and large ImageList properties of listview
            listViewBgChoose.LargeImageList = BgPresetImgs;
            listViewBgChoose.SmallImageList = BgPresetImgs;

            listViewBgChoose.View = View.LargeIcon;
            listViewBgChoose.Items.Add(new ListViewItem() { ImageIndex = 0, Text = "Sky" });
            listViewBgChoose.Items.Add(new ListViewItem() { ImageIndex = 1, Text = "test" });


        }

        private void listViewBgChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewBgChoose.SelectedIndices.Count == 1)
            {
                // listViewBgChoose.SelectedIndices[0]
                Image chosenPreset = BgPresetImgs.Images[0];
                Bitmap bm = new Bitmap(IMG_WIDTH, IMG_HEIGHT);

                using (Graphics gr = Graphics.FromImage(bm))
                {
                    Point location = new Point(0, 0);
                    gr.DrawImage(chosenPreset, location);

                }

                UpdateLayer(Layers.Background, bm);

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
            StarNoiseThreshold = 990;
            Random rnumber = new Random();

            Bitmap newStarBitmap = new Bitmap(IMG_WIDTH, IMG_HEIGHT);
            for (int y = 0; y < IMG_HEIGHT; y++)
            {
                for (int x = 0; x < IMG_WIDTH; x++)
                {
                    if (rnumber.Next(1000) > StarNoiseThreshold)
                    {
                        newStarBitmap.SetPixel(x, y, Color.White);
                    }
                }
            }
            UpdateLayer(Layers.Star, newStarBitmap);
        }

        
    }
}
