<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="PartyInvites.Pages.Summary" %>
<%@ Import Namespace="PartyInvites" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="/Content/PartyStyles.css" />
</head>
<body>
    <h2>RSVP Summary</h2>

    <h3>People Who Will Attend</h3>
    <table>
        <thead>
            <tr><th>Name</th><th>Email</th><th>Phone</th></tr>
        </thead>
        <tbody ><%= GetResponses(true) %></tbody>
        
            <!-- Preivous omitted code nugget
            < % var yesData = ResponseRepository.GetRepository().GetAllResponses().Where(r => r.WillAttend.HasValue && r.WillAttend.Value);
                foreach (var rsvp in yesData)
                {
                    string htmlString = string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td>", rsvp.Name, rsvp.Email, rsvp.Phone);
                    Response.Write(htmlString);
                }
                % >
                -->


    </table>
    <h3>People Who Will Not Attend</h3>
    <table>
        <thead>
            <tr><th>Name</th><th>Email</th><th>Phone</th></tr>
        </thead>
        <tbody>
            <%= GetResponses(false) %>
        </tbody>
    </table>
</body>
</html>
