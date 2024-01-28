namespace GameOfLife;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        speedSlider = new TrackBar();
        buttonPlay = new Button();
        buttonStep = new Button();
        canvas = new PictureBox();
        delayLabel1 = new Label();
        delayLabel2 = new Label();
        xDim = new NumericUpDown();
        yDim = new NumericUpDown();
        label1 = new Label();
        ((System.ComponentModel.ISupportInitialize)speedSlider).BeginInit();
        ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
        ((System.ComponentModel.ISupportInitialize)xDim).BeginInit();
        ((System.ComponentModel.ISupportInitialize)yDim).BeginInit();
        SuspendLayout();
        // 
        // speedSlider
        // 
        speedSlider.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        speedSlider.LargeChange = 20;
        speedSlider.Location = new Point(751, 12);
        speedSlider.Maximum = 500;
        speedSlider.Minimum = 1;
        speedSlider.Name = "speedSlider";
        speedSlider.Orientation = Orientation.Vertical;
        speedSlider.RightToLeft = RightToLeft.Yes;
        speedSlider.RightToLeftLayout = true;
        speedSlider.Size = new Size(45, 138);
        speedSlider.TabIndex = 0;
        speedSlider.TickFrequency = 10;
        speedSlider.Value = 1;
        speedSlider.Scroll += SpeedChanged;
        // 
        // buttonPlay
        // 
        buttonPlay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        buttonPlay.Location = new Point(735, 156);
        buttonPlay.Name = "buttonPlay";
        buttonPlay.Size = new Size(61, 34);
        buttonPlay.TabIndex = 1;
        buttonPlay.Text = "Play";
        buttonPlay.UseVisualStyleBackColor = true;
        buttonPlay.Click += OnPlay;
        // 
        // buttonStep
        // 
        buttonStep.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        buttonStep.Location = new Point(735, 196);
        buttonStep.Name = "buttonStep";
        buttonStep.Size = new Size(61, 34);
        buttonStep.TabIndex = 2;
        buttonStep.Text = "Step";
        buttonStep.UseVisualStyleBackColor = true;
        buttonStep.Click += OnStep;
        // 
        // canvas
        // 
        canvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        canvas.BackColor = Color.Transparent;
        canvas.BackgroundImageLayout = ImageLayout.Center;
        canvas.Cursor = Cursors.Cross;
        canvas.Location = new Point(12, 12);
        canvas.Name = "canvas";
        canvas.Size = new Size(717, 472);
        canvas.TabIndex = 3;
        canvas.TabStop = false;
        // 
        // delayLabel1
        // 
        delayLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        delayLabel1.AutoSize = true;
        delayLabel1.Location = new Point(735, 126);
        delayLabel1.Name = "delayLabel1";
        delayLabel1.Size = new Size(32, 15);
        delayLabel1.TabIndex = 4;
        delayLabel1.Text = "Slow";
        // 
        // delayLabel2
        // 
        delayLabel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        delayLabel2.AutoSize = true;
        delayLabel2.Location = new Point(735, 12);
        delayLabel2.Name = "delayLabel2";
        delayLabel2.Size = new Size(28, 15);
        delayLabel2.TabIndex = 5;
        delayLabel2.Text = "Fast";
        // 
        // xDim
        // 
        xDim.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        xDim.Location = new Point(735, 236);
        xDim.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        xDim.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
        xDim.Name = "xDim";
        xDim.Size = new Size(61, 23);
        xDim.TabIndex = 6;
        xDim.Value = new decimal(new int[] { 10, 0, 0, 0 });
        xDim.ValueChanged += DimensionsChanged;
        // 
        // yDim
        // 
        yDim.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        yDim.Location = new Point(735, 280);
        yDim.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        yDim.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
        yDim.Name = "yDim";
        yDim.Size = new Size(61, 23);
        yDim.TabIndex = 7;
        yDim.Value = new decimal(new int[] { 10, 0, 0, 0 });
        yDim.ValueChanged += DimensionsChanged;
        // 
        // label1
        // 
        label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        label1.AutoSize = true;
        label1.Location = new Point(751, 262);
        label1.Name = "label1";
        label1.Size = new Size(20, 15);
        label1.TabIndex = 8;
        label1.Text = "by";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(808, 496);
        Controls.Add(label1);
        Controls.Add(yDim);
        Controls.Add(xDim);
        Controls.Add(delayLabel2);
        Controls.Add(delayLabel1);
        Controls.Add(canvas);
        Controls.Add(buttonStep);
        Controls.Add(buttonPlay);
        Controls.Add(speedSlider);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Conways Game of Life";
        SizeChanged += MainForm_SizeChanged;
        ((System.ComponentModel.ISupportInitialize)speedSlider).EndInit();
        ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
        ((System.ComponentModel.ISupportInitialize)xDim).EndInit();
        ((System.ComponentModel.ISupportInitialize)yDim).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TrackBar speedSlider;
    private Button buttonPlay;
    private Button buttonStep;
    private PictureBox canvas;
    private Label delayLabel1;
    private Label delayLabel2;
    private NumericUpDown xDim;
    private NumericUpDown yDim;
    private Label label1;
}
