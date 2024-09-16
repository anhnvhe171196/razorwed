using _12_EntityFramworkEx.Models;
using _12_EntityFramworkEx.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

namespace _12_EntityFramworkEx
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            builder.Services.AddOptions();

            // Cấu hình mail settings
            var mailSetting = builder.Configuration.GetSection("MailSettings");
            builder.Services.Configure<MailSettings>(mailSetting);
            builder.Services.AddSingleton<IEmailSender, SendMailService>();

            // Cấu hình Razor Pages
            builder.Services.AddRazorPages();

            // Cấu hình DbContext
            builder.Services.AddDbContext<MyBlogContext>(options =>
            {
                string connectionString = builder.Configuration.GetConnectionString("MyBlogDatabase");
                options.UseSqlServer(connectionString);
            });

            // Cấu hình Identity
            builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<MyBlogContext>()
                .AddDefaultTokenProviders();

            // Cấu hình Identity Options
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Cấu hình password
                options.Password.RequireDigit = false; // Không bắt phải có số
                options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
                options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
                options.Password.RequireUppercase = false; // Không bắt buộc chữ in
                options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
                options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

                // Cấu hình Lockout (khóa người dùng sau nhiều lần thất bại)
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // Khóa 5 phút
                options.Lockout.MaxFailedAccessAttempts = 5; // Thất bại 5 lần thì khóa
                options.Lockout.AllowedForNewUsers = true;

                // Cấu hình về User
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true; // Email là duy nhất

                // Cấu hình đăng nhập
                options.SignIn.RequireConfirmedEmail = true; // Yêu cầu xác nhận email
                options.SignIn.RequireConfirmedPhoneNumber = false; // Không yêu cầu xác nhận số điện thoại
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}

/*
    Identity:
        - Authentication: Xác định danh tính -> login, logout
        - Authorization: Xác thực quyền truy cập
        - Quản lý user: Sign Up, User, Role ...
 */
