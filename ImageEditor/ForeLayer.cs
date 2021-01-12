using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ImageEditor
{
    class ForeLayer
    {
        GroupBox GroupBox;
        FlowLayoutPanel FlowPanel;
        ComboBox ComboBox;
        TableLayoutPanel TablePlainColour;
        ListView ListViewPresets;

        PictureBox PlainColourPreview;
        Button PlainColourButton;

        public ForeLayer(SplitterPanel parentPanel)
        {
            this.GroupBox = new GroupBox();
            this.GroupBox.Text = "Foreground Layer";
            this.GroupBox.Dock = DockStyle.Top;
            this.GroupBox.AutoSize = true;

            this.ComboBox = new ComboBox();
            this.ComboBox.Dock = DockStyle.Top;
            this.ComboBox.Items.Add("Plain colour");
            this.ComboBox.Items.Add("Presets");
            this.ComboBox.SelectedIndexChanged += new EventHandler(this.comboBox_SelectedIndexChanged);

            this.TablePlainColour = new TableLayoutPanel();
            this.TablePlainColour.Dock = DockStyle.Top;
            this.TablePlainColour.ColumnCount = 2;
            this.TablePlainColour.AutoSize = true;

            this.PlainColourButton = new Button();
            // CONTINUE HERE

            this.PlainColourPreview = new PictureBox();
            this.PlainColourPreview.Size = new Size(29, 29);
            this.PlainColourPreview.BorderStyle = BorderStyle.Fixed3D;

            this.ListViewPresets = new ListView();
            this.ListViewPresets.Dock = DockStyle.Top;
            this.ListViewPresets.AutoSize = true;


            parentPanel.Controls.Add(GroupBox);
            this.GroupBox.Controls.Add(this.FlowPanel);
            this.GroupBox.Controls.Add(this.ComboBox);
            this.GroupBox.Controls.Add(this.TablePlainColour);
            this.TablePlainColour.Controls.Add(this.PlainColourPreview);
            this.GroupBox.Controls.Add(this.ListViewPresets);

            this.ComboBox.SelectedIndex = 1;
            this.comboBoxIndexCheck();
        }



        private void comboBoxIndexCheck()
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

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxIndexCheck();
        }

    }
}
