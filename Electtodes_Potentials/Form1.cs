using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using AForge.Video.DirectShow;
using AForge.Video;

namespace Electtodes_Potentials
{
    public partial class Form1 : Form
    {
        double input_distance_old =5;
        double input_electrod_head_radius_old = 4;
        double input_epsilon_old = 1.2;
        int width;
        int height;
        double width_distance = 0.3;
        double height_distance = 0.3;
        bool add_electrod = false;
        bool move_electrod = false;
        Work w;
        int select_electrod_index = -1;
        
        VideoCaptureDevice videoSource;

        public Form1()
        {
            InitializeComponent();

            VideoCaptureDeviceForm vcdForm = new VideoCaptureDeviceForm();
            if (vcdForm.ShowDialog() == DialogResult.OK)
            {
                videoSource = vcdForm.VideoDevice;
                width = vcdForm.CaptureSize.Width;
                height = vcdForm.CaptureSize.Height;
            }
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.Start();

            //Bitmap btm = new Bitmap("Z://Desktop//солнце.png");
            //pictureBox.Image = btm;
 
            Cursor = Cursors.Arrow;
            input_distance.Text = input_distance_old.ToString();
            input_distance_in.SelectedIndex = 2;

            input_electrod_head_radius.Text = input_electrod_head_radius_old.ToString();
            input_electrod_head_radius_in.SelectedIndex = 2;

            input_epsilon.Text = input_epsilon_old.ToString();

            delete_btn.Enabled = false;
            move_btn.Enabled = false;

            //pictureBox.Width = width;
            //pictureBox.Height = height;

            w = new Work(500, 500, width_distance, height_distance);
            //w.Image = btm;
            Calculate();
        }

        private void Calculate()
        {
            double distance = input_distance_old * (input_distance_in.SelectedIndex == 0 ? 1 :
                input_distance_in.SelectedIndex == 1 ? 0.01 :
                input_distance_in.SelectedIndex == 2 ? 0.001 : 0.000001);

            double head_radius = input_electrod_head_radius_old * (input_electrod_head_radius_in.SelectedIndex == 0 ? 1 :
                input_electrod_head_radius_in.SelectedIndex == 1 ? 0.01 :
                input_electrod_head_radius_in.SelectedIndex == 2 ? 0.001 : 0.000001);
            double epsilon = input_epsilon_old;

            w.Distance = distance;
            w.HeadRadius = head_radius;
            w.Epsilon = epsilon;

            draw();
            CleanUpElectrod();
        }

        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //CleanUpElectrod();
            int i = w.FindElectrod(e.X, e.Y);
            SelectElectrod(i);
        }

        private void SelectElectrod(int i)
        {
            if (i != -1)
            {
                CleanUpElectrod();
                pictureBox.Image = w.DrawSelectedElectrod(i);
                data_dgv.Rows[i].Selected = true;
                add_btn.Enabled = false;
                delete_btn.Enabled = true;
                move_btn.Enabled = true;
                select_electrod_index = i;
            }
        }

        private void CleanUpElectrod()
        {
            delete_btn.Enabled = false;
            move_btn.Enabled = false;
            add_btn.Enabled = true;
            add_electrod = false;
            move_electrod = false;
            if (select_electrod_index >=0 && select_electrod_index < data_dgv.Rows.Count)
            {
                data_dgv.Rows[select_electrod_index].Selected = false;
                select_electrod_index = -1;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            CleanUpElectrod();
            draw();
        }

        private void move_btn_Click(object sender, EventArgs e)
        {
            move_electrod = true;
            move_btn.Enabled = false;
            add_btn.Enabled = false;
            delete_btn.Enabled = false;
        }

        private void calculate_btn_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            w.DeleteElectrod(select_electrod_index);
            data_dgv.Rows.RemoveAt(select_electrod_index);
            CleanUpElectrod();
            draw();
            Calculate();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            CleanUpElectrod();
            add_electrod = true;
            add_btn.Enabled = false;
            delete_btn.Enabled = true;
            move_btn.Enabled = true;
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (add_electrod)
            {
                double voltage = 0;
                w.AddElectrod(e.X, e.Y, voltage);
                data_dgv.Rows.Add();
                data_dgv[0, data_dgv.RowCount - 1].Value = voltage;
                data_dgv.CurrentCell.Selected = false;
                Calculate();
            }
            else if (move_electrod)
            {
                w.MoveElectrod(select_electrod_index, e.X, e.Y);
                CleanUpElectrod();
                Calculate();
            }
            else
            {
                double val = w.GetVoltageAt(e.X, e.Y);
                potentialLab.Text = "U = " + Math.Round(val, 5) + " в точке (" + e.X + "," + e.Y +")";
            }
        }

        private void data_dgv_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
                return;

            double val = 0;
            //todo
            if (!double.TryParse(data_dgv[0, e.RowIndex].Value.ToString(), out val))
            {
                data_dgv[0, e.RowIndex].Value = 0;
                MessageBox.Show("Не верное входное значение на строке " + e.RowIndex);
                return;
            }
        }

        private void input_electrod_head_radius_Leave(object sender, EventArgs e)
        {
            double k;
            if (!double.TryParse(input_electrod_head_radius.Text, out k))
            {
                input_electrod_head_radius.Text = input_electrod_head_radius_old.ToString();
            }
            else
            {
                if (k > 0)
                {
                    input_electrod_head_radius_old = k;
                }
                else
                {
                    input_electrod_head_radius.Text = input_electrod_head_radius_old.ToString();
                }
            }
        }
        
        private void input_epsilon_Leave(object sender, EventArgs e)
        {
            double k;
            if (!double.TryParse(input_epsilon.Text, out k))
            {
                input_epsilon.Text = input_epsilon_old.ToString();
            }
            else
            {
                if (k >= 1)
                {
                    input_epsilon_old = k;
                }
                else
                {
                    input_epsilon.Text = input_epsilon_old.ToString();
                }
            }
        }

        private void input_distance_Leave(object sender, EventArgs e)
        {
            double k;
            if (!double.TryParse(input_distance.Text, out k))
            {
                input_distance.Text = input_distance_old.ToString();
            }
            else
            {
                if (k > 0)
                {
                    input_distance_old = k;
                }
                else
                {
                    input_distance.Text = input_distance_old.ToString();
                }
            }
        }

        private void data_dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            data_dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
            SelectElectrod(e.RowIndex);
        }

        private void data_dgv_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            data_dgv[e.ColumnIndex, e.RowIndex].ReadOnly = true;
        }

        private void data_dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            data_dgv[e.ColumnIndex, e.RowIndex].ReadOnly = true;
        }

        private void data_dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 1)
                    return;

                double val = 0;
                //todo
                if (!double.TryParse(data_dgv[0, e.RowIndex].Value.ToString(), out val))
                {
                    data_dgv[0, e.RowIndex].Value = 0;
                    MessageBox.Show("Не верное входное значение на строке " + e.RowIndex);
                    return;
                }
                w.ChangeVoltageAtElectrodByIndex(e.RowIndex, val);
                Calculate();
            }
            
        }

        private void input_distance_Validated(object sender, EventArgs e)
        {
            double k;
            if (!double.TryParse(input_distance.Text, out k))
            {
                input_distance.Text = input_distance_old.ToString();
            }
            else
            {
                if (k > 0)
                {
                    input_distance_old = k;
                }
                else
                {
                    input_distance.Text = input_distance_old.ToString();
                }
            }
        }

        object l = new object();
        void draw()
        {
            lock (l)
            {
                try {
                    pictureBox.Image = w.Draw();
                }
                catch
                {
                    return;
                }
            }
        }
        
        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox.Image = (Bitmap)eventArgs.Frame.Clone();
            w.Image = (Bitmap)eventArgs.Frame.Clone();
            draw();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!(videoSource == null))
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
        }


        /*private void camera_btn_Click(object sender, EventArgs e)
        {
            VideoCaptureDeviceForm vcdForm = new VideoCaptureDeviceForm();
            if (vcdForm.ShowDialog() == DialogResult.OK)
            {
                videoSource = vcdForm.VideoDevice;
            }

            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.Start();
        }*/

    }
}
