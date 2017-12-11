namespace Carsharing
{
    partial class CarView
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
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.carListBox = new System.Windows.Forms.ListBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.powerTextBox = new System.Windows.Forms.TextBox();
            this.fuelTextBox = new System.Windows.Forms.TextBox();
            this.gearboxTextBox = new System.Windows.Forms.TextBox();
            this.classTextBox = new System.Windows.Forms.TextBox();
            this.trunksizeTextBox = new System.Windows.Forms.TextBox();
            this.seatsTextBox = new System.Windows.Forms.TextBox();
            this.makeTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.fuelLabel = new System.Windows.Forms.Label();
            this.gearboxLabel = new System.Windows.Forms.Label();
            this.classLabel = new System.Windows.Forms.Label();
            this.trunksizeLabel = new System.Windows.Forms.Label();
            this.seatsLabel = new System.Windows.Forms.Label();
            this.powerLabel = new System.Windows.Forms.Label();
            this.makeLabel = new System.Windows.Forms.Label();
            this.couplingLabel = new System.Windows.Forms.Label();
            this.streetTextBox = new System.Windows.Forms.TextBox();
            this.streetLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.postcodeLabel = new System.Windows.Forms.Label();
            this.couplingTextBox = new System.Windows.Forms.TextBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.postcodeTextBox = new System.Windows.Forms.TextBox();
            this.reserveButton = new System.Windows.Forms.Button();
            this.blockButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.addCarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(12, 12);
            this.searchTextBox.MaxLength = 20;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(141, 20);
            this.searchTextBox.TabIndex = 0;
            this.searchTextBox.TabStop = false;
            this.searchTextBox.TextChanged += new System.EventHandler(this.SearchTextBoxTextChanged);
            // 
            // carListBox
            // 
            this.carListBox.DisplayMember = "Name";
            this.carListBox.FormattingEnabled = true;
            this.carListBox.Location = new System.Drawing.Point(12, 38);
            this.carListBox.Name = "carListBox";
            this.carListBox.Size = new System.Drawing.Size(141, 303);
            this.carListBox.Sorted = true;
            this.carListBox.TabIndex = 0;
            this.carListBox.TabStop = false;
            this.carListBox.SelectedValueChanged += new System.EventHandler(this.CarListBoxSelectedValueChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(191, 31);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(139, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // powerTextBox
            // 
            this.powerTextBox.Location = new System.Drawing.Point(191, 109);
            this.powerTextBox.Name = "powerTextBox";
            this.powerTextBox.Size = new System.Drawing.Size(139, 20);
            this.powerTextBox.TabIndex = 3;
            // 
            // fuelTextBox
            // 
            this.fuelTextBox.Location = new System.Drawing.Point(349, 70);
            this.fuelTextBox.Name = "fuelTextBox";
            this.fuelTextBox.Size = new System.Drawing.Size(139, 20);
            this.fuelTextBox.TabIndex = 8;
            // 
            // gearboxTextBox
            // 
            this.gearboxTextBox.Location = new System.Drawing.Point(349, 31);
            this.gearboxTextBox.Name = "gearboxTextBox";
            this.gearboxTextBox.Size = new System.Drawing.Size(139, 20);
            this.gearboxTextBox.TabIndex = 7;
            // 
            // classTextBox
            // 
            this.classTextBox.Location = new System.Drawing.Point(191, 226);
            this.classTextBox.Name = "classTextBox";
            this.classTextBox.Size = new System.Drawing.Size(139, 20);
            this.classTextBox.TabIndex = 6;
            // 
            // trunksizeTextBox
            // 
            this.trunksizeTextBox.Location = new System.Drawing.Point(191, 187);
            this.trunksizeTextBox.Name = "trunksizeTextBox";
            this.trunksizeTextBox.Size = new System.Drawing.Size(139, 20);
            this.trunksizeTextBox.TabIndex = 5;
            // 
            // seatsTextBox
            // 
            this.seatsTextBox.Location = new System.Drawing.Point(191, 148);
            this.seatsTextBox.Name = "seatsTextBox";
            this.seatsTextBox.Size = new System.Drawing.Size(139, 20);
            this.seatsTextBox.TabIndex = 4;
            // 
            // makeTextBox
            // 
            this.makeTextBox.Location = new System.Drawing.Point(191, 70);
            this.makeTextBox.Name = "makeTextBox";
            this.makeTextBox.Size = new System.Drawing.Size(139, 20);
            this.makeTextBox.TabIndex = 2;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(188, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name";
            // 
            // fuelLabel
            // 
            this.fuelLabel.AutoSize = true;
            this.fuelLabel.Location = new System.Drawing.Point(346, 54);
            this.fuelLabel.Name = "fuelLabel";
            this.fuelLabel.Size = new System.Drawing.Size(51, 13);
            this.fuelLabel.TabIndex = 0;
            this.fuelLabel.Text = "Treibstoff";
            // 
            // gearboxLabel
            // 
            this.gearboxLabel.AutoSize = true;
            this.gearboxLabel.Location = new System.Drawing.Point(346, 15);
            this.gearboxLabel.Name = "gearboxLabel";
            this.gearboxLabel.Size = new System.Drawing.Size(59, 13);
            this.gearboxLabel.TabIndex = 0;
            this.gearboxLabel.Text = "Getriebeart";
            // 
            // classLabel
            // 
            this.classLabel.AutoSize = true;
            this.classLabel.Location = new System.Drawing.Point(188, 210);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(38, 13);
            this.classLabel.TabIndex = 0;
            this.classLabel.Text = "Klasse";
            // 
            // trunksizeLabel
            // 
            this.trunksizeLabel.AutoSize = true;
            this.trunksizeLabel.Location = new System.Drawing.Point(188, 171);
            this.trunksizeLabel.Name = "trunksizeLabel";
            this.trunksizeLabel.Size = new System.Drawing.Size(85, 13);
            this.trunksizeLabel.TabIndex = 0;
            this.trunksizeLabel.Text = "Kofferraumgröße";
            // 
            // seatsLabel
            // 
            this.seatsLabel.AutoSize = true;
            this.seatsLabel.Location = new System.Drawing.Point(188, 132);
            this.seatsLabel.Name = "seatsLabel";
            this.seatsLabel.Size = new System.Drawing.Size(52, 13);
            this.seatsLabel.TabIndex = 0;
            this.seatsLabel.Text = "Sitzplätze";
            // 
            // powerLabel
            // 
            this.powerLabel.AutoSize = true;
            this.powerLabel.Location = new System.Drawing.Point(188, 93);
            this.powerLabel.Name = "powerLabel";
            this.powerLabel.Size = new System.Drawing.Size(47, 13);
            this.powerLabel.TabIndex = 0;
            this.powerLabel.Text = "Leistung";
            // 
            // makeLabel
            // 
            this.makeLabel.AutoSize = true;
            this.makeLabel.Location = new System.Drawing.Point(188, 54);
            this.makeLabel.Name = "makeLabel";
            this.makeLabel.Size = new System.Drawing.Size(37, 13);
            this.makeLabel.TabIndex = 0;
            this.makeLabel.Text = "Marke";
            // 
            // couplingLabel
            // 
            this.couplingLabel.AutoSize = true;
            this.couplingLabel.Location = new System.Drawing.Point(346, 93);
            this.couplingLabel.Name = "couplingLabel";
            this.couplingLabel.Size = new System.Drawing.Size(97, 13);
            this.couplingLabel.TabIndex = 0;
            this.couplingLabel.Text = "Anhängerkupplung";
            // 
            // streetTextBox
            // 
            this.streetTextBox.Location = new System.Drawing.Point(349, 226);
            this.streetTextBox.Name = "streetTextBox";
            this.streetTextBox.Size = new System.Drawing.Size(139, 20);
            this.streetTextBox.TabIndex = 12;
            // 
            // streetLabel
            // 
            this.streetLabel.AutoSize = true;
            this.streetLabel.Location = new System.Drawing.Point(346, 210);
            this.streetLabel.Name = "streetLabel";
            this.streetLabel.Size = new System.Drawing.Size(38, 13);
            this.streetLabel.TabIndex = 0;
            this.streetLabel.Text = "Straße";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(346, 171);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(32, 13);
            this.cityLabel.TabIndex = 0;
            this.cityLabel.Text = "Stadt";
            // 
            // postcodeLabel
            // 
            this.postcodeLabel.AutoSize = true;
            this.postcodeLabel.Location = new System.Drawing.Point(346, 132);
            this.postcodeLabel.Name = "postcodeLabel";
            this.postcodeLabel.Size = new System.Drawing.Size(60, 13);
            this.postcodeLabel.TabIndex = 0;
            this.postcodeLabel.Text = "Postleitzahl";
            // 
            // couplingTextBox
            // 
            this.couplingTextBox.Location = new System.Drawing.Point(349, 109);
            this.couplingTextBox.Name = "couplingTextBox";
            this.couplingTextBox.Size = new System.Drawing.Size(139, 20);
            this.couplingTextBox.TabIndex = 9;
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(349, 187);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(139, 20);
            this.cityTextBox.TabIndex = 11;
            // 
            // postcodeTextBox
            // 
            this.postcodeTextBox.Location = new System.Drawing.Point(349, 148);
            this.postcodeTextBox.Name = "postcodeTextBox";
            this.postcodeTextBox.Size = new System.Drawing.Size(139, 20);
            this.postcodeTextBox.TabIndex = 10;
            // 
            // reserveButton
            // 
            this.reserveButton.Location = new System.Drawing.Point(191, 274);
            this.reserveButton.Name = "reserveButton";
            this.reserveButton.Size = new System.Drawing.Size(139, 23);
            this.reserveButton.TabIndex = 13;
            this.reserveButton.Text = "Für 2 Stunden reservieren";
            this.reserveButton.UseVisualStyleBackColor = true;
            this.reserveButton.Click += new System.EventHandler(this.ReserveButtonClick);
            // 
            // blockButton
            // 
            this.blockButton.Location = new System.Drawing.Point(349, 274);
            this.blockButton.Name = "blockButton";
            this.blockButton.Size = new System.Drawing.Size(139, 23);
            this.blockButton.TabIndex = 14;
            this.blockButton.Text = "Ausleihen";
            this.blockButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(191, 318);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(139, 23);
            this.saveButton.TabIndex = 15;
            this.saveButton.Text = "Änderungen speichern";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // addCarButton
            // 
            this.addCarButton.Location = new System.Drawing.Point(349, 318);
            this.addCarButton.Name = "addCarButton";
            this.addCarButton.Size = new System.Drawing.Size(139, 23);
            this.addCarButton.TabIndex = 16;
            this.addCarButton.Text = "Auto hinzufügen";
            this.addCarButton.UseVisualStyleBackColor = true;
            this.addCarButton.Click += new System.EventHandler(this.AddCarButtonClick);
            // 
            // CarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 358);
            this.Controls.Add(this.addCarButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.blockButton);
            this.Controls.Add(this.reserveButton);
            this.Controls.Add(this.postcodeTextBox);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.couplingTextBox);
            this.Controls.Add(this.postcodeLabel);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.streetLabel);
            this.Controls.Add(this.streetTextBox);
            this.Controls.Add(this.couplingLabel);
            this.Controls.Add(this.makeLabel);
            this.Controls.Add(this.powerLabel);
            this.Controls.Add(this.seatsLabel);
            this.Controls.Add(this.trunksizeLabel);
            this.Controls.Add(this.classLabel);
            this.Controls.Add(this.gearboxLabel);
            this.Controls.Add(this.fuelLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.makeTextBox);
            this.Controls.Add(this.seatsTextBox);
            this.Controls.Add(this.trunksizeTextBox);
            this.Controls.Add(this.classTextBox);
            this.Controls.Add(this.gearboxTextBox);
            this.Controls.Add(this.fuelTextBox);
            this.Controls.Add(this.powerTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.carListBox);
            this.Controls.Add(this.searchTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CarView";
            this.Text = "Rocket";
            this.Shown += new System.EventHandler(this.CarViewShown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.ListBox carListBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox powerTextBox;
        private System.Windows.Forms.TextBox fuelTextBox;
        private System.Windows.Forms.TextBox gearboxTextBox;
        private System.Windows.Forms.TextBox classTextBox;
        private System.Windows.Forms.TextBox trunksizeTextBox;
        private System.Windows.Forms.TextBox seatsTextBox;
        private System.Windows.Forms.TextBox makeTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label fuelLabel;
        private System.Windows.Forms.Label gearboxLabel;
        private System.Windows.Forms.Label classLabel;
        private System.Windows.Forms.Label trunksizeLabel;
        private System.Windows.Forms.Label seatsLabel;
        private System.Windows.Forms.Label powerLabel;
        private System.Windows.Forms.Label makeLabel;
        private System.Windows.Forms.Label couplingLabel;
        private System.Windows.Forms.TextBox streetTextBox;
        private System.Windows.Forms.Label streetLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label postcodeLabel;
        private System.Windows.Forms.TextBox couplingTextBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.TextBox postcodeTextBox;
        private System.Windows.Forms.Button reserveButton;
        private System.Windows.Forms.Button blockButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button addCarButton;
    }
}