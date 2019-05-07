//using System;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Resto.Data
//{
//    public static class DbInitializer
//    {
//        public static async Task Initialize(ApplicationDbContext context, UserManager<IdentityUser> userManager,
//            RoleManager<IdentityRole> roleManager, IConfiguration configuration, RpcClient rpcClient)
//        {
//            await roleManager.CreateAsync(new IdentityRole(UserRole.Service));
//            var user = new IdentityUser
//            {
//                UserName = "service@svc.svc",
//                Email = "service@svc.svc",
//            };
//            await userManager.CreateAsync(user, "servicepassword");
//            await userManager.AddToRoleAsync(user, UserRole.Service);
//        }
//    }
//}