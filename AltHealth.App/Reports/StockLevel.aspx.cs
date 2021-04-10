using AltHealth.Data.Gateways.Repositories.Wrapper;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AltHealth.App.Reports
{
    public partial class StockLevel : System.Web.UI.Page
    {
        /// <summary>
        /// Property for repository to read data from database
        /// </summary>
        private readonly IRepositoryWrapper _repositoryWrapper;

        public StockLevel(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                LoadStockLevelGrid();
        }
        // Load data from database
        private void LoadStockLevelGrid()
        {
            grdStockLevels.DataSource = _repositoryWrapper.Suppliment.GetStockLevels();
            grdStockLevels.DataBind();
        }
        // Create index for the table 
        protected void grdStockLevels_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdStockLevels.PageIndex = e.NewPageIndex;
            LoadStockLevelGrid();
        }

        protected void grdStockLevels_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            // If the stock is less or equal to three highlight it with yellow color
            {
                if (int.Parse(e.Row.Cells[3].Text) == 3)
                    e.Row.BackColor = System.Drawing.Color.Khaki;

                // If the stock is less or equal to two highlight it with red color
                else if (int.Parse(e.Row.Cells[3].Text) <= 2)
                {
                    e.Row.BackColor = System.Drawing.Color.Salmon;
                    
                }
                // Highlight enough stock with green color 
                else {
                    e.Row.BackColor = System.Drawing.Color.LightGreen;
                 

                }
                    
            }
        }
    }
}