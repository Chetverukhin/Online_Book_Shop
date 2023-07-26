using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class AddDefaultProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Cost", "Description", "Genre", "ImageLink", "Isbn", "Name", "Pages", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Айзек Азимов", 595.0m, null, "Фантастика", "https://ndc.book24.ru/resize/820x1192/iblock/f21/f21f9483ee3861d440665b4411f2279e/300a6c758a8bdfeda1f6f5afc27b563e.jpg", "978-5-04-100014-1", "Я, Робот", 320, null, 2022 },
                    { 2, "Айзек Азимов", 434.0m, null, "Фантастика", "https://ndc.book24.ru/resize/820x1192/iblock/181/181beb5dbd902b55a4765e70e51231b8/aa10e3358076daa167348bc844c9decb.jpg", "978-5-04-093907-7", "Академия", 320, null, 2022 },
                    { 3, "Джек Лондон", 299.0m, null, "Приключения", "https://ndc.book24.ru/resize/820x1192/iblock/5b5/5b5af79c1d0c3a5847ad835b4c97d075/0ec5f7e31d749f17f26ebaa637afa619.jpg", "978-5-04-155023-3", "Сердца трех", 384, null, 2021 },
                    { 4, "Маккарти Кормак", 708.0m, null, "Фантастика", "https://ndc.book24.ru/resize/820x1192/iblock/be0/be0ddf53becceba6ff022c04d56b5817/d6b8855b357edfb326b31a88e8b96def.jpg", "978-5-389-14385-2", "Дорога", 320, null, 2018 },
                    { 5, "Джон Стейнбек", 575.0m, null, "Проза", "https://ndc.book24.ru/resize/820x1192/iblock/ea9/ea9eb4a164eac48fe14c20638213e01c/a47a1686f161bdce78d32b30e6975f3d.jpg", "978-5-17-982853-2", "О мышах и людях", 256, null, 2020 },
                    { 6, "Терри Пратчетт", 745.0m, null, "Фэнтези", "https://cdn.book24.ru/v2/ITD000000001286313/COVER/cover13d__w410.webp", "978-5-04-170567-1", "Пастушья корона", 384, null, 2023 },
                    { 7, "Анджей Сапковский", 519.0m, null, "Фэнтези", "https://cdn.book24.ru/v2/AST000000000025472/COVER/cover13d__w410.webp", "978-5-17-074112-0", "Меч Предназначения", 384, null, 2022 },
                    { 8, "Стиг Ларссон", 602.0m, null, "Детектив", "https://ndc.book24.ru/resize/820x1180/iblock/bad/bad1a2e028d38c5ff25cc194e3275574/5df4501d6356f6c94d8b22ca34519707.jpg", "978-5-04-102885-5", "Девушка с татуировкой дракона", 576, null, 2022 },
                    { 9, "Дуглас Адамс", 920.0m, null, "Фантастика", "https://ndc.book24.ru/resize/820x1192/iblock/ab1/ab139c2bdf94259370f5da9644a72663/487613949db6b3eb04c94490ce202e69.jpg", "978-5-17-098748-1", "Автостопом по галактике", 640, null, 2023 },
                    { 10, "Джордж Р.Р. Мартин", 819.0m, null, "Фэнтези", "https://ndc.book24.ru/resize/820x1180/iblock/d78/d782032aeb2a79f720423b339a16fb1a/cf9f7284d68e3dd7b9d1b7b8a7ff9c61.jpg", "978-5-17-077386-2", "Путешествия Тафа", 480, null, 2019 },
                    { 11, "Томас Харрис", 406.0m, null, "Детектив", "https://ndc.book24.ru/resize/820x1180/iblock/8ed/8edd954668cc5946b2d8be98162e19d9/b19b90e38142864977c6c73d0337437d.jpg", "978-5-04-170567-1", "Кари Мора", 320, null, 2019 },
                    { 12, "Ю Несбё", 406.0m, null, "Детектив", "https://ndc.book24.ru/resize/820x1180/iblock/155/1552f2966a722870dc095b98c65ce911/9e2a0c4e892877fc299aae3b78658668.jpg", "978-5-04-092924-5", "Макбет", 608, null, 2019 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
