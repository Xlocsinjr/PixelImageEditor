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

        CombinedLayers activeCombinedLayers;
        
        // CONSTRUCTOR
        public Form1()
        {
            InitializeComponent();

            ForeLayer.InitialisePresets();
            ForeLayer.PlainColourDialog = colorDialogPlainColour;

            CombinedLayers CombinedLayers = new CombinedLayers(pictureBox1, splitContainer1.Panel2);
            this.activeCombinedLayers = CombinedLayers;
            ForeLayer BackGround = new ForeLayer(0, "Background layers");
            StarsLayer StarsLayer = new StarsLayer(0, BackGround.GroupBox);
            ForeLayer ForeGround = new ForeLayer(80, "Foreground layer 1");
            ForeLayer ForeGround2 = new ForeLayer(100, "Foreground layer 2");

            // Adds the layers to the list in CombinedLayers
            CombinedLayers.AddLayer(BackGround);
            CombinedLayers.AddLayer(StarsLayer);
            CombinedLayers.AddLayer(ForeGround);
            CombinedLayers.AddLayer(ForeGround2);

            CombinedLayers.ShowCombinedLayers();
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
            // resets all layers to blank of the active CombinedLayers
            this.activeCombinedLayers.ClearLayers();
        }

        private void exportImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "PixelImage.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.activeCombinedLayers.CombinedBitmap.Save(saveFileDialog1.FileName);
            }
        }

        
    }
}
