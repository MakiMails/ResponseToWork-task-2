using System.Data;
using System.Data.SqlClient;
using Dapper;

//Здравствуйте
//Размыто написано ТЗ второго задания, так как не понят, как должна выглядить БД.
//Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов.
//Что под этим подразумевается?
//Есть много вариантов, как это понять.
//Будет в БД одна таблица, где будет поля такие как название продукта и категория
//Или же будет две таблицы: Продукты(поля название продукта и категория) и Категория(категория и название продукта)
//Пожалуйста, отпишите https://t.me/MakiMails готов буду исправить программу, которая подойдет вашим условиям
//Спасибо за просмотр выполненного задания


SqlConnection sqlConnection = ConectDB();

if(sqlConnection != null)
{
    if(sqlConnection.State == ConnectionState.Open)
    {
        var products = sqlConnection.Query<Product>("SELECT * FROM Products").ToList();
        if(products.Count > 0)
        {
            foreach(var product in products)
            {
                Console.Write($"{product.NameProduct} ");
                Console.WriteLine(product.Сategory);
            }
        }
    }
    else
    {
        throw new Exception("Close BD");
    }
}
else
{
    throw new Exception("Not conect BD");
}

SqlConnection ConectDB()
{
    try
    {
        //Для запуска программы нужно указать путь к БД
        SqlConnection sqlConnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\3 курс\\works\\Work2\\Work2\\DatabaseProducts.mdf\";Integrated Security=True");
        sqlConnection.Open();
        return sqlConnection;
    }
    catch
    {
        Console.WriteLine("Неверый путь к подключению БД");
        return null;
    }
}

