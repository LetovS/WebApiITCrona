### Описание
В данном проекте реализована работа одного ```Web Api``` c [Web Api](https://ipinfo.io)

На вход подается строка в формате IP, далее в конвеере ASP.net выполняется [Валидация](https://github.com/LetovS/WebApiITCrona/blob/master/WebApiITCrona/Infrastructure/Validators/IpRequestValidator.cs) 

При успешной валидации вызывается [Service](https://github.com/LetovS/WebApiITCrona/blob/master/WebApiITCrona/Services/GeoService.cs)

Алгоритм сервиса: ```Получение по IP``` сущности из БД сервиса, далее выполняется формерование ```Request Url``` с выполнением запроса.

Если ```В БД сервиса``` такого IP нет, то ```IP``` добавляется в БД. После возвращается ```response``` в [формате](https://github.com/LetovS/WebApiITCrona/blob/master/WebApiITCrona/Infrastructure/Models/IpInfoResponse.cs) 

#### Swagger
Настроен Swagger, с документированием методов.

```shell
services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Web API",
        Version = "v1"
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
```

#### CI
Настроен простенький [CI](https://github.com/LetovS/WebApiITCrona/actions)

#### Unit tests
Тестируется:
- валидация входящего строкового представления IP Address [link](https://github.com/LetovS/WebApiITCrona/blob/master/tests/UnitTests/Validators/IpRequestValidatorTest.cs)
- DI контейнер [link](https://github.com/LetovS/WebApiITCrona/blob/master/tests/UnitTests/Dependencies/DependenciesTests.cs)
