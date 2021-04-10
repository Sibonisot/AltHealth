using AltHealth.Data.Gateways.Repositories.Wrapper;
using System;
using System.Web.UI;

namespace AltHealth.App
{
    public partial class Contact : Page
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public Contact(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}