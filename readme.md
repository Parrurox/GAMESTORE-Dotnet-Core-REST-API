🚀 Exciting Journey in .NET Development! 🎮

📚 I recently added the `miniapis.extension` package from the NuGet Gallery to my web API project. This package provides convenient input validation for my application.

🔧 To start, I created a new web API project using the `dotnet new web` command. With the help of `dotnet watch run`, I can now hot reload the server and quickly see the changes by pressing `ctrl + r`.

🔍 To organize my code, I added an `endpoints` folder and created classes for each endpoint. This allowed me to refactor my `program.cs` file and use the `app.<endpoint_class_method>()` syntax for cleaner code.

📦 I also created a `repositories` folder to store my game list, making it read-only. This separation of concerns improved the maintainability of my project.

🔧 I implemented CRUD operations by defining new methods and made the game list private instead of static. This enhanced the encapsulation of my code.

🌟 Understanding service lifetimes, I introduced an interface called `IGamesRepository` and moved it to a separate file. Now, I pass the `IGamesRepository` type as an argument in my endpoints instead of creating an instance at the top.

🔌 Finally, I registered my instance in the `program.cs` file to ensure proper dependency injection.

Join me on this amazing journey in .NET development! Let's build robust and scalable applications together. 🚀💻

#dotnet #webdevelopment #dotnetcore #journey #linkedinpromo
