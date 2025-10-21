Use master;
-- drop database dbdemo;
-- create database dbdemo;
Use dbdemo;

CREATE TABLE Products (
    Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    Code NVARCHAR(50) NOT NULL ,    -- UNIQUE
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL
);