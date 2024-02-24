using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using Telerik.WinControls.UI;

public class PleaseWait : IDisposable {
    private RadForm mSplash;
    
  private Point mLocation;   

  public PleaseWait(Point location) 
  {
    mLocation = location;
    Thread t = new Thread(new ThreadStart(workerThread));
    t.IsBackground = true;
    t.SetApartmentState(ApartmentState.STA);
    t.Start();
  }
  public void Dispose() 
  {
    mSplash.Invoke(new MethodInvoker(stopThread));
  }
  private void stopThread() 
  {
    mSplash.Close();
  }
  private void workerThread() 
  {
    mSplash = new RadForm();   // Substitute this with your own
    mSplash.StartPosition = FormStartPosition.CenterScreen;
    mSplash.Location = mLocation;
    mSplash.TopMost = true;
    mSplash.ClientSize = new System.Drawing.Size(64, 158);
    mSplash.FormBorderStyle = FormBorderStyle.None;    
    PictureBox pb = new PictureBox();
    pb.Image = global::ET.Properties.Resources.loading;
    pb.Dock = DockStyle.Top;
    pb.SizeMode = PictureBoxSizeMode.StretchImage;
    pb.Size = new System.Drawing.Size(128,128 );
    PictureBox pb1 = new PictureBox();
    pb1.Image = global::ET.Properties.Resources.Untitled;
    pb1.Dock = DockStyle.Bottom;
    pb1.SizeMode = PictureBoxSizeMode.StretchImage;
    pb1.Size = new System.Drawing.Size(128, 30);
    mSplash.Controls.Add(pb);
    mSplash.Controls.Add(pb1);      
    Application.Run(mSplash);
  }
}
