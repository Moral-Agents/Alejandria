using Alejandria.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alejandria.Services
{
    public static class InjectionDependency
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            return services.AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<ICommentRepository, CommentRepository>()
                .AddTransient<ICommentService, CommentService>()
                .AddTransient<ITeacherRepository, TeacherRepository>()
                .AddTransient<ITeacherService, TeacherService>();
        }
    }
}
