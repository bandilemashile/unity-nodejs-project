const Pool  = require("pg").Pool 

const pool = new Pool({
user: "postgres",
password: "mashile",
database: "car_database",
host: "localhost",
port: 5432

});

module.exports = pool;

