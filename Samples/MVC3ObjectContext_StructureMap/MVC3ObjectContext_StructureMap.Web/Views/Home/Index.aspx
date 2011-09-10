<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<MVC3ObjectContext_StructureMap.Data.Person>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
		Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Index</h2>

<% foreach (var person in Model) { %>
	<%= person.FirstName %>
	<%= person.LastName %>
	<br />
<% } %>

</asp:Content>
