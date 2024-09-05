using Blog.Domain.Entity.Write;
using Blog.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.DbConfigurations;
public class InitialData
{
    private readonly WriteDbContext _context;

    public InitialData(WriteDbContext context)
    {
        _context = context;
    }

    public async Task Invoke()
    {
        await _context.Database.EnsureDeletedAsync();
        await _context.Database.MigrateAsync();
        await AddAdmin();
        await AddUsers();
    }

    public async Task AddAdmin()
    {
        var passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("admin");

        var admin = UserEntity.Create("admin@admin.admin", passwordHash, "admin", RoleEntity.Admin);

        await _context.Users.AddAsync(admin.Value);
        await _context.SaveChangesAsync();

        return;
    }

    public async Task AddUsers()
    {
        for (var i = 0; i < 5; i++)
        {
            var passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword($"user{i}");
            var user = UserEntity.Create($"user{i}@user.user", passwordHash, "");
            await _context.Users.AddAsync(user.Value);
            //var article = ArticleEntity.Create(
            //    $"Article #{i}",
            //    $"Some Description for new article #{i}",
            //    "Unit of Work - это паттерн определяющий логическую транзакцию т.е. атомарную синхронизацию изменений в объектах, " +
            //    "помещённых в объект UoW с хранилищем (базой данных).\r\n\r\nЕсли обратиться к исходному описанию этого паттерна у " +
            //    "Мартина Фаулера - то видно что объект, реализующий этот паттерн отвечает за накопление информации о том какие объекты " +
            //    "входят в транзакцию и каковы их изменния относительно исходных значений в хранилище. Основная работа производится " +
            //    "в методе commit() который отвечает за вычисление изменений в сохранённых в UoW объектах и синхронизацию этих " +
            //    "изменений с хранилищем (базой данных).\r\n\r\nПаттерн Unit of Work как правило не является полностью " +
            //    "самостоятельным, он обычно тесно связан с паттерном Identity Map, задача которого - " +
            //    "сохранение карты созданных объектов, взятых из хранилища с тем чтобы гарантировать что одна единица " +
            //    "информации из хранилища представлена ровно одним экземпляром объекта данных в приложении. Это позволяет " +
            //    "избежать конфликтов изменений т.к. не допускает ситуации когда два объекта, представляющих один и тот" +
            //    " же элемент данных в хранилище, изменены по-разному. Информация из Identity Map используется в методе" +
            //    " commit() паттерна Unit of Work для вычисления разницы между исходными данными и накопленными изменениями.",
            //    new[] { TagEntity.Create($"Tag{i}").Value });

            //user.Value.PostArticle(article.Value);
        }
        await _context.SaveChangesAsync();

        return;
    }
}
