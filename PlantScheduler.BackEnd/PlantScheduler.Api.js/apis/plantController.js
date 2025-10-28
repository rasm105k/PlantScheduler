import express from 'express';

const app = express()
app.use(express.json());
const port = 5000
import PlantRepository from '../repositories/plantRepository.js';

app.get('/api/getAllPlants', (req, res) => {
    
    var plantRepository = new PlantRepository(); 
    var plants = plantRepository.getPlants();

    res.json(plants)
})


app.post('/createPlant', (req, res) => {

    const json = req.body;
    res.json({ message: 'Data received successfully', data: json });
});

app.listen(port, () => {
  console.log(`Starting app on port ${port}`)
})