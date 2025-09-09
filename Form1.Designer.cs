namespace SyncDemo;

partial class Form1
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
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(400, 225);
        this.Text = "Form1";


        // Инициализация ProgressBar
        this.progressBar1 = new ProgressBar();
        this.progressBar1.Location = new System.Drawing.Point(12, 12);
        this.progressBar1.Size = new System.Drawing.Size(300, 23);
        this.progressBar1.Minimum = 0;
        this.progressBar1.Maximum = 100;
        this.progressBar1.Value = 0;

            // Инициализация кнопки Plus
        this.buttonPlus = new Button();
        this.buttonPlus.Location = new System.Drawing.Point(12, 50);
        this.buttonPlus.Size = new System.Drawing.Size(75, 23);
        this.buttonPlus.Text = "Plus";
        this.buttonPlus.Click += new System.EventHandler(this.ButtonPlus_Click);

            // Инициализация кнопки Minus
        this.buttonMinus = new Button();
        this.buttonMinus.Location = new System.Drawing.Point(100, 50);
        this.buttonMinus.Size = new System.Drawing.Size(75, 23);
        this.buttonMinus.Text = "Minus";
        this.buttonMinus.Click += new System.EventHandler(this.ButtonMinus_Click);

            // Инициализация таймера
        this.timer1 = new System.Windows.Forms.Timer();
        this.timer1.Interval = 1000;
        this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);

            // Настройка формы
        this.Controls.Add(this.progressBar1);
        this.Controls.Add(this.buttonPlus);
        this.Controls.Add(this.buttonMinus);
        this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
    }

    #endregion
}
