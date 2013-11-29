using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace InstutiteOfFineArt
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //AWARDS
            RouteTable.Routes.MapPageRoute("AwardDetail", "award/{id}/edit", "~/Views/Awards/Edit.aspx");
            RouteTable.Routes.MapPageRoute("AwardIndex", "awards", "~/Views/Awards/Index.aspx");
            RouteTable.Routes.MapPageRoute("AwardSearch", "awards/search", "~/Views/Awards/Search.aspx");
            RouteTable.Routes.MapPageRoute("AwardNew", "awards/new", "~/Views/Awards/New.aspx");
            RouteTable.Routes.MapPageRoute("AwardShow", "awards/{id}", "~/Views/Awards/Show.aspx");
            RouteTable.Routes.MapPageRoute("AwardList", "awards/list", "~/Views/Awards/List.aspx");

            //CUSTOMERS
            RouteTable.Routes.MapPageRoute("CustomersIndex", "customers", "~/Views/Customers/Index.aspx");
            RouteTable.Routes.MapPageRoute("CustomersDetail", "customers/{id}/edit", "~/Views/Customers/Edit.aspx");
            RouteTable.Routes.MapPageRoute("CustomersSearch", "customers/search", "~/Views/Customers/Search.aspx");
            RouteTable.Routes.MapPageRoute("CustomersNew", "customers/new", "~/Views/Customers/New.aspx");
            RouteTable.Routes.MapPageRoute("CustomersShow", "customers/{id}", "~/Views/Customers/Show.aspx");
            RouteTable.Routes.MapPageRoute("CustomersList", "customers/list", "~/Views/Customers/List.aspx");

            //EXHIBITIONS
            RouteTable.Routes.MapPageRoute("ExhibitionsIndex", "exhibitions", "~/Views/Exhibitions/Index.aspx");
            RouteTable.Routes.MapPageRoute("ExhibitionsDetail", "exhibitions/{id}/edit", "~/Views/Exhibitions/Edit.aspx");
            RouteTable.Routes.MapPageRoute("ExhibitionsSearch", "exhibitions/search", "~/Views/Exhibitions/Search.aspx");
            RouteTable.Routes.MapPageRoute("ExhibitionsNew", "exhibitions/new", "~/Views/Exhibitions/New.aspx");
            RouteTable.Routes.MapPageRoute("ExhibitionsShow", "exhibitions/{id}", "~/Views/Exhibitions/Show.aspx");
            RouteTable.Routes.MapPageRoute("ExhibitionsList", "exhibitions/list", "~/Views/Exhibitions/List.aspx");

            //PAINTINGS
            RouteTable.Routes.MapPageRoute("PaintingsIndex", "paintings", "~/Views/Paintings/Index.aspx");
            RouteTable.Routes.MapPageRoute("PaintingsDetail", "paintings/{id}/edit", "~/Views/Paintings/Edit.aspx");
            RouteTable.Routes.MapPageRoute("PaintingsSearch", "paintings/search", "~/Views/Paintings/Search.aspx");
            RouteTable.Routes.MapPageRoute("PaintingsNew", "paintings/new", "~/Views/Paintings/New.aspx");
            RouteTable.Routes.MapPageRoute("PaintingsShow", "paintings/{id}", "~/Views/Paintings/Show.aspx");
            RouteTable.Routes.MapPageRoute("PaintingsList", "paintings/list", "~/Views/Paintings/List.aspx");

            //USERS
            RouteTable.Routes.MapPageRoute("UsersIndex", "users", "~/Views/Users/Index.aspx");
            RouteTable.Routes.MapPageRoute("UsersDetail", "users/{id}/edit", "~/Views/Users/Edit.aspx");
            RouteTable.Routes.MapPageRoute("UsersSearch", "users/search", "~/Views/Users/Search.aspx");
            RouteTable.Routes.MapPageRoute("UsersNew", "users/new", "~/Views/Users/New.aspx");
            RouteTable.Routes.MapPageRoute("UsersShow", "users/{id}", "~/Views/Users/Show.aspx");
            RouteTable.Routes.MapPageRoute("UsersList", "users/list", "~/Views/Users/List.aspx");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}