# Fitlros

Um filtro pode ser adicionado ao pipeline com um de três escopos:

* `:global` - Aplicado a todos os arquivos, configurando no `program.cs`:

```csharp
builder.Services.AddMvc(options =>
{ 
    options.Filters.Add(new LoggingActionAttribute());     
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

