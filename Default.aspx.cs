using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    public static void ConsumeCPU(int percentage)
    {
        if (percentage < 0 || percentage > 100)
            throw new ArgumentException("percentage");
        Stopwatch watch = new Stopwatch();
        watch.Start();
        while (true)
        {
            // Make the loop go on for "percentage" milliseconds then sleep the 
            // remaining percentage milliseconds. So 40% utilization means work 40ms and sleep 60ms
            if (watch.ElapsedMilliseconds > percentage)
            {
                Thread.Sleep(100 - percentage);
                watch.Reset();
                watch.Start();
            }
        }
    }

    protected void Button_Click(object sender, EventArgs e)
    {
        ConsumeCPU(100);
    }
}