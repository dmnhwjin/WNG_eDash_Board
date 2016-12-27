using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Data.SqlClient;
using System.Configuration;
namespace WNG_eDash_Board
{
    public partial class _Default : Page
    {

        private SqlConnection cnn = null;
        public String strProdName = string.Empty;
        public int intTarget = 0;
        public int intCum = 0;
        public string dateTimeStr = string.Empty;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            string Server = Properties.Settings.Default.Server;
            string database = Properties.Settings.Default.Database;
            string user = Properties.Settings.Default.User;
            string password = Properties.Settings.Default.Password;

            SqlConnectionStringBuilder cnnStr = new SqlConnectionStringBuilder();
            cnnStr.DataSource = Server;
            cnnStr.InitialCatalog = database;
            cnnStr.UserID = user;
            cnnStr.Password = password;
            cnn = new SqlConnection(cnnStr.ConnectionString);
            try
            {
               
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("exec udf_queryPN", cnn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        strProdName = dr.GetString(0);
                    }
                    dr.Close();

                }
                string cmdTxt = string.Format("exec udf_queryTarget '{0}%'", strProdName.Substring(0, 9));
                using (SqlCommand cmd = new SqlCommand(cmdTxt, cnn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        intTarget = dr.GetInt32(0);
                    }
                    dr.Close();
                }
                DateTime now = DateTime.Now.AddHours(-15);
                DateTime dFrom =new DateTime(now.Year,now.Month,now.Day,now.Hour,0,0);
                DateTime dEnd = new DateTime(dFrom.Year, dFrom.Month, dFrom.Day, dFrom.AddHours(1).Hour, 0, 0);
                //string cmdTxtQty = string.Format("exec udf_queryTarget '{0}%','{1}','{2}'", strProdName.Substring(0, 9),dFrom,dEnd);
                using (SqlCommand cmd = new SqlCommand("exec udf_QueryQty @PartNUmber,@TimeStart,@TimeEnd", cnn))
                {
                    //DateTime dFrom = DateTime.Now.AddHours(-15);
                    //DateTime dEnd = new DateTime(dFrom.Year, dFrom.Month, dFrom.Day, dFrom.AddHours(1).Hour, 0, 0);
                    cmd.Parameters.AddWithValue("@partNumber", string.Format("{0}%", strProdName.Substring(0, 9)));
                     cmd.Parameters.AddWithValue("@TimeStart", dFrom);
                    cmd.Parameters.AddWithValue("@TimeEnd", dEnd);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        intCum = dr.GetInt32(0);
                    }
                    dr.Close();
                    cnn.Close();
                }

                


            }
            catch(Exception ex)
            {
                Response.ClearContent();
                Response.Write(ex.Message);
            }finally
            {
                cnn.Close();
            }

        }
        //{
        //    Response.Write("<div id='mydiv' >");
        //    Response.Write("_");
        //    Response.Write("</div>");
        //    Response.Write("<script>mydiv.innerText = '';</script>");
        //    Response.Write("<script language=javascript>;");
        //    Response.Write("var dots = 0;var dotmax = 10;function ShowWait()");
        //    Response.Write("{var output; output = '正在装载页面';dots++;if(dots>=dotmax)dots=1;");
        //    Response.Write("for(var x = 0;x < dots;x++){output += '·';}mydiv.innerText =　output;}");
        //    Response.Write("function StartShowWait(){mydiv.style.visibility = 'visible'; ");
        //    Response.Write("window.setInterval('ShowWait()',1000);}");
        //    Response.Write("function HideWait(){mydiv.style.visibility = 'hidden';");
        //    Response.Write("window.clearInterval();}");
        //    Response.Write("StartShowWait();</script>");
        //    Response.Flush();
        //    Thread.Sleep(10000);
        

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Timer1.Enabled = false;
            try
            {
                cnn.Open();
                DateTime Now = DateTime.Now.AddDays(-15);
                DateTime newTime = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0);
                TimeSpan ts = newTime.AddHours(1) - Now;
                string strMin = string.Format("{0}", ts.Minutes);
                string strSecond = string.Format("{0}", ts.Seconds);
                if (strMin.Length == 1)
                {
                    strMin = "0" + strMin;
                }
                if (strSecond.Length == 1)
                {
                    strSecond = "0" + strSecond;
                }
                dateTimeStr = string.Format("00:{0}:{1}", strMin, strSecond);
                using (SqlCommand cmd = new SqlCommand("exec udf_queryPN", cnn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        strProdName = dr.GetString(0);
                    }
                    dr.Close();

                }
                string cmdTxt = string.Format("exec udf_queryTarget '{0}%'", strProdName.Substring(0, 9));
                using (SqlCommand cmd = new SqlCommand(cmdTxt, cnn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        intTarget = dr.GetInt32(0);
                    }
                    dr.Close();
                }
                DateTime now = DateTime.Now.AddHours(-15);
                DateTime dFrom = new DateTime(now.Year, now.Month, now.Day, now.Hour, 0, 0);
                DateTime dEnd = new DateTime(dFrom.Year, dFrom.Month, dFrom.Day, dFrom.AddHours(1).Hour, 0, 0);
                //string cmdTxtQty = string.Format("exec udf_queryTarget '{0}%','{1}','{2}'", strProdName.Substring(0, 9),dFrom,dEnd);
                double mPerCent= now.Minute / 60;
                double iPercent = intCum / intTarget;
                if(iPercent<mPerCent)
                {
                    //strWebColore = "God";
                }else
                {
                    //strWebColore = "LightBlue";
                }

                using (SqlCommand cmd = new SqlCommand("exec udf_QueryQty @PartNUmber,@TimeStart,@TimeEnd", cnn))
                {
                    //DateTime dFrom = DateTime.Now.AddHours(-15);
                    //DateTime dEnd = new DateTime(dFrom.Year, dFrom.Month, dFrom.Day, dFrom.AddHours(1).Hour, 0, 0);
                    cmd.Parameters.AddWithValue("@partNumber", string.Format("{0}%", strProdName.Substring(0, 9)));
                    cmd.Parameters.AddWithValue("@TimeStart", dFrom);
                    cmd.Parameters.AddWithValue("@TimeEnd", dEnd);

                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        intCum = dr.GetInt32(0);
                    }
                    dr.Close();
                     
                }
                Timer1.Enabled = true;
                cnn.Close();
                
            }
            catch(Exception ex)
            {
                Response.ClearContent();
                Response.Write(ex.Message);
            }finally
            {
                Timer1.Enabled = true;
                cnn.Close();
            }

        }

        protected void Timer1_Init(object sender, EventArgs e)
        {

        }
        
    }
}