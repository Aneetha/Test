namespace Moive_shop
{
    partial class theater_add_more
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(theater_add_more));
            this.label18 = new System.Windows.Forms.Label();
            this.to_date = new System.Windows.Forms.PictureBox();
            this.calender = new System.Windows.Forms.MonthCalendar();
            this.from_date = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.to_txt = new System.Windows.Forms.TextBox();
            this.from_txt = new System.Windows.Forms.TextBox();
            this.screen_drop = new System.Windows.Forms.ComboBox();
            this.theater_drop = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.timing_panel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.to_date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.from_date)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(7, 116);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 14);
            this.label18.TabIndex = 68;
            this.label18.Text = "Show Timing:";
            // 
            // to_date
            // 
            this.to_date.Image = ((System.Drawing.Image)(resources.GetObject("to_date.Image")));
            this.to_date.Location = new System.Drawing.Point(402, 78);
            this.to_date.Name = "to_date";
            this.to_date.Size = new System.Drawing.Size(28, 29);
            this.to_date.TabIndex = 67;
            this.to_date.TabStop = false;
            this.to_date.Click += new System.EventHandler(this.to_date_Click);
            // 
            // calender
            // 
            this.calender.Location = new System.Drawing.Point(13, 31);
            this.calender.Name = "calender";
            this.calender.TabIndex = 57;
            this.calender.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.calender.Visible = false;
            this.calender.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.calender_DateChanged);
            this.calender.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calender_DateSelected);
            // 
            // from_date
            // 
            this.from_date.Image = ((System.Drawing.Image)(resources.GetObject("from_date.Image")));
            this.from_date.Location = new System.Drawing.Point(209, 78);
            this.from_date.Name = "from_date";
            this.from_date.Size = new System.Drawing.Size(28, 29);
            this.from_date.TabIndex = 57;
            this.from_date.TabStop = false;
            this.from_date.Click += new System.EventHandler(this.from_date_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(54, 85);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(39, 14);
            this.label17.TabIndex = 66;
            this.label17.Text = "From:";
            // 
            // to_txt
            // 
            this.to_txt.Location = new System.Drawing.Point(271, 81);
            this.to_txt.Name = "to_txt";
            this.to_txt.Size = new System.Drawing.Size(100, 20);
            this.to_txt.TabIndex = 65;
            this.to_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.theater_drop_KeyPress);
            // 
            // from_txt
            // 
            this.from_txt.Location = new System.Drawing.Point(103, 79);
            this.from_txt.Name = "from_txt";
            this.from_txt.Size = new System.Drawing.Size(100, 20);
            this.from_txt.TabIndex = 64;
            this.from_txt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.theater_drop_KeyPress);
            // 
            // screen_drop
            // 
            this.screen_drop.FormattingEnabled = true;
            this.screen_drop.Location = new System.Drawing.Point(103, 45);
            this.screen_drop.Name = "screen_drop";
            this.screen_drop.Size = new System.Drawing.Size(174, 21);
            this.screen_drop.TabIndex = 63;
            this.screen_drop.DropDown += new System.EventHandler(this.screen_drop_DropDown);
            this.screen_drop.SelectedIndexChanged += new System.EventHandler(this.screen_drop_SelectedIndexChanged);
            this.screen_drop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.theater_drop_KeyPress);
            // 
            // theater_drop
            // 
            this.theater_drop.FormattingEnabled = true;
            this.theater_drop.Location = new System.Drawing.Point(103, 16);
            this.theater_drop.Name = "theater_drop";
            this.theater_drop.Size = new System.Drawing.Size(174, 21);
            this.theater_drop.TabIndex = 62;
            this.theater_drop.DropDown += new System.EventHandler(this.theater_drop_DropDown);
            this.theater_drop.SelectedIndexChanged += new System.EventHandler(this.theater_drop_SelectedIndexChanged);
            this.theater_drop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.theater_drop_KeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(243, 84);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 14);
            this.label16.TabIndex = 61;
            this.label16.Text = "To:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(14, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 14);
            this.label15.TabIndex = 60;
            this.label15.Text = "Date:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(10, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 14);
            this.label14.TabIndex = 59;
            this.label14.Text = "Screen Name:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(87, 14);
            this.label13.TabIndex = 58;
            this.label13.Text = "Theater Name:";
            // 
            // timing_panel
            // 
            this.timing_panel.AutoScroll = true;
            this.timing_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.timing_panel.Location = new System.Drawing.Point(101, 116);
            this.timing_panel.Name = "timing_panel";
            this.timing_panel.Padding = new System.Windows.Forms.Padding(5);
            this.timing_panel.Size = new System.Drawing.Size(334, 65);
            this.timing_panel.TabIndex = 69;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(352, 204);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(83, 32);
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // theater_add_more
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(227)))), ((int)(((byte)(227)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.calender);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.to_date);
            this.Controls.Add(this.from_date);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.to_txt);
            this.Controls.Add(this.from_txt);
            this.Controls.Add(this.screen_drop);
            this.Controls.Add(this.theater_drop);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.timing_panel);
            this.Name = "theater_add_more";
            this.Size = new System.Drawing.Size(476, 244);
            ((System.ComponentModel.ISupportInitialize)(this.to_date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.from_date)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox to_date;
        private System.Windows.Forms.MonthCalendar calender;
        private System.Windows.Forms.PictureBox from_date;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox to_txt;
        private System.Windows.Forms.TextBox from_txt;
        private System.Windows.Forms.ComboBox screen_drop;
        private System.Windows.Forms.ComboBox theater_drop;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel timing_panel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
