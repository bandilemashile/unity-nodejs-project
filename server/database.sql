CREATE DATABASE car_database;

CREATE TABLE car(
    id SERIAL PRIMARY KEY,
    name VARCHAR(255),
    model VARCHAR(255),
    speed VARCHAR(250)
);