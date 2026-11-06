# SQL notes

Учебная база: `PracticeDB`. Скрипт создания и заполнения: `init.sql`. Запускайте его в SSMS или через `sqlcmd` из отдельного соединения, не подключённого к `PracticeDB`: скрипт удаляет и пересоздаёт эту базу. Для проверки заданий с изменением данных (16–18) сначала повторно выполните `init.sql`.

## Task 01 — Создание базы и таблиц

### Запрос

```sql
SELECT name AS TableName
FROM sys.tables
WHERE name IN (N'Departments', N'Employees', N'Projects', N'EmployeeProjects')
ORDER BY name;

SELECT COUNT(*) AS ForeignKeyCount
FROM sys.foreign_keys
WHERE parent_object_id IN (
    OBJECT_ID(N'dbo.Departments'),
    OBJECT_ID(N'dbo.Employees'),
    OBJECT_ID(N'dbo.Projects'),
    OBJECT_ID(N'dbo.EmployeeProjects')
);
```

### Результат

Четыре таблицы: `Departments`, `Employees`, `EmployeeProjects`, `Projects`. `ForeignKeyCount = 4`.

### Вывод

Скрипт `init.sql` создаёт таблицы, первичные ключи и связи, включая связь руководителя с сотрудником.

## Task 02 — Заполнение данными

### Запрос

```sql
SELECT N'Departments' AS TableName, COUNT(*) AS RowCount FROM Departments
UNION ALL
SELECT N'Employees', COUNT(*) FROM Employees
UNION ALL
SELECT N'Projects', COUNT(*) FROM Projects
UNION ALL
SELECT N'EmployeeProjects', COUNT(*) FROM EmployeeProjects;
```

### Результат

| Таблица | Строк |
| --- | ---: |
| Departments | 4 |
| Employees | 10 |
| Projects | 5 |
| EmployeeProjects | 14 |

### Вывод

Исходные данные вставляются пакетными `INSERT ... VALUES` в `init.sql`; повторный запуск скрипта возвращает базу к исходному состоянию.

## Task 03 — SELECT и WHERE

### Запрос

```sql
SELECT EmployeeId, EmployeeName, Salary FROM Employees WHERE Salary > 50000 ORDER BY EmployeeId;
SELECT EmployeeId, EmployeeName, HireDate FROM Employees WHERE YEAR(HireDate) = 2023 ORDER BY EmployeeId;
SELECT EmployeeId, EmployeeName FROM Employees WHERE EmployeeName LIKE N'А%' ORDER BY EmployeeId;
SELECT EmployeeId, EmployeeName FROM Employees WHERE DepartmentId = 2 ORDER BY EmployeeId;
SELECT EmployeeId, EmployeeName, Salary FROM Employees WHERE Salary BETWEEN 40000 AND 60000 ORDER BY EmployeeId;
```

### Результат

1. Зарплата выше 50000: 7 сотрудников — Анна Иванова, Пётр Сидоров, Мария Кузнецова, Ольга Смирнова, Дмитрий Орлов, Елена Волкова, Алексей Лебедев.
2. Найдены Иван Петров (2023-02-10) и Елена Волкова (2023-06-01).
3. Имена на «А»: Анна Иванова и Алексей Лебедев.
4. Отдел 2: Ольга Смирнова, Дмитрий Орлов, Елена Волкова.
5. Диапазон 40000–60000 включительно: Мария Кузнецова, Иван Петров, Дмитрий Орлов, Елена Волкова, Сергей Морозов, Наталья Соколова.

### Вывод

Каждый фильтр применяется независимо; `BETWEEN` включает обе границы.

## Task 04 — ORDER BY и TOP

### Запрос

```sql
SELECT TOP (3) EmployeeName, Salary
FROM Employees
ORDER BY Salary DESC, EmployeeId;

SELECT TOP (5) EmployeeName, HireDate
FROM Employees
ORDER BY HireDate, EmployeeId;

SELECT EmployeeName, DepartmentId, Salary
FROM Employees
ORDER BY DepartmentId, Salary DESC, EmployeeName;
```

### Результат

Топ зарплат: Алексей Лебедев — 90000; Пётр Сидоров — 72000; Анна Иванова — 65000.

Пять самых давних сотрудников: Алексей Лебедев — 2018-05-25; Пётр Сидоров — 2019-07-01; Анна Иванова — 2020-03-15; Ольга Смирнова — 2020-09-05; Мария Кузнецова — 2021-11-20.

Третий запрос возвращает всех 10 сотрудников, сначала по `DepartmentId`, внутри отдела по зарплате по убыванию.

### Вывод

Дополнительный ключ сортировки делает порядок стабильным при равных значениях.

## Task 05 — Агрегатные функции

### Запрос

```sql
SELECT COUNT(*) AS EmployeeCount,
       SUM(Salary) AS SalaryTotal,
       ROUND(AVG(Salary), 2) AS SalaryAverage,
       MIN(Salary) AS MinSalary,
       MAX(Salary) AS MaxSalary,
       SUM(CASE WHEN Salary > 50000 THEN 1 ELSE 0 END) AS Above50000
FROM Employees;
```

### Результат

| EmployeeCount | SalaryTotal | SalaryAverage | MinSalary | MaxSalary | Above50000 |
| ---: | ---: | ---: | ---: | ---: | ---: |
| 10 | 589000.00 | 58900.00 | 43000.00 | 90000.00 | 7 |

### Вывод

Агрегаты считают общую статистику по сотрудникам; `CASE` позволяет посчитать строки, удовлетворяющие условию.

## Task 06 — GROUP BY по отделам

### Запрос

```sql
SELECT DepartmentId,
       COUNT(*) AS EmployeeCount,
       ROUND(AVG(Salary), 2) AS AverageSalary,
       SUM(Salary) AS SalaryTotal
FROM Employees
GROUP BY DepartmentId
ORDER BY AverageSalary DESC, DepartmentId;
```

### Результат

| DepartmentId | EmployeeCount | AverageSalary | SalaryTotal |
| ---: | ---: | ---: | ---: |
| 4 | 1 | 90000.00 | 90000.00 |
| 1 | 4 | 60000.00 | 240000.00 |
| 2 | 3 | 57000.00 | 171000.00 |
| 3 | 2 | 44000.00 | 88000.00 |

### Вывод

`GROUP BY` формирует по одной строке на отдел, а сортировка выполняется по средней зарплате.

## Task 07 — GROUP BY и HAVING

### Запрос

```sql
SELECT DepartmentId, COUNT(*) AS EmployeeCount
FROM Employees
GROUP BY DepartmentId
HAVING COUNT(*) > 2;

SELECT DepartmentId, AVG(Salary) AS AverageSalary
FROM Employees
GROUP BY DepartmentId
HAVING AVG(Salary) > 55000;

SELECT DepartmentId, SUM(Salary) AS SalaryTotal
FROM Employees
GROUP BY DepartmentId
HAVING SUM(Salary) > 150000;
```

### Результат

Больше двух сотрудников: отделы 1 (4 сотрудника) и 2 (3 сотрудника).

Средняя зарплата выше 55000: отделы 1 (60000), 2 (57000) и 4 (90000).

Суммарная зарплата выше 150000: отделы 1 (240000) и 2 (171000).

### Вывод

`HAVING` фильтрует уже сгруппированные результаты по агрегатам.

## Task 08 — INNER JOIN сотрудников и отделов

### Запрос

```sql
SELECT e.EmployeeName, d.DepartmentName, e.Salary
FROM Employees AS e
INNER JOIN Departments AS d ON d.DepartmentId = e.DepartmentId
ORDER BY d.DepartmentName, e.Salary DESC, e.EmployeeName;
```

### Результат

| Сотрудник | Отдел | Зарплата |
| --- | --- | ---: |
| Ольга Смирнова | Аналитика | 61000.00 |
| Дмитрий Орлов | Аналитика | 58000.00 |
| Елена Волкова | Аналитика | 52000.00 |
| Алексей Лебедев | Менеджмент | 90000.00 |
| Пётр Сидоров | Разработка | 72000.00 |
| Анна Иванова | Разработка | 65000.00 |
| Мария Кузнецова | Разработка | 55000.00 |
| Иван Петров | Разработка | 48000.00 |
| Сергей Морозов | Тестирование | 45000.00 |
| Наталья Соколова | Тестирование | 43000.00 |

Сортировка названий отделов и сотрудников внутри отдела следует правилам сортировки текущей базы данных.

### Вывод

`INNER JOIN` связывает каждую строку сотрудника с существующим отделом по внешнему ключу.

## Task 09 — LEFT JOIN: сотрудники без проектов

### Запрос

```sql
SELECT e.EmployeeId, e.EmployeeName
FROM Employees AS e
LEFT JOIN EmployeeProjects AS ep ON ep.EmployeeId = e.EmployeeId
WHERE ep.EmployeeId IS NULL;
```

### Результат

| EmployeeId | EmployeeName |
| ---: | --- |
| 9 | Наталья Соколова |

### Вывод

Проверка `IS NULL` на стороне присоединённой таблицы находит сотрудника без назначений.

## Task 10 — Сотрудники, отделы и проекты

### Запрос

```sql
SELECT e.EmployeeName, d.DepartmentName, p.ProjectName, ep.Hours
FROM Employees AS e
INNER JOIN Departments AS d ON d.DepartmentId = e.DepartmentId
INNER JOIN EmployeeProjects AS ep ON ep.EmployeeId = e.EmployeeId
INNER JOIN Projects AS p ON p.ProjectId = ep.ProjectId
ORDER BY d.DepartmentId, e.EmployeeName, p.ProjectName;
```

### Результат

Возвращается 14 назначений:

| Сотрудник | Отдел | Проект | Часы |
| --- | --- | --- | ---: |
| Анна Иванова | Разработка | CRM System | 120 |
| Анна Иванова | Разработка | Data Warehouse | 80 |
| Иван Петров | Разработка | Legacy Refactor | 40 |
| Иван Петров | Разработка | Mobile App | 90 |
| Мария Кузнецова | Разработка | Mobile App | 100 |
| Пётр Сидоров | Разработка | AI Assistant | 60 |
| Пётр Сидоров | Разработка | CRM System | 150 |
| Дмитрий Орлов | Аналитика | AI Assistant | 50 |
| Дмитрий Орлов | Аналитика | Data Warehouse | 70 |
| Елена Волкова | Аналитика | Mobile App | 95 |
| Ольга Смирнова | Аналитика | Data Warehouse | 110 |
| Сергей Морозов | Тестирование | Legacy Refactor | 130 |
| Алексей Лебедев | Менеджмент | AI Assistant | 200 |
| Алексей Лебедев | Менеджмент | CRM System | 30 |

### Вывод

Соединение четырёх таблиц выводит подробности каждого назначения; сотрудник без проекта в результат не попадает.

## Task 11 — Self-join руководителей

### Запрос

```sql
SELECT e.EmployeeName,
       m.EmployeeName AS ManagerName
FROM Employees AS e
LEFT JOIN Employees AS m ON m.EmployeeId = e.ManagerId
ORDER BY e.EmployeeId;
```

### Результат

| Сотрудник | Руководитель |
| --- | --- |
| Анна Иванова | NULL |
| Пётр Сидоров | NULL |
| Мария Кузнецова | Пётр Сидоров |
| Иван Петров | Анна Иванова |
| Ольга Смирнова | NULL |
| Дмитрий Орлов | Ольга Смирнова |
| Елена Волкова | NULL |
| Сергей Морозов | NULL |
| Наталья Соколова | Алексей Лебедев |
| Алексей Лебедев | NULL |

### Вывод

Самосоединение связывает сотрудника с его руководителем; `LEFT JOIN` сохраняет сотрудников без руководителя.

## Task 12 — Подзапросы в WHERE

### Запрос

```sql
SELECT EmployeeName, Salary
FROM Employees
WHERE Salary > (SELECT AVG(Salary) FROM Employees)
ORDER BY Salary DESC;

SELECT EmployeeName, Salary
FROM Employees
WHERE Salary = (SELECT MAX(Salary) FROM Employees);
```

### Результат

Средняя зарплата равна 58900. Выше неё получают Алексей Лебедев (90000), Пётр Сидоров (72000), Анна Иванова (65000) и Ольга Смирнова (61000). Максимальная зарплата — у Алексея Лебедева (90000).

### Вывод

Скалярные подзапросы возвращают агрегат для сравнения с каждой строкой основного запроса.

## Task 13 — Скалярный подзапрос в SELECT

### Запрос

```sql
SELECT e.EmployeeName,
       e.Salary,
       e.DepartmentId,
       CAST(ROUND(
           e.Salary - (
               SELECT AVG(e2.Salary)
               FROM Employees AS e2
               WHERE e2.DepartmentId = e.DepartmentId
           ), 2
       ) AS DECIMAL(10,2)) AS DifferenceFromDepartmentAverage
FROM Employees AS e
ORDER BY e.EmployeeId;
```

### Результат

| Сотрудник | Зарплата | DepartmentId | Отклонение |
| --- | ---: | ---: | ---: |
| Анна Иванова | 65000.00 | 1 | 5000.00 |
| Пётр Сидоров | 72000.00 | 1 | 12000.00 |
| Мария Кузнецова | 55000.00 | 1 | -5000.00 |
| Иван Петров | 48000.00 | 1 | -12000.00 |
| Ольга Смирнова | 61000.00 | 2 | 4000.00 |
| Дмитрий Орлов | 58000.00 | 2 | 1000.00 |
| Елена Волкова | 52000.00 | 2 | -5000.00 |
| Сергей Морозов | 45000.00 | 3 | 1000.00 |
| Наталья Соколова | 43000.00 | 3 | -1000.00 |
| Алексей Лебедев | 90000.00 | 4 | 0.00 |

### Вывод

Коррелированный подзапрос рассчитывает среднюю зарплату отдельно для отдела каждой строки.

## Task 14 — EXISTS и NOT EXISTS

### Запрос

```sql
SELECT e.EmployeeId, e.EmployeeName
FROM Employees AS e
WHERE EXISTS (
    SELECT 1
    FROM EmployeeProjects AS ep
    WHERE ep.EmployeeId = e.EmployeeId
)
ORDER BY e.EmployeeId;

SELECT e.EmployeeId, e.EmployeeName
FROM Employees AS e
WHERE NOT EXISTS (
    SELECT 1
    FROM EmployeeProjects AS ep
    WHERE ep.EmployeeId = e.EmployeeId
)
ORDER BY e.EmployeeId;
```

### Результат

Первый запрос возвращает 9 сотрудников: всех, кроме Натальи Соколовой (EmployeeId 9). Второй запрос возвращает только Наталью Соколову.

### Вывод

`EXISTS` проверяет наличие связанной строки, не добавляя столбцы проекта в результат.

## Task 15 — UNION и UNION ALL

### Запрос

```sql
SELECT EmployeeId, EmployeeName
FROM Employees
WHERE Salary > 60000
UNION
SELECT EmployeeId, EmployeeName
FROM Employees
WHERE HireDate < '2022-01-01'
ORDER BY EmployeeId;

SELECT EmployeeId, EmployeeName
FROM Employees
WHERE Salary > 60000
UNION ALL
SELECT EmployeeId, EmployeeName
FROM Employees
WHERE HireDate < '2022-01-01'
ORDER BY EmployeeId;
```

### Результат

`UNION` возвращает 6 строк: сотрудников с EmployeeId 1, 2, 3, 5, 8 и 10. `UNION ALL` возвращает 10 строк; сотрудники с EmployeeId 1, 2, 5 и 10 входят в обе выборки и повторяются.

### Вывод

`UNION` удаляет дубликаты по выбранным столбцам, а `UNION ALL` сохраняет их.

## Task 16 — UPDATE зарплат и даты найма

Перед выполнением восстановите исходные данные запуском `init.sql`.

### Запрос

```sql
SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE DepartmentId = 1
ORDER BY EmployeeId;

UPDATE Employees
SET Salary = Salary * 1.10
WHERE DepartmentId = 1;

SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE DepartmentId = 1
ORDER BY EmployeeId;

SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE HireDate < '2022-01-01'
ORDER BY EmployeeId;

UPDATE Employees
SET Salary = Salary + 5000
WHERE HireDate < '2022-01-01';

SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE HireDate < '2022-01-01'
ORDER BY EmployeeId;

SELECT EmployeeId, EmployeeName, HireDate
FROM Employees
WHERE EmployeeId = 7;

UPDATE Employees
SET HireDate = '2023-05-15'
WHERE EmployeeId = 7;

SELECT EmployeeId, EmployeeName, HireDate
FROM Employees
WHERE EmployeeId = 7;
```

### Результат

После повышения отдела 1 на 10%: Анна Иванова — 71500.00; Пётр Сидоров — 79200.00; Мария Кузнецова — 60500.00; Иван Петров — 52800.00.

После прибавки 5000 сотрудникам, нанятым до 2022 года: Анна — 76500.00; Пётр — 84200.00; Мария — 65500.00; Ольга — 66000.00; Сергей — 50000.00; Алексей — 95000.00. Иван Петров не попадает в этот фильтр.

Дата найма Елены Волковой (EmployeeId 7) изменяется с 2023-06-01 на 2023-05-15.

### Вывод

Обновления применяются последовательно: сотрудники отдела 1, принятые до 2022 года, получают обе прибавки.

## Task 17 — DELETE

Перед выполнением восстановите исходные данные запуском `init.sql`. Блок удаления из рабочих таблиц обёрнут в транзакцию и в конце откатывается, чтобы база осталась исходной.

### Запрос

```sql
BEGIN TRANSACTION;

SELECT COUNT(*) AS ZeroHourAssignmentsBefore
FROM EmployeeProjects
WHERE Hours = 0;

DELETE FROM EmployeeProjects
WHERE Hours = 0;

SELECT COUNT(*) AS ZeroHourAssignmentsAfter
FROM EmployeeProjects
WHERE Hours = 0;

SELECT COUNT(*) AS EmployeeAssignmentsBefore
FROM EmployeeProjects
WHERE EmployeeId = 4;

DELETE FROM EmployeeProjects
WHERE EmployeeId = 4;

SELECT COUNT(*) AS EmployeeAssignmentsAfter
FROM EmployeeProjects
WHERE EmployeeId = 4;

SELECT COUNT(*) AS EmployeeBefore
FROM Employees
WHERE EmployeeId = 4;

DELETE FROM Employees
WHERE EmployeeId = 4;

SELECT COUNT(*) AS EmployeeAfter
FROM Employees
WHERE EmployeeId = 4;

ROLLBACK TRANSACTION;

SELECT COUNT(*) AS EmployeeRestored
FROM Employees
WHERE EmployeeId = 4;

SELECT EmployeeId, DepartmentId INTO #EmployeeDeleteDemo
FROM Employees;

SELECT COUNT(*) AS TestRowsBefore FROM #EmployeeDeleteDemo;
DELETE FROM #EmployeeDeleteDemo WHERE DepartmentId = 3;
SELECT COUNT(*) AS TestRowsAfterWhere FROM #EmployeeDeleteDemo;
DELETE FROM #EmployeeDeleteDemo;
SELECT COUNT(*) AS TestRowsAfterAll FROM #EmployeeDeleteDemo;
DROP TABLE #EmployeeDeleteDemo;
```

### Результат

Назначений с `Hours = 0`: 0 до и после удаления. У EmployeeId 4 — 2 назначения до удаления и 0 после. Сотрудник с EmployeeId 4: 1 строка до удаления и 0 после; после `ROLLBACK` снова 1 строка. В тестовой копии: 10 строк до удаления, 8 после удаления строк отдела 3 и 0 после удаления оставшихся строк без `WHERE`.

### Вывод

Перед удалением сотрудника удаляются зависимые назначения. `DELETE` без `WHERE` выполняется только над временной таблицей; рабочие данные возвращаются через `ROLLBACK`.

## Task 18 — Транзакции

Перед выполнением восстановите исходные данные запуском `init.sql`.

### Запрос

```sql
SELECT EmployeeId, EmployeeName, Salary FROM Employees WHERE EmployeeId = 1;

BEGIN TRANSACTION;
UPDATE Employees SET Salary = Salary + 1000 WHERE EmployeeId = 1;
SELECT EmployeeId, EmployeeName, Salary FROM Employees WHERE EmployeeId = 1;
ROLLBACK TRANSACTION;
SELECT EmployeeId, EmployeeName, Salary FROM Employees WHERE EmployeeId = 1;

BEGIN TRANSACTION;
UPDATE Employees SET Salary = Salary + 1000 WHERE EmployeeId = 1;
SELECT EmployeeId, EmployeeName, Salary FROM Employees WHERE EmployeeId = 1;
COMMIT TRANSACTION;
SELECT EmployeeId, EmployeeName, Salary FROM Employees WHERE EmployeeId = 1;
```

### Результат

Исходная зарплата Анны Ивановой — 65000.00. В первой транзакции после `UPDATE` видно 66000.00; после `ROLLBACK` снова 65000.00. Во второй транзакции после `UPDATE` и `COMMIT` сохраняется 66000.00.

### Вывод

`ROLLBACK` отменяет изменение, а `COMMIT` фиксирует его. Для повторного запуска верните исходные данные через `init.sql`.

## Task 19 — Представление

### Запрос

```sql
CREATE VIEW dbo.vw_EmployeeDetails AS
SELECT e.EmployeeName,
       d.DepartmentName,
       p.ProjectName,
       ep.Hours
FROM Employees AS e
INNER JOIN Departments AS d ON d.DepartmentId = e.DepartmentId
INNER JOIN EmployeeProjects AS ep ON ep.EmployeeId = e.EmployeeId
INNER JOIN Projects AS p ON p.ProjectId = ep.ProjectId;
GO
SELECT * FROM dbo.vw_EmployeeDetails;
GO
DROP VIEW dbo.vw_EmployeeDetails;
GO
```

### Результат

Представление возвращает 14 строк назначений с именем сотрудника, отделом, проектом и количеством часов. Команда `DROP VIEW` удаляет представление.

### Вывод

Представление сохраняет запрос с несколькими соединениями под именем `vw_EmployeeDetails`.

## Task 20 — Индексы и статистика

Перед каждым сравнением восстановите исходные данные запуском `init.sql`. В SSMS включите фактический план выполнения. Не запускайте весь раздел повторно поверх уже созданных индексов без сброса базы.

### Запрос

```sql
SET STATISTICS IO ON;

SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE DepartmentId = 1 AND Salary > 50000;

CREATE INDEX IX_Employees_DepartmentId ON Employees(DepartmentId);
CREATE INDEX IX_Employees_Salary ON Employees(Salary);

SELECT EmployeeId, EmployeeName, Salary
FROM Employees
WHERE DepartmentId = 1 AND Salary > 50000;

SET STATISTICS IO OFF;
```

### Результат

В исходных данных запрос возвращает Анну Иванову (65000), Петра Сидорова (72000) и Марию Кузнецову (55000). Скрипт создаёт два требуемых индекса. Фактические logical reads и выбранный план зависят от экземпляра SQL Server и должны быть записаны по вкладке Messages и фактическому плану SSMS после запуска. На таблице из 10 строк оптимизатор может выбрать сканирование и после создания индексов; это не доказывает ошибку в индексе.

| Запуск | Logical reads | Фактический оператор |
| --- | --- | --- |
| До индексов | Заполнить по SSMS | Заполнить по фактическому плану |
| После индексов | Заполнить по SSMS | Заполнить по фактическому плану |

### Вывод

Индекс ускоряет поиск не во всех случаях: решение оптимизатора зависит от статистики, размера таблицы и стоимости чтения. Для корректного сравнения нужно фиксировать фактические показатели на своём экземпляре.
