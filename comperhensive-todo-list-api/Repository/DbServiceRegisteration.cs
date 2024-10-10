using comperhensive_todo_list_api.Repository.DatabaseContext.Interface;
using comperhensive_todo_list_api.Repository.DatabaseContext.Obejct;

namespace comperhensive_todo_list_api.Repository
{
    public static class DbServiceRegisteration
    {
        public static void RegisterDatabaseContext(this IServiceCollection services)
        {
            services.AddSingleton<IMainDatabaseContext , MainDatabaseContext>();
        }
    }
}
