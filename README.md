# Online Book Shop

Приложение основано на ASP.NET CORE Framework и состоит из двух частей: веб-приложения и базы данных. Обе части взаимодействуют с использованием ядра Entity Framework (EF). Все классы и зависимости поддерживаются внедрением зависимостей Dependency Injection (DI).

## База Данных
Все объекты хранятся в Microsoft SQL Server 2022. База данных имеет два контекста: базу данных и идентификатор. Первый выделяет объекты, связанные с продуктами и заказами. Второй отвечает за авторизацию и регистрацию, которые управляются с помощью ASP.NET Identity.

## Веб-приложение
Веб-приложение основано на шаблоне Model-View-Controller (MVC). Модели между базой данных и представлением сопоставляются вручную. Все представления используют Razor pages и Bootstrap. Приложение разделено на три области: Администратор и Магазин.

## Пользователи

### Администратор имеет права на:

<li>добавление / удаление / изменение товаров (изменение с изображением товара все еще в процессе);
<li>просмотр всех заказов и обновление статуса заказа;
<li>удалить /изменить адрес электронной почты, пароль или права пользователя;
<li>управление ролями;
  
### Пользователь имеет права на:

<li>просмотр карточки товара;
<li>поиск товара по названию;
<li>оформить заказ;
<li>оставить отзыв о товаре (осуществаляется через WEB API, работает только через Docker Compose);
<li>добавить товар в избранное;  
<li>незарегистрированный пользователь не может приобрести какой-либо продукт (необходимо решить)
  
### Для тестирования каждой из пользовательских областей, пожалуйста, используйте следующие данные:

Электронная почта администратора = "iamgroot@gmail.com "; Пароль администратора = "1123581321_Ajax";
Электронная почта тестового пользователя = "ajaxstas@gmail.com "; Тестовый пароль пользователя = "_Stas123";

## Отладка
Чтобы облегчить процесс отладки, была использована библиотека Serilog.
