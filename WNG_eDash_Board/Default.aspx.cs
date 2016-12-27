using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
namespace WNG_eDash_Board
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("<div id='mydiv' >");
            Response.Write("_");
            Response.Write("</div>");
            Response.Write("<script>mydiv.innerText = '';</script>");
            Response.Write("<script language=javascript>;");
            Response.Write("var dots = 0;var dotmax = 10;function ShowWait()");
            Response.Write("{var output; output = '正在装载页面';dots++;if(dots>=dotmax)dots=1;");
            Response.Write("for(var x = 0;x < dots;x++){output += '·';}mydiv.innerText =　output;}");
            Response.Write("function StartShowWait(){mydiv.style.visibility = 'visible'; ");
            Response.Write("window.setInterval('ShowWait()',1000);}");
            Response.Write("function HideWait(){mydiv.style.visibility = 'hidden';");
            Response.Write("window.clearInterval();}");
            Response.Write("StartShowWait();</script>");
            Response.Flush();
            Thread.Sleep(10000);
        }
    }
}