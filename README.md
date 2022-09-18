# Задание 1
Напишите на C# библиотеку для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам.
Дополнительно к работоспособности:
- Юнит-тесты
- Легкость добавления других фигур
- Вычисление площади фигуры без знания типа фигуры в compile-time
- Проверку на то, является ли треугольник прямоугольным
## Решение
### GeometricCalculator (Поддерживаемые фигуры: круг, треугольник, правильный многоугольник)
#### FirstSolution (реализация паттерна strategy):
- ##### Для добавления новой фигуры необходимо добавить её модель, унаследовав интерфейс IFigure, затем в Extension классе фигуры написать алгоритм вычисления площади, в "базовом" FigureExtensions дополнить оператор switch новой фигурой
- ##### Для вычисления площади вызвать метод CalculateArea у реализации IFigure

#### SecondSolution (реализация паттерна strategy с автоматическим определением необходимой стратегии в RunTime):
- ##### Для добавления новой фигуры необходимо добавить её модель, унаследовав интерфейс IFigure, затем создать класс стратегии для фигуры, наследующий  : BaseCalculateStrategy<TFigure> где TFigure - новая фигура
- ##### Для вычисления площади вызвать метод CalculateArea из класса Calculator
###### p.s. без DI не работает, IoC Container Autofac
###### Для работы библиотеки нужно добавить ссылку на неё в проект
```sh
    <ItemGroup>
      <ProjectReference Include="..\GeometricCalculator.Application.FirstSolution\GeometricCalculator.Application.FirstSolution.csproj" />
      <ProjectReference Include="..\GeometricCalculator.Application.SecondSolution\GeometricCalculator.Application.SecondSolution.csproj" />
    </ItemGroup>
```
Дополнительно для второго решения нужно зарегистрировать его в контейнере в классе Startup
```sh
    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterModule<SecondSolutionGeometricCalculatorModule>();
    }
```
# Задание 2
В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий,
в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории».
Если у продукта нет категорий, то его имя все равно должно выводиться

## Решение

### Postgres
Сначала я не обратил внимания в формулировке задания "В базе данных MS SQL Server" и написал запрос для Postgres

```sh
WITH 
    Products (Id, Name) AS (VALUES (1,'product1'), (2,'product2'), (3,'product3'), (4,'product4'), (5,'product5'), (6,'product6'), (7,'product7'), (8,'product8')),
    Categories (Id, Name) AS (VALUES (1,'category1'), (2,'category2'), (3,'category3'), (4,'category4'), (5,'category5'), (10,'category10'), (11,'category11')),
    ProductToCategories (ProductId,CategoryId) AS (SELECT p.Id,c.Id FROM Products p INNER JOIN Categories c on p.Id = c.Id)
SELECT prd.Name, ctg.Name FROM Products prd 
    LEFT OUTER JOIN ProductToCategories ptc ON prd.Id = ptc.ProductId
    LEFT OUTER JOIN  Categories ctg ON ctg.Id = ptc.CategoryId;
```
![query result](https://i.imgur.com/w7nUTZ3.png)

### MS SQL Server
С MS SQL Server почти не работал, не знал, что CTE в нем не может в CREATE, поэтому в тупую
```sh
CREATE TABLE Products(id INT PRIMARY KEY, name VARCHAR(255) NOT NULL);
CREATE TABLE Categories(id INT PRIMARY KEY, name VARCHAR(255) NOT NULL);
CREATE TABLE ProductToCategories(ProductId INT NOT NULL, CategoryId INT NOT NULL);

INSERT INTO Products VALUES (1,'product1'), (2,'product2'), (3,'product3'), (4,'product4'), (5,'product5'), (6,'product6'), (7,'product7'), (8,'product8');
INSERT INTO Categories VALUES (1,'category1'), (2,'category2'), (3,'category3'), (4,'category4'), (5,'category5'), (10,'category10'), (11,'category11');
INSERT INTO ProductToCategories (ProductId, CategoryId) (SELECT p.Id,c.Id FROM Products p INNER JOIN Categories c on p.Id = c.Id);

SELECT prd.Name, ctg.Name FROM Products prd
     LEFT OUTER JOIN ProductToCategories ptc ON prd.Id = ptc.ProductId
     LEFT OUTER JOIN  Categories ctg ON ctg.Id = ptc.CategoryId;

SELECT * FROM ProductToCategories;

-- DROP TABLE Products;
-- DROP TABLE Categories;
-- DROP TABLE ProductToCategories;
```
![query result](https://i.imgur.com/VpwO5fa.png)

