# Fitlros

Um filtro pode ser adicionado ao pipeline com um de três escopos:

* `:global` - Aplicado a todos os arquivos, configurando no `program.cs`:

```csharp
builder.Services.AddMvc(options =>
{ 
    options.Filters.Add(new LoggingActionFilter());     
});
```

* `:controller` - Aplicado a todos os métodos de um controller, configurando no `controller.cs`:

```csharp
[LoggingAction]
public class HomeController : Controller
{
    // ...
}
```

* `:action` - Aplicado a um método específico, configurando no `controller.cs`:

```csharp
[HeaderAction("X-API-VERSION", "1")]
public IActionResult Index()
{
    // ...
}
```

## Injeção de dependência

O filtro que NÃO implementa a classe `Attribute` pode receber dependências através do construtor. Para isso, é necessário registrar o filtro no `program.cs`:

```csharp
builder.Services.AddScoped<LoggingActionFilter>();
```
E configurar no `controller.cs`:

```csharp
[ServiceFilter(typeof(LoggingActionAttribute))]
public class HomeController : Controller
{
    // ...
}
```


## Referências

https://learn.microsoft.com/pt-br/aspnet/core/mvc/controllers/filters?view=aspnetcore-6.0

