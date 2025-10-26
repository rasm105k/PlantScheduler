window.onload = async () => 
{
    await getPlants();
}

async function getPlants()  
{
    const res = await fetch('http://localhost:5015/api/plant/getAll');
    
    if (!res.ok) 
        throw new Error(res.statusText);
    
    const plantList = document.getElementById('plant-list');
    await res.json().then(data => 
    {
        data.forEach(item => {
            const li = document.createElement('li');
            li.textContent = item.name;
            plantList.appendChild(li);
        });  
    }).catch(error => {
        console.error('Error fetching plants:', error)
    });
}

async function createPlant()
{
    const plantName = document.getElementById('plant-name').value;
    const plantSpecies =  document.getElementById('plant-species').value;
    const lastWatered = document.getElementById('watering-interval').value;  
    
    const plant = {
        name: plantName,
        species: plantSpecies,
        lastWatered: lastWatered
    };

    await fetch('http://localhost:5015/api/plant/createPlant',
    {
        method: 'POST',
        headers: {
            "Content-type": "application/json; charset=UTF-8"
        },
        body: JSON.stringify(plant)

    }).catch(error => {
        console.error('Error creating plant:', error);
    });
}