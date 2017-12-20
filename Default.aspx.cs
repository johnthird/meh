using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Text = "The server's fucking IP is this: " + DyndnsIP() + ". Fuck you!.<br/>Also, the current date is : " + DateTime.Now.ToString() + "<br/>Current Machine name: " + System.Environment.MachineName;
    }

    private string DyndnsIP()
    {
        return RequestToText("http://checkip.dyndns.org").Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address: ", "").Replace("</body></html>", "");
    }

    private string RequestToText(string requestUri)
    {
        System.Net.HttpWebRequest hwreq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(requestUri);
        System.Net.HttpWebResponse hwres = (System.Net.HttpWebResponse)hwreq.GetResponse();
        System.IO.StreamReader sr = new System.IO.StreamReader(hwres.GetResponseStream());
        string result = sr.ReadToEnd();
        sr.Close();
        hwres.Close();
        return result;
    }
}