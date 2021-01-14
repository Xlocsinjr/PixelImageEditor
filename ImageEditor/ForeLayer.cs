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
        

        public ForeLayer(int layerHeight, SplitterPanel parentPanel, CombinedLayers targetCombinedLayers, ColorDialog colorDialog) : 
            base(layerHeight, parentPanel, targetCombinedLayers, colorDialog)
        {
            Label testLabel = new Label();
            testLabel.Text = "test test test. THIS IS A FOREGROUND LAYER";
            testLabel.Dock = DockStyle.Top;

            this.GroupBox.Controls.Add(testLabel);
        }



        
    }
}
