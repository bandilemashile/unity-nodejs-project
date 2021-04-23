const express = require('express');
const id = require('shortid');
const app = express();
const pool = require("./db");
const createCsvWriter = require('csv-writer').createObjectCsvWriter;


app.use(express.json());

app.get('/', (req, res) => {
    res.send('Hello Unity Developers!');
});

let car = {
		
		"name": "BMW",
		"model": "325i",
		"speed": "260"
	};


//get method to get values 
app.get('/car', (req, res) => {
    res.send(car);
});


//post method to insert values in csv and database
app.post('/car/create', (req, res) => {
	let cars = [{
		
		"name": "BMW",
		"model": "325i",
		"speed": "260"
	}];
	
	let  newCar = {
	
		"name": req.body.name,
		"model": req.body.model,
		"speed": req.body.speed
	};


//create csv file with header
const csvWriter = createCsvWriter({
    path: 'file.csv',
    header: [
		
        {id: 'name', title: 'NAME'},
        {id: 'model', title: 'MODEL'},
		{id: 'speed', title: 'SPEED'}
    ]
});
 

 //write to file
csvWriter.writeRecords(cars)     
    .then(() => {
        console.log('...Done');
    });




	cars.push(newCar);
	console.log(cars);
	res.send(cars);
});




app.listen(3000, () => console.log('started and listening on localhost:3000.'));

console.log(car);