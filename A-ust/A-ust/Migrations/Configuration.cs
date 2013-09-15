namespace A_ust.Migrations
{
    using A_ust.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<AustContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AustContext context)
        {
            WebSecurity.InitializeDatabaseConnection(
               "DefaultConnection",
               "UserProfile",
               "UserId",
               "UserName", autoCreateTables: true);

            #region UserManagement
        
            //seed default Roles
            AddRoles(context);

            //Seed default users
            AddUsers(context);
            #endregion
        }
        #region Helper Functions

        public void AddRoles(AustContext context)
        {
            String[] role = { "admin", "user"};
            foreach (String r in role)
            {
                if (!Roles.RoleExists(r))
                {
                    Roles.CreateRole(r);
                }

            }
        }
        public void AddUsers(AustContext context)
        {
            //Seed default users
            user[] users = { new user("admin", "password", "admin", "Alfred", "Hitchcock"), new user("groupadmin", "password", "user", "Luke", "Skywalker"), new user("user", "password", "user", "Barbie", "Roberts ") };
            foreach (user u in users)
            {
                if (!WebSecurity.UserExists(u.username))
                    WebSecurity.CreateUserAndAccount(
                     u.username,
                     u.password,
                     new { firstName = u.firstName, lastName = u.lastName }
                   );
                //Seed default Users In Roles
                if (!Roles.GetRolesForUser(u.username).Contains(u.role))
                {
                    Roles.AddUsersToRole(new[] { u.username }, u.role);
                }

            }
        }
        #endregion

        #region helper object
        class user
        {
            public String username;
            public String password;
            public String role;
            public String firstName;
            public String lastName;
            
            public user(String u, String p, String r, String f, String l)
            {
                this.username = u;
                this.password = p;
                this.role = r;
                this.lastName = l;
                this.firstName = f;
                
            }

        }
        #endregion

    }
}
