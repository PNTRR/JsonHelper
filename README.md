# 🗄️ JsonHelper

**A simple yet powerful helper for working with JSON files in C#.**

`JsonHelper` is a lightweight utility that frees you from the routine of writing code to create, delete, save, and load JSON files. No more repetitive `File.WriteAllText` or `JsonSerializer` — just call the methods and focus on what matters.

## ✨ Features
- 🚀 **Instant operation** — no setup required, just plug and play.
- 📁 **Flexible paths** — save files in the project folder or your custom path.
- 🧩 **Array handling** — batch create, delete, and save files.
- 🧠 **Strong typing** — load data with type specification (`LoadFile<T>`).
- 📦 **Pretty JSON** — automatic formatting with indentation.

## 📋 Version History
| Version | Date | Changes |
|--------|------|-----------|
| 1.0.0 | 2026-03-20 | ✨ First release. Basic methods: create, delete, save, and load JSON files. |

## 🛠️ How to add to your project
1. **Copy the file** `JsonHelper.cs` to your project folder.
2. **Done!** Now you can create an instance of the class and use its methods.
>Important: The class uses a static field projectDir, which by default points to a folder 3 levels above Environment.CurrentDirectory. If your project structure differs, you can modify this logic or use methods that specify the path.

## 🧪 Usage Examples

1. Creating a JSON file
   ```csharp
   var helper = new JsonHelper();
   
   // Create a file in the project folder
   helper.CreateFile("settings");
   
   // Create a file at a specific path
   helper.CreateFile(@"C:\MyApp\Data", "config");
   
   // Create multiple files
   helper.CreateFile(new[] { "users", "products", "orders" });

2. Saving data
   ```csharp
   var user = new { Name = "Micheal Wilder", Age = 30, Role = "Developer" };
   var products = new[] { "Laptop", "Mouse", "Keyboard" };
   
   // Save an object to a file
   helper.SaveFile("user", user);
   
   // Save to a different folder
   helper.SaveFile(@"C:\MyApp\Data", "inventory", products);
   
   // Save multiple objects to different files
   helper.SaveFile(
    new[] { "user", "products" },
    new object[] { user, products }
   );

3. Loading data
   ```csharp
   // Load data with type specification
   var loadedUser = helper.LoadFile<UserData>(out var userData, "user");
   Console.WriteLine($"Имя: {userData.Name}, Возраст: {userData.Age}");
   
   // You can also use the return value
   UserData sameUser = helper.LoadFile<UserData>(out _, "user");

4. Deleting files
   ```csharp
   // Delete a single file
   helper.DeleteFile("old_data");
   
   // Delete multiple files
   helper.DeleteFile(new[] { "temp1", "temp2", "cache" });

   // Delete using full path
   helper.DeleteFile(@"C:\MyApp\Data", "obsolete");

## 👤 Creator

**PanTerra4464 / PNTRR / Michael Wilder**

A developer who values clean code and your time.

Made with ❤️ for those who love order in their data.
