using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventReady.Application_Layer
{
    public partial class Calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DateTime d = calEvents.SelectedDate;

            //fd
            DateTime testthis = Convert.ToDateTime("05/29/2015");

        }
        public void calEvent_DayRender(object o, DayRenderEventArgs e)

        {
            DateTime date = Convert.ToDateTime("05/29/2015");
            /*if (e.Day.Date == Convert.ToDateTime())
            {

            }*/
        }
    }
}