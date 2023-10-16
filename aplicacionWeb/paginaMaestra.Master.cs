using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aplicacionWeb
{
    public partial class paginaMaestra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["PrimerCarga"] == null)
                {
                    Session.Add("idUsuario", -1);
                    Session.Add("mailUsuario", null);

                    Session["PrimerCarga"] = true;
                }
            }
        }
    }
}