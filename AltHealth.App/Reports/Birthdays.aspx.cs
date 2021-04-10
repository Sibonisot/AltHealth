using AltHealth.App.Extensions;
using AltHealth.Data.Gateways.Repositories.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltHealth.App.Reports
{
    public partial class Birthdays : System.Web.UI.Page
    {
        /// <summary>
        /// Property for repository to read data from database
        /// </summary>
        private readonly IRepositoryWrapper _repositoryWrapper;

        public Birthdays(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        /// <summary>
        /// Page initialisation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadBirthDaysGrid();
        }

        /// <summary>
        /// Load birthday grid by client info
        /// </summary>
        private void LoadBirthDaysGrid()
        {
            grdBirthDays.DataSource = _repositoryWrapper.ClientInfo.GetBirthDays();
            grdBirthDays.DataBind();
        }
        protected void grdBirthDays_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBirthDays.PageIndex = e.NewPageIndex;
            LoadBirthDaysGrid();
        }
    }
}