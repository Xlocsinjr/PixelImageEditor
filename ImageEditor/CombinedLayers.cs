using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    public class CombinedLayers
    {
        public Bitmap CombinedBitmap;
        PictureBox TargetPictureBox;
        public Panel TargetControlsPanel;
        int zoomFactor;

        List<LayerImage> LayerImageList;  // List of Layer objects
        

        public CombinedLayers(PictureBox targetPictureBox, Panel targetControlsPanel)
        {
            this.TargetPictureBox = targetPictureBox;
            this.TargetControlsPanel = targetControlsPanel;

            this.LayerImageList = new List<LayerImage> { };



        }



        public void ShowCombinedLayers()
        {
            // http://csharphelper.com/blog/2016/11/overlay-images-in-c/
            // Combines layers into a single image;
            CombinedBitmap = new Bitmap(Form1.IMG_WIDTH, Form1.IMG_HEIGHT);

            this.zoomFactor = 3;

            // Overlays the images of each layer
            using (Graphics gr = Graphics.FromImage(CombinedBitmap))
            {
                
                foreach (LayerImage layer in LayerImageList)
                {
                    var location = new Point(0, Convert.ToInt32(layer.LayerHeight));
                    gr.DrawImage(layer.LayerBitmap, location);
                }
            }

            // Creates a larger version of the combined bitmap for display
            int zoomedWidth = Convert.ToInt32(Form1.IMG_WIDTH * zoomFactor);
            int zoomedHeight = Convert.ToInt32(Form1.IMG_HEIGHT * zoomFactor);
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
                this.TargetPictureBox.Image = zoomedCombinedBitmap;
            }
        }

        public void AddLayer(LayerImage layer)
        {
            layer.TargetCombinedLayers = this;
            this.LayerImageList.Add(layer);
        }

        public void ClearLayers()
        {
            foreach (LayerImage layer in LayerImageList)
            {
                layer.ClearLayer();
            }
        }

    }
}
