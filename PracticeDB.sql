
/* ==========================================
   PRACTICEDB - ВСЕ 10 ЗАДАНИЙ
   SQL SERVER MANAGEMENT STUDIO
   ========================================== */

-- ЗАДАНИЕ 1. СОЗДАНИЕ БАЗЫ ДАННЫХ

USE master;
GO

IF DB_ID(N'PracticeDB') IS NOT NULL
BEGIN
    ALTER DATABASE PracticeDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE PracticeDB;
END;
GO

CREATE DATABASE PracticeDB;
GO

USE PracticeDB;
GO

CREATE TABLE Departments (
    DepartmentId INT PRIMARY KEY,
    DepartmentName NVARCHAR(100) NOT NULL
);

CREATE TABLE Employees (
    EmployeeId INT PRIMARY KEY,
    EmployeeName NVARCHAR(100) NOT NULL,
    DepartmentId INT,
    ManagerId INT NULL,
    Salary DECIMAL(10,2),
    HireDate DATE,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(DepartmentId),
    FOREIGN KEY (ManagerId) REFERENCES Employees(EmployeeId)
);

CREATE TABLE Projects (
    ProjectId INT PRIMARY KEY,
    ProjectName NVARCHAR(100) NOT NULL,
    Budget DECIMAL(12,2),
    StartDate DATE
);

CREATE TABLE EmployeeProjects (
    EmployeeId INT,
    ProjectId INT,
    Hours DECIMAL(8,2),
    PRIMARY KEY (EmployeeId, ProjectId),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId),
    FOREIGN KEY (ProjectId) REFERENCES Projects(ProjectId)
);

-- Проверка таблиц
SELECT * FROM Departments;
SELECT * FROM Employees;
SELECT * FROM Projects;
SELECT * FROM EmployeeProjects;


-- ЗАДАНИЕ 2. INSERT - ЗАПОЛНЕНИЕ ДАННЫМИ

INSERT INTO Departments (DepartmentId, DepartmentName)
VALUES
(1, N'IT'),
(2, N'HR'),
(3, N'Finance'),
(4, N'Marketing');

INSERT INTO Employees
(EmployeeId, EmployeeName, DepartmentId, ManagerId, Salary, HireDate)
VALUES
(1, N'Александр', 1, NULL, 85000, '2020-03-15'),
(2, N'Анна', 2, NULL, 55000, '2023-04-10'),
(3, N'Иван', 1, 1, 65000, '2022-06-20'),
(4, N'Мария', 3, NULL, 60000, '2021-01-12'),
(5, N'Андрей', 2, 2, 45000, '2023-09-05'),
(6, N'Елена', 4, NULL, 70000, '2019-11-25'),
(7, N'Дмитрий', 1, 1, 50000, '2024-02-14'),
(8, N'Алина', 3, 4, 58000, '2023-07-18'),
(9, N'Сергей', 4, 6, 40000, '2022-12-01'),
(10, N'Ольга', 1, 1, 62000, '2021-08-30');

INSERT INTO Projects (ProjectId, ProjectName, Budget, StartDate)
VALUES
(1, N'Разработка сайта', 200000, '2024-01-15'),
(2, N'Мобильное приложение', 350000, '2024-03-01'),
(3, N'Финансовый анализ', 150000, '2023-11-10'),
(4, N'Рекламная кампания', 100000, '2024-05-20'),
(5, N'Обновление системы', 250000, '2024-06-01');

INSERT INTO EmployeeProjects (EmployeeId, ProjectId, Hours)
VALUES
(1, 1, 120),
(1, 5, 80),
(2, 4, 60),
(3, 1, 100),
(3, 2, 90),
(4, 3, 110),
(5, 4, 70),
(6, 4, 130),
(7, 5, 50),
(8, 3, 85),
(10, 1, 95),
(10, 2, 75);

-- Проверка количества записей
SELECT COUNT(*) AS DepartmentsCount FROM Departments;
SELECT COUNT(*) AS EmployeesCount FROM Employees;
SELECT COUNT(*) AS ProjectsCount FROM Projects;
SELECT COUNT(*) AS AssignmentsCount FROM EmployeeProjects;


-- ЗАДАНИЕ 3. SELECT + WHERE

-- 1. Зарплата больше 50000
SELECT *
FROM Employees
WHERE Salary > 50000;

-- 2. Нанятые в 2023 году
SELECT *
FROM Employees
WHERE YEAR(HireDate) = 2023;

-- 3. Имена на букву А
SELECT *
FROM Employees
WHERE EmployeeName LIKE N'А%';

-- 4. Сотрудники отдела 2
SELECT *
FROM Employees
WHERE DepartmentId = 2;

-- 5. Зарплата от 40000 до 60000
SELECT *
FROM Employees
WHERE Salary BETWEEN 40000 AND 60000;


-- ЗАДАНИЕ 4. ORDER BY + TOP

-- 1. Топ-3 по зарплате
SELECT TOP 3 *
FROM Employees
ORDER BY Salary DESC;

-- 2. Топ-5 самых давних сотрудников
SELECT TOP 5 *
FROM Employees
ORDER BY HireDate ASC;

-- 3. Сортировка по отделу и зарплате
SELECT *
FROM Employees
ORDER BY DepartmentId ASC, Salary DESC;


-- ЗАДАНИЕ 5. АГРЕГАЦИЯ

-- 1. Количество сотрудников
SELECT COUNT(*) AS TotalEmployees
FROM Employees;

-- 2. Сумма зарплат
SELECT SUM(Salary) AS TotalSalary
FROM Employees;

-- 3. Средняя зарплата
SELECT ROUND(AVG(Salary), 2) AS AverageSalary
FROM Employees;

-- 4. Минимальная и максимальная зарплата
SELECT
    MIN(Salary) AS MinSalary,
    MAX(Salary) AS MaxSalary
FROM Employees;

-- 5. Количество сотрудников с зарплатой больше 50000
SELECT COUNT(*) AS EmployeesOver50000
FROM Employees
WHERE Salary > 50000;


-- ЗАДАНИЕ 6. GROUP BY

SELECT
    DepartmentId,
    COUNT(*) AS EmployeeCount,
    AVG(Salary) AS AverageSalary,
    SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId
ORDER BY AverageSalary DESC;


-- ЗАДАНИЕ 7. GROUP BY + HAVING

-- 1. Отделы с количеством сотрудников больше 2
SELECT
    DepartmentId,
    COUNT(*) AS EmployeeCount
FROM Employees
GROUP BY DepartmentId
HAVING COUNT(*) > 2;

-- 2. Отделы со средней зарплатой больше 55000
SELECT
    DepartmentId,
    AVG(Salary) AS AverageSalary
FROM Employees
GROUP BY DepartmentId
HAVING AVG(Salary) > 55000;

-- 3. Отделы с суммарной зарплатой больше 150000
SELECT
    DepartmentId,
    SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId
HAVING SUM(Salary) > 150000;


-- ЗАДАНИЕ 8. INNER JOIN

SELECT
    Employees.EmployeeName,
    Departments.DepartmentName,
    Employees.Salary
FROM Employees
INNER JOIN Departments
    ON Employees.DepartmentId = Departments.DepartmentId
ORDER BY
    Departments.DepartmentName ASC,
    Employees.Salary DESC;


-- ЗАДАНИЕ 9. LEFT JOIN

SELECT
    Employees.EmployeeId,
    Employees.EmployeeName
FROM Employees
LEFT JOIN EmployeeProjects
    ON Employees.EmployeeId = EmployeeProjects.EmployeeId
WHERE EmployeeProjects.EmployeeId IS NULL;


-- ЗАДАНИЕ 10. МНОЖЕСТВЕННЫЙ JOIN

SELECT
    Employees.EmployeeName,
    Departments.DepartmentName,
    Projects.ProjectName,
    EmployeeProjects.Hours
FROM Employees
INNER JOIN Departments
    ON Employees.DepartmentId = Departments.DepartmentId
INNER JOIN EmployeeProjects
    ON Employees.EmployeeId = EmployeeProjects.EmployeeId
INNER JOIN Projects
    ON EmployeeProjects.ProjectId = Projects.ProjectId
ORDER BY
    Departments.DepartmentName ASC,
    Employees.EmployeeName ASC,
    Projects.ProjectName ASC;


-- ФИНАЛЬНАЯ ПРОВЕРКА ВСЕХ ТАБЛИЦ

SELECT * FROM Departments;
SELECT * FROM Employees;
SELECT * FROM Projects;
SELECT * FROM EmployeeProjects;

PRINT N'ВСЕ 10 ЗАДАНИЙ ВЫПОЛНЕНЫ!';
