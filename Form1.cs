using System;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace SyncDemo;

public partial class Form1 : Form
{


    Thread PlusThread = null;
    Thread MinusThread = null;
    public static object mtxA = new object();
    public static object mtxB = new object();
    public delegate void Progress();
    public Progress progressDelegate;
    public Progress minusDelegate;


    // Элементы которые должны быть объявлены
    private ProgressBar progressBar1;
    private Button buttonPlus;
    private Button buttonMinus;
    private System.Windows.Forms.Timer timer1;
    public Form1()
    {
        InitializeComponent();
        progressDelegate = new Progress(StepMethod);
        minusDelegate = new Progress(MinusMethod);
    }

    private void ThreadMinusFunc()
    {
        while (true)
        {
            lock (mtxA)
            {
                lock (mtxB)
                {
                    try
                    {
                        Invoke(minusDelegate);

                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        return;
                    }
                }
            }
        }
    }
    private void ThreadPlusFunc()
    {
        while (true)
        {
            lock (mtxA)
            {
                lock (mtxB)
                {   
                    try
                    {
                        Invoke(progressDelegate);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        return;
                    }
                    
                }
            }
        }
    }



    public void StepMethod()
    {
        if (progressBar1 != null && progressBar1.Value < progressBar1.Maximum)
                progressBar1.Value += 1;
    }
    public void MinusMethod()
    {
        if (progressBar1 != null && progressBar1.Value > progressBar1.Minimum)
            progressBar1.Value -= 1;
    }
    private void ButtonPlus_Click(object sender, EventArgs e)
    {
        if (PlusThread != null && PlusThread.IsAlive)
        {
            return;
        }

        PlusThread = new Thread(ThreadPlusFunc)
        {
            IsBackground = true,
            Priority = ThreadPriority.Normal
        };
        PlusThread.Start();
        timer1.Enabled = false;
        // buttonPlus.Enabled = false;
    }
    private void ButtonMinus_Click(object sender, EventArgs e)
    {
        Thread MinusThread = new Thread(ThreadMinusFunc)
        {
            IsBackground = true,
            Priority = ThreadPriority.AboveNormal
        };
        MinusThread.Start();
        timer1.Enabled = true;
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (PlusThread != null)
            PlusThread.Abort();
    }
    private void Timer1_Tick(object sender, EventArgs e)
    {
        Text = DateTime.Now.ToLongTimeString();
    }


}
