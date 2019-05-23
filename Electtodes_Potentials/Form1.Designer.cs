namespace Electtodes_Potentials
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.input_distance = new System.Windows.Forms.TextBox();
            this.input_electrod_head_radius = new System.Windows.Forms.TextBox();
            this.input_epsilon = new System.Windows.Forms.TextBox();
            this.input_distance_in = new System.Windows.Forms.ComboBox();
            this.input_electrod_head_radius_in = new System.Windows.Forms.ComboBox();
            this.data_dgv = new System.Windows.Forms.DataGridView();
            this.input = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calculate_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.add_btn = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.potentialLab = new System.Windows.Forms.Label();
            this.move_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 199);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 36;
            this.label6.Text = "Расстояние";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 266);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 37;
            this.label2.Text = "Радиус электрода";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 318);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 17);
            this.label4.TabIndex = 39;
            this.label4.Text = "Диэлектрическая проницаемость, ε";
            // 
            // input_distance
            // 
            this.input_distance.Location = new System.Drawing.Point(277, 226);
            this.input_distance.Margin = new System.Windows.Forms.Padding(4);
            this.input_distance.Name = "input_distance";
            this.input_distance.Size = new System.Drawing.Size(132, 22);
            this.input_distance.TabIndex = 40;
            this.input_distance.Leave += new System.EventHandler(this.input_distance_Leave);
            this.input_distance.Validated += new System.EventHandler(this.input_distance_Validated);
            // 
            // input_electrod_head_radius
            // 
            this.input_electrod_head_radius.Location = new System.Drawing.Point(277, 288);
            this.input_electrod_head_radius.Margin = new System.Windows.Forms.Padding(4);
            this.input_electrod_head_radius.Name = "input_electrod_head_radius";
            this.input_electrod_head_radius.Size = new System.Drawing.Size(132, 22);
            this.input_electrod_head_radius.TabIndex = 41;
            this.input_electrod_head_radius.Leave += new System.EventHandler(this.input_electrod_head_radius_Leave);
            // 
            // input_epsilon
            // 
            this.input_epsilon.Location = new System.Drawing.Point(281, 339);
            this.input_epsilon.Margin = new System.Windows.Forms.Padding(4);
            this.input_epsilon.Name = "input_epsilon";
            this.input_epsilon.Size = new System.Drawing.Size(132, 22);
            this.input_epsilon.TabIndex = 43;
            this.input_epsilon.Leave += new System.EventHandler(this.input_epsilon_Leave);
            // 
            // input_distance_in
            // 
            this.input_distance_in.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_distance_in.FormattingEnabled = true;
            this.input_distance_in.Items.AddRange(new object[] {
            "м",
            "см",
            "мм",
            "мкн"});
            this.input_distance_in.Location = new System.Drawing.Point(422, 226);
            this.input_distance_in.Margin = new System.Windows.Forms.Padding(4);
            this.input_distance_in.Name = "input_distance_in";
            this.input_distance_in.Size = new System.Drawing.Size(116, 24);
            this.input_distance_in.TabIndex = 44;
            // 
            // input_electrod_head_radius_in
            // 
            this.input_electrod_head_radius_in.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_electrod_head_radius_in.FormattingEnabled = true;
            this.input_electrod_head_radius_in.Items.AddRange(new object[] {
            "м",
            "см",
            "мм",
            "мкн"});
            this.input_electrod_head_radius_in.Location = new System.Drawing.Point(422, 285);
            this.input_electrod_head_radius_in.Margin = new System.Windows.Forms.Padding(4);
            this.input_electrod_head_radius_in.Name = "input_electrod_head_radius_in";
            this.input_electrod_head_radius_in.Size = new System.Drawing.Size(116, 24);
            this.input_electrod_head_radius_in.TabIndex = 45;
            // 
            // data_dgv
            // 
            this.data_dgv.AllowUserToAddRows = false;
            this.data_dgv.AllowUserToResizeColumns = false;
            this.data_dgv.AllowUserToResizeRows = false;
            this.data_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.input});
            this.data_dgv.Location = new System.Drawing.Point(27, 30);
            this.data_dgv.Margin = new System.Windows.Forms.Padding(4);
            this.data_dgv.Name = "data_dgv";
            this.data_dgv.Size = new System.Drawing.Size(193, 446);
            this.data_dgv.TabIndex = 47;
            this.data_dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_dgv_CellDoubleClick);
            this.data_dgv.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_dgv_CellEndEdit);
            this.data_dgv.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_dgv_CellLeave);
            this.data_dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_dgv_CellValueChanged);
            // 
            // input
            // 
            this.input.HeaderText = "Вход, мВ";
            this.input.Name = "input";
            this.input.ReadOnly = true;
            this.input.Width = 120;
            // 
            // calculate_btn
            // 
            this.calculate_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.calculate_btn.Location = new System.Drawing.Point(281, 389);
            this.calculate_btn.Margin = new System.Windows.Forms.Padding(4);
            this.calculate_btn.Name = "calculate_btn";
            this.calculate_btn.Size = new System.Drawing.Size(257, 58);
            this.calculate_btn.TabIndex = 48;
            this.calculate_btn.Text = "Рассчитать";
            this.calculate_btn.UseVisualStyleBackColor = true;
            this.calculate_btn.Click += new System.EventHandler(this.calculate_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(257, 60);
            this.delete_btn.Margin = new System.Windows.Forms.Padding(4);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(177, 28);
            this.delete_btn.TabIndex = 49;
            this.delete_btn.Text = "Удалить электрод";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // add_btn
            // 
            this.add_btn.Location = new System.Drawing.Point(257, 112);
            this.add_btn.Margin = new System.Windows.Forms.Padding(4);
            this.add_btn.Name = "add_btn";
            this.add_btn.Size = new System.Drawing.Size(177, 28);
            this.add_btn.TabIndex = 50;
            this.add_btn.Text = "Добавить электрод";
            this.add_btn.UseVisualStyleBackColor = true;
            this.add_btn.Click += new System.EventHandler(this.add_btn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pictureBox.Location = new System.Drawing.Point(555, 30);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(600, 400);
            this.pictureBox.TabIndex = 51;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDoubleClick);
            // 
            // potentialLab
            // 
            this.potentialLab.AutoSize = true;
            this.potentialLab.Location = new System.Drawing.Point(36, 564);
            this.potentialLab.Name = "potentialLab";
            this.potentialLab.Size = new System.Drawing.Size(30, 17);
            this.potentialLab.TabIndex = 52;
            this.potentialLab.Text = "U =";
            // 
            // move_btn
            // 
            this.move_btn.Location = new System.Drawing.Point(257, 30);
            this.move_btn.Name = "move_btn";
            this.move_btn.Size = new System.Drawing.Size(177, 23);
            this.move_btn.TabIndex = 54;
            this.move_btn.Text = "Передвинуть электрод";
            this.move_btn.UseVisualStyleBackColor = true;
            this.move_btn.Click += new System.EventHandler(this.move_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 596);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.move_btn);
            this.Controls.Add(this.potentialLab);
            this.Controls.Add(this.add_btn);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.calculate_btn);
            this.Controls.Add(this.data_dgv);
            this.Controls.Add(this.input_electrod_head_radius_in);
            this.Controls.Add(this.input_distance_in);
            this.Controls.Add(this.input_epsilon);
            this.Controls.Add(this.input_electrod_head_radius);
            this.Controls.Add(this.input_distance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.data_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox input_distance;
        private System.Windows.Forms.TextBox input_electrod_head_radius;
        private System.Windows.Forms.TextBox input_epsilon;
        private System.Windows.Forms.ComboBox input_distance_in;
        private System.Windows.Forms.ComboBox input_electrod_head_radius_in;
        private System.Windows.Forms.DataGridView data_dgv;
        private System.Windows.Forms.Button calculate_btn;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Button add_btn;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label potentialLab;
        private System.Windows.Forms.Button move_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn input;
    }
}

