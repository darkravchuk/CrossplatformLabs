# Інструкція для запуску проекту

## Запуск API (App.Api)
1. Перейдіть у директорію `App.Api` всередині папки Lab13:
   ```bash
   cd App.Api

2. Запустіть API за допомогою команди:
    ```bash
    dotnet run

## Запуск Web-клієнта (App.Web)
1. Перейдіть у директорію `App.Web` всередині папки Lab13:
    ```bash
    cd App.Web
2. Запустіть Angular-клієнт за допомогою команди:
    ```bash
    ng serve

# Функціонал

Цей проект включає наступний функціонал:
- Авторизація (Login)
- Вихід із системи (Log out)
- Відображення профілю користувача (Showing the user profile)
- Захист маршрутів за допомогою Authentication Guard (Protecting routes)
- Виклик API із автоматично прикріпленими Bearer-токенами (Calling APIs with automatically-attached bearer tokens)

## Конфігурація

Для коректної роботи застосунку потрібно налаштувати Auth0. У корені проекту є файл `auth_config.json`. Відкрийте файл і замініть значення на ті, які відповідають вашому Auth0:

```json
{
  "domain": "<YOUR AUTH0 DOMAIN>",
  "clientId": "<YOUR AUTH0 CLIENT ID>",
  "audience": "<YOUR AUTH0 API AUDIENCE IDENTIFIER>"
}
```
Окрім цього, для API-конфігурації використовується файл appsettings.json, в якому вказані параметри вашого Auth0-тенанту. Наприклад:

```json
{
  "Auth0": {
    "Domain": "<YOUR AUTH0 DOMAIN>",
    "ClientId": "<YOUR AUTH0 CLIENT ID>",
    "Audience": "<YOUR AUTH0 API AUDIENCE IDENTIFIER>"
  }
}
```
Переконайтеся, що значення в auth_config.json і в appsettings.json синхронізовані.