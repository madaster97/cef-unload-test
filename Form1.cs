using CefSharp;
using CefSharp.WinForms;

namespace source;

public partial class Form1 : Form
{
    private ChromiumWebBrowser browser;

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (MessageBox.Show("Are you sure you want to close the application?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
        {
            e.Cancel = true;
        } else {
            browser.BrowserCore.CloseBrowser(true);
            // browser.Dispose(); ???
            Cef.Shutdown();
        }
    }

    public Form1()
    {
        InitializeComponent();

        // Initialize CefSharp
        Cef.Initialize(new CefSettings());

        // Create a new ChromiumWebBrowser instance
        // browser = new ChromiumWebBrowser("https://www.google.com");
        browser = new ChromiumWebBrowser("<your URL here>");

        // Add the browser control to your form
        browser.Dock = DockStyle.Fill;
        this.Controls.Add(browser);
    }
}
