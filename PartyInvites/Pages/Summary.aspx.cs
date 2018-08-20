using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using PartyInvites.Models;
using PartyInvites.Presenters;
using PartyInvites.Presenters.Results;


namespace PartyInvites.Pages
{
    public partial class Summary : System.Web.UI.Page
    {
        private IEnumerable<GuestResponse> data;

        [Ninject.Inject]
        public IPresenter<IEnumerable<GuestResponse>> presenter { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            data = ((DataResult<IEnumerable<GuestResponse>>)presenter
                .GetResult()).DataItem;
        }

        protected string GetResponses(bool accepted)
        {        
            StringBuilder html = new StringBuilder();
            var selectedData = data.Where(r => r.WillAttend.HasValue
            && r.WillAttend.Value == accepted);
            foreach (var rsvp in selectedData)
            {
                html.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td>", rsvp.Name, rsvp.Email, rsvp.Phone));
            }
            return html.ToString();

            /* old code
            var noData = ResponseRepository.GetRepository().GetAllResponses().Where(r => r.WillAttend.HasValue && !r.WillAttend.Value);
            foreach (var rsvp in noData)
            {
                html.Append(string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td>", rsvp.Name, rsvp.Email, rsvp.Phone));
            }
            */
        }
    }
}