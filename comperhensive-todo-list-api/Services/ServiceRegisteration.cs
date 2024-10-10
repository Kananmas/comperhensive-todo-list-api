using comperhensive_todo_list_api.Services.Interface.General;
using comperhensive_todo_list_api.Services.Interface.TodoService;
using comperhensive_todo_list_api.Services.Interface.TodoStepService;
using comperhensive_todo_list_api.Services.Interface.UserService;
using comperhensive_todo_list_api.Services.Objects.General;
using comperhensive_todo_list_api.Services.Objects.TodoService;
using comperhensive_todo_list_api.Services.Objects.TodoStepService;
using comperhensive_todo_list_api.Services.Objects.UserService;
using comperhensive_todo_list_api.Validators;

namespace comperhensive_todo_list_api.Services
{
    public static class ServiceRegisteration
    {
        public static void RegisterMainServices(this IServiceCollection services)
        {
            // general services
            services.AddTransient<IHttpContextAccessor , HttpContextAccessor>();
            services.AddSingleton<IJwtServices, JwtServices>();

            // todo service reg
            services.AddScoped<IGetTodoService, GetTodoService>();
            services.AddScoped<IPostTodoService, PostTodoService>();
            services.AddScoped<IUpdateTodoService, UpdateTodoService>();
            services.AddScoped<IDeleteTodoService, DeleteTodoService>();

            // todostep service reg
            services.AddScoped<IGetTodoStepService, GetTodoStepService>();
            services.AddScoped<IPostTodoStepService , PostTodoStepService>();
            services.AddScoped<IDeleteTodoStepService , DeleteTodoStepService>();   
            services.AddScoped<IUpdateTodoStepService , UpdateTodoStepService>();

            // user service reg
            services.AddScoped<IGetUserService, GetUserService>();
            services.AddScoped<IPostUserService, PostUserService>();
            services.AddScoped<IUpdateUserService, UpdateUserService>();
            services.AddScoped<IDeleteUserService, DeleteUserService>();



            services.AddScoped<UserValidator>();
            services.AddScoped<TodoValidator>();
            services.AddScoped<TodoStepValidator>();

        }
    }
}
