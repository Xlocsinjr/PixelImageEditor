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

        ImageList BgPresetImgs = new ImageList();

        // The current combined image.
        private Bitmap CombinedBitmap = null;

        // Declare layer images list
        private List<Image> LayersList = new List<Image> { };

        public enum Layers
        {
            Background,
            Star,
        }

        // Declare list of the enums so the indeces can later be retrieved
        List<Layers> LayersIndeces = new List<Layers> {};



        public Form1()
        {
            InitializeComponent();
            ListviewBgChooseInit();
            NewImage();

            // Open on Plain colour on the combobox for the background layers
            comboBoxBg.SelectedIndex = 0;

            // Initialises the LayersIndeces to contain the enums so the indeces can later be retrieved
            // Also initialises the layerslist with empty transparent images
            foreach (Layers layer in (Layers[])Enum.GetValues(typeof(Layers)))
            {
                LayersIndeces.Add(layer);

                var newBitmap = new Bitmap(IMG_WIDTH, IMG_HEIGHT);
                newBitmap.MakeTransparent(Color.White);
                LayersList.Add(newBitmap);
            }


            //pictureBox1.Image = Image.FromFile(@"..\..\SourceImages\testImage.png");

        }

        private void ListviewBgChooseInit()
        {
            // https://stackoverflow.com/questions/17151776/c-sharp-listview-adding-item-with-image-and-text-and-align-the-text-to-left
            //retrieve all image files
            String[] ImageFiles = Directory.GetFiles(@".\SourceImages\");
            foreach (var file in ImageFiles)
            {
                //Add images to Imagelist
                BgPresetImgs.Images.Add(Image.FromFile(file));
            }

            pictureBox1.Image = Image.FromFile(@"..\..\SourceImages\testImage.png");

            //set the amall and large ImageList properties of listview
            listViewBgChoose.LargeImageList = BgPresetImgs;
            listViewBgChoose.SmallImageList = BgPresetImgs;

            listViewBgChoose.View = View.LargeIcon;
            listViewBgChoose.Items.Add(new ListViewItem() { ImageIndex = 0 , Text="test"});

            
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
            // create an image of the desired size
            var bitmap = new Bitmap(IMG_WIDTH, IMG_HEIGHT);

            using (var graphics = Graphics.FromImage(bitmap))
            {
                // specify the desired quality of the render and text, if you wish
                //graphics.CompositingQuality = CompositingQuality.HighQuality;
                //graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
                // From: https://stackoverflow.com/questions/61513832/how-to-edit-image-in-c-sharp;

                // set background color
                graphics.Clear(Color.Black);
            }

            pictureBox1.Image = bitmap;
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

                // retrieves the index of the Layers.Background enum in LayersIndeces
                int bgIndex = LayersIndeces.IndexOf(Layers.Background);

                // Replaces the background image in the layersList to the new background
                LayersList[bgIndex] = bgBitmap;

                // Updates the image shown in the picture box
                ShowCombinedLayers();
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

        private void ShowCombinedLayers()
        {
            // http://csharphelper.com/blog/2016/11/overlay-images-in-c/
            // Combines layers into a single image;
            Bitmap CombinedBitmap = new Bitmap(IMG_WIDTH, IMG_HEIGHT);

            // Overlays the images of each layer
            using (Graphics gr = Graphics.FromImage(CombinedBitmap))
            {
                var location = new Point(0, 0);
                foreach (Image layer in LayersList)
                {
                    gr.DrawImage(layer, location);
                }
                
            }

            // Display the result.
            pictureBox1.Image = CombinedBitmap;
        }
    }
}
