namespace Moive_shop
{
    partial class add_timing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(add_timing));
            this.am_pm = new System.Windows.Forms.ComboBox();
            this.mins = new System.Windows.Forms.ComboBox();
            this.hours = new System.Windows.Forms.ComboBox();
            this.delete_timing = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.delete_timing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // am_pm
            // 
            this.am_pm.FormattingEnabled = true;
            this.am_pm.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.am_pm.Location = new System.Drawing.Point(119, 3);
            this.am_pm.Name = "am_pm";
            this.am_pm.Size = new System.Drawing.Size(51, 21);
            this.am_pm.TabIndex = 54;
            // 
            // mins
            // 
            this.mins.FormattingEnabled = true;
            this.mins.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60"});
            this.mins.Location = new System.Drawing.Point(60, 4);
            this.mins.Name = "mins";
            this.mins.Size = new System.Drawing.Size(53, 21);
            this.mins.TabIndex = 53;
            // 
            // hours
            // 
            this.hours.FormattingEnabled = true;
            this.hours.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.hours.Location = new System.Drawing.Point(3, 3);
            this.hours.Name = "hours";
            this.hours.Size = new System.Drawing.Size(51, 21);
            this.hours.TabIndex = 52;
            // 
            // delete_timing
            // 
            this.delete_timing.Image = ((System.Drawing.Image)(resources.GetObject("delete_timing.Image")));
            this.delete_timing.Location = new System.Drawing.Point(226, 3);
            this.delete_timing.Name = "delete_timing";
            this.delete_timing.Size = new System.Drawing.Size(19, 18);
            this.delete_timing.TabIndex = 51;
            this.delete_timing.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(201, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(19, 18);
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // add_timing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.am_pm);
            this.Controls.Add(this.mins);
            this.Controls.Add(this.hours);
            this.Controls.Add(this.delete_timing);
            this.Controls.Add(this.pictureBox1);
            this.Name = "add_timing";
            this.Size = new System.Drawing.Size(248, 26);
            ((System.ComponentModel.ISupportInitialize)(this.delete_timing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox am_pm;
        private System.Windows.Forms.ComboBox mins;
        private System.Windows.Forms.ComboBox hours;
        private System.Windows.Forms.PictureBox delete_timing;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
